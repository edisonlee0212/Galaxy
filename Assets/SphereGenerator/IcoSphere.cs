using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SphereGenerator{
	
	#if UNITY_EDITOR
	using UnityEditor;
	[CustomEditor (typeof (IcoSphere))]
	public class IcoSphereEditor : Editor{
		IcoSphere component;
		string filePath;

		[MenuItem("GameObject/3D Object/SphereGenerator/IcoSphere")]
		static void spawnIcoSphere(){
			GameObject sphere = new GameObject ();
			sphere.AddComponent<IcoSphere> ();
		}

		public void OnEnable(){
			component = (IcoSphere)target;
		}

		public override void OnInspectorGUI(){
			GUILayout.Label ("Ico Sphere Properties", EditorStyles.boldLabel);
			component.hardEdges = EditorGUILayout.Toggle ("Hard Edges", component.hardEdges);
			component.radius = EditorGUILayout.FloatField ("Radius", component.radius);
			if (!component.hardEdges) {
				component.subdivision = EditorGUILayout.IntSlider ("Subdivisions", component.subdivision, 0, 6);
			} else {
				component.subdivision = EditorGUILayout.IntSlider ("Subdivisions", component.subdivision, 0, 5);
			}
			GUILayout.Label (" ", EditorStyles.boldLabel);
			GUILayout.Label ("Save mesh in assets folder", EditorStyles.boldLabel);
			filePath = EditorGUILayout.TextField ("filePath", filePath);
			if (GUILayout.Button ("Save Mesh")){
				AssetDatabase.CreateAsset (component.generateMesh (component.subdivision, component.radius, component.hardEdges), "Assets/" + filePath + ".asset");
				AssetDatabase.SaveAssets ();
			}
			if (GUI.changed) {
				component.setMesh ();
			}
		}
	}
	#endif

	[ExecuteInEditMode]
	public class IcoSphere : MonoBehaviour {
		public int subdivision = 1;
		public float radius = 1.0f;
		public bool hardEdges = false;
		MeshFilter mf;
		MeshRenderer mr;

		public void setMesh(){
			if(mf != null)
				mf.sharedMesh = generateMesh(subdivision, radius, hardEdges);
		}

		void Start(){
			mf = gameObject.GetComponent<MeshFilter> ();
			if (mf == null)
				mf = gameObject.AddComponent<MeshFilter> ();
			mr = gameObject.GetComponent<MeshRenderer> ();
			if (mr == null) {
				mr = gameObject.AddComponent<MeshRenderer> ();
				mr.material = new Material(Shader.Find("Standard"));
			}
			setMesh ();
		}
			
		class VertOnEdge{
			public VertOnEdge(int vertexIndex, int vertexA, int vertexB){ vertIndex = vertexIndex; A = vertexA; B = vertexB;}
			public int vertIndex;
			public int A, B;//the verts he is connected to
		};

		public Mesh generateMesh(int subdivision = 0, float radius = 1.0f, bool hardEdges = false){
			Mesh sphere = new Mesh ();
			if (subdivision < 0) {
				//fail
				Debug.Log("[IcoSphere] generateMesh(): Subdivision has to be at least 0");
				return sphere;
			}

			//base starting mesh
			List<Vector3> vertices = new List<Vector3>(){
				new Vector3(0.000000f, -1.000000f, 0.000000f),
				new Vector3(0.723600f, -0.447215f, 0.525720f),
				new Vector3(-0.276385f, -0.447215f, 0.850640f),
				new Vector3(-0.894425f, -0.447215f, 0.000000f),
				new Vector3(-0.276385f, -0.447215f, -0.850640f),
				new Vector3(0.723600f, -0.447215f, -0.525720f),
				new Vector3(0.276385f, 0.447215f, 0.850640f),
				new Vector3(-0.723600f, 0.447215f, 0.525720f),
				new Vector3(-0.723600f, 0.447215f, -0.525720f),
				new Vector3(0.276385f, 0.447215f, -0.850640f),
				new Vector3(0.894425f, 0.447215f, 0.000000f),
				new Vector3(0.000000f, 1.000000f, 0.000000f)
			};
			int[] triangles = {
				0, 1, 2,
				1, 0, 5,
				0, 2, 3,
				0, 3, 4,
				0, 4, 5,
				1, 5, 10,
				2, 1, 6,
				3, 2, 7,
				4, 3, 8,
				5, 4, 9,
				1, 10, 6,
				2, 6, 7,
				3, 7, 8,
				4, 8, 9,
				5, 9, 10,
				6, 10, 11,
				7, 6, 11,
				8, 7, 11,
				9, 8, 11,
				10, 9, 11
			};

			for (int s = 0; s < subdivision; s++) {
				//this stores all the vertices that are part of a connection already so doublicate/overlapping vertices won't exist.
				List<VertOnEdge> connected = new List<VertOnEdge>();
				int[] newTriangles = new int[triangles.Length * 4];

				for (int t = 0; t < triangles.Length / 3; t++) {
					//create new vertices
					int A = triangles[t*3]; int B = triangles[t*3 + 1]; int C = triangles[t*3 + 2]; //vertices the triangle is connected to
					int ab = -1; int bc = -1; int ca = -1; //vertices the triangle is connected to
					List<int> connectionToBeRemoved = new List<int>(); //connections that have to be deleted AFTERWARDS!
					//look for dublicates
					//procedure : check if any of the connections are the same. Then set a flag, so no new one will be created there. 
					//Remember the vertexIndex and remove the connection, because it won't be needed after that
					//if no doubles have been found for a certain connection create one with a new vertex in the middle
					for (int c = 0; c < connected.Count; c++) {
						VertOnEdge voe = connected[c];
						if (voe.A == A) { //check if there is a connection between A and B or C
							if (voe.B == B) {
								ab = voe.vertIndex;
								connectionToBeRemoved.Add(c);
							}
							else if (voe.B == C) {
								ca = voe.vertIndex;
								connectionToBeRemoved.Add(c);
							}
						} else if (voe.A == B) { //check if there is a connection between B and A or C
							if (voe.B == A) {
								ab = voe.vertIndex;
								connectionToBeRemoved.Add(c);
							}
							else if (voe.B == C) {
								bc = voe.vertIndex;
								connectionToBeRemoved.Add(c);
							}
						} else if (voe.A == C) { //check if there is a connection between C and A or B
							if (voe.B == A) {
								ca = voe.vertIndex;
								connectionToBeRemoved.Add(c);
							}
							else if (voe.B == B) {
								bc = voe.vertIndex;
								connectionToBeRemoved.Add(c);
							}
						}
					}
					//sort list descending indices and delete dublicates that were found
					connectionToBeRemoved.Sort();
					connectionToBeRemoved.Reverse ();
					for(int i = 0; i < connectionToBeRemoved.Count; i++){
						connected.RemoveAt(connectionToBeRemoved[i]);
					}
					//create new vertices and connections that don't exist
					if(ab == -1){ 
						vertices.Add((vertices[A] + vertices[B])/2);
						ab = vertices.Count - 1;
						connected.Add ( new VertOnEdge (ab, A, B));
					}
					if(bc == -1){ 
						vertices.Add((vertices[B] + vertices[C])/2);
						bc = vertices.Count - 1;
						connected.Add ( new VertOnEdge (bc, B, C));
					}
					if(ca == -1){ 
						vertices.Add((vertices[C] + vertices[A])/2);
						ca = vertices.Count - 1;
						connected.Add ( new VertOnEdge (ca, C, A));
					}

					//write triangles
					int triangleStartingIndex = t * 12;

					newTriangles [triangleStartingIndex] = A;
					newTriangles [triangleStartingIndex + 1] = ab;
					newTriangles [triangleStartingIndex + 2] = ca;

					newTriangles [triangleStartingIndex + 3] = ab;
					newTriangles [triangleStartingIndex + 4] = B;
					newTriangles [triangleStartingIndex + 5] = bc;

					newTriangles [triangleStartingIndex + 6] = bc;
					newTriangles [triangleStartingIndex + 7] = C;
					newTriangles [triangleStartingIndex + 8] = ca;

					newTriangles [triangleStartingIndex + 9] = ab;
					newTriangles [triangleStartingIndex + 10] = bc;
					newTriangles [triangleStartingIndex + 11] = ca;
				}

				//spherify
				for(int i = 0; i < vertices.Count; i++){
					vertices[i] = vertices[i].normalized;
				}

				triangles = null;
				triangles = newTriangles;
				//Debug.Log (connected.Count);
				//connected.Clear (); NOT neccessary, because if there would have been any left, then something is wrong
				newTriangles = null;
			}

			Vector3[] normals = null;
			Vector3[] verts = null;
			if (hardEdges) {
				//disconnect faces from each other
				verts = new Vector3[triangles.Length];
				normals = new Vector3[verts.Length];
				for(int i = 0; i < triangles.Length; i++){
					verts[i] = vertices[triangles[i]] * radius;
					normals [i] = verts [i];
					triangles [i] = i;
				}
			} else {
				//normals are smooth as usual
				normals = new Vector3[vertices.Count];
				verts = vertices.ToArray();
				for(int i = 0; i < normals.Length; i++){
					normals[i] = vertices[i];
					verts[i] *= radius;
				}
			}

			sphere.vertices = verts;
			sphere.normals = normals;
			sphere.triangles = triangles;
			if (hardEdges) {
				sphere.RecalculateNormals();
			}

			return sphere;
		}
	}

}