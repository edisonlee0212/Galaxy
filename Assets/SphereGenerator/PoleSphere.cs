using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SphereGenerator{
	
	#if UNITY_EDITOR
	using UnityEditor;
	[CustomEditor (typeof (PoleSphere))]
	public class PoleSphereEditor : Editor{
		PoleSphere component;
		string filePath;

		[MenuItem("GameObject/3D Object/SphereGenerator/PoleSphere")]
		static void spawnPoleSphere(){
			GameObject sphere = new GameObject ();
			sphere.AddComponent<PoleSphere> ();
		}

		public void OnEnable(){
			component = (PoleSphere)target;
		}

		public override void OnInspectorGUI(){
			GUILayout.Label ("Pole Sphere Properties", EditorStyles.boldLabel);
			component.hardEdges = EditorGUILayout.Toggle("Hard Edges", component.hardEdges);
			component.radius = EditorGUILayout.FloatField("Radius", component.radius);
			component.segments = EditorGUILayout.IntSlider("Segments", component.segments, 3, 100);
			component.rings = EditorGUILayout.IntSlider("Rings", component.rings, 1, 100);
			GUILayout.Label (" ", EditorStyles.miniLabel);

			GUILayout.Label ("Save mesh in assets folder", EditorStyles.boldLabel);
			filePath = EditorGUILayout.TextField("filePath", filePath);
			if (GUILayout.Button ("Save Mesh")) {
				AssetDatabase.CreateAsset( component.generateMesh(component.segments, component.rings, component.radius, component.hardEdges), "Assets/" + filePath + ".asset" );
				AssetDatabase.SaveAssets();
			}

			if (GUI.changed) {
				component.setMesh();
			}
		}
	}
	#endif

	[ExecuteInEditMode]
	public class PoleSphere : MonoBehaviour {

		public int segments = 6;
		public int rings = 3;
		public float radius = 1.0f;
		public bool hardEdges = false;
		MeshFilter mf;
		MeshRenderer mr;

		void Start(){
			mf = gameObject.GetComponent<MeshFilter> ();
			if (mf == null)
				mf = gameObject.AddComponent<MeshFilter> ();
			mr = gameObject.GetComponent<MeshRenderer> ();
			if (mr == null) {
				mr = gameObject.AddComponent<MeshRenderer> ();
				mr.material = new Material(Shader.Find("Standard"));
			}
			if(mf != null)
				mf.sharedMesh = generateMesh(segments, rings, radius, hardEdges);
		}

		public void setMesh(){
			if(mf != null)
				mf.sharedMesh = generateMesh(segments, rings, radius, hardEdges);
		}

		public Mesh generateMesh(int segments = 3, int rings = 1, float radius = 1.0f, bool hardEdges = false){
			Mesh sphere = new Mesh ();
			if (segments < 3) {
				//fail
				Debug.Log ("[PoleSphere] generateMesh(): There need to be at least 3 segments. Your Input was " + segments);
				return sphere;
			}
			if (rings < 1) {
				//fail
				Debug.Log ("[PoleSphere] generateMesh(): There need to be at least 1 ring. Your Input was " + rings);
				return sphere;
			}

			int vertsOnRing = segments + 1;
			int vertsOnSegment = rings + 2;
			Vector3[] vertices = new Vector3[(vertsOnRing) * (vertsOnSegment)];
			Vector2[] uvs = new Vector2[vertices.Length];
			//Debug.Log (vertices.Length);
			int[] triangles = new int[(vertsOnRing - 1) * (vertsOnSegment - 1)*6];
			float deltaPhi = 2*Mathf.PI/segments;
			float deltaTheta = Mathf.PI/(rings + 1);

			////CREATE VERTICES
			//make equator
			Vector3[] equator = new Vector3[vertsOnRing];
			for (int i = 0; i < segments + 1; i++) {
				equator [i].x = Mathf.Cos (deltaPhi * i);
				equator [i].z = Mathf.Sin (deltaPhi * i);
			}
			float latitude, radiusAtLatitude, height;
			int index;
			for (int r = 0; r < vertsOnSegment; r++) {
				latitude = -deltaTheta * r + Mathf.PI / 2;
				radiusAtLatitude = Mathf.Cos (latitude);
				height = Mathf.Sin (latitude);
				//Debug.Log ("height " + height);
				for(int s = 0; s < vertsOnRing; s++){
					index = r * vertsOnRing + s;
					vertices [index].x = equator[s].x*radiusAtLatitude;
					vertices [index].z = equator[s].z*radiusAtLatitude;
					vertices [index].y = height;
				}
			}
			////CREATE UVS
			float deltaU = 1f / segments;
			float deltaV = 1f / (rings + 1);
			for (int r = 0; r < vertsOnSegment; r++) {
				for(int s = 0; s < vertsOnRing; s++){
					index = r * vertsOnRing + s;
					uvs [index].x = s*deltaU;
					uvs [index].y = 1f - r*deltaV;
					//Debug.Log ("(" + uvs [index].x + "," + uvs [index].y + ")");
				}
			}
			for(int s = 0; s < vertsOnRing; s++){
				uvs [s].x += 0.5f * deltaU;
			}
			for(int s = 0; s < vertsOnRing; s++){
				uvs [vertsOnRing*(rings + 1) + s].x += 0.5f * deltaU;
			}
			////CREATE TRIANGLES
			//mantle
			index = 0; 
			for (int r = 1; r < rings; r++) {//ring
				for (int s = 0; s < segments; s++) {//segment
					//Debug.Log("index " + index + " r " + r + " s " + s);
					triangles [index++] = (r + 1) * vertsOnRing + s + 1;
					triangles [index++] = (r + 1) * vertsOnRing + s;
					triangles [index++] = r * vertsOnRing + s;

					triangles [index++] = r * vertsOnRing + s;
					triangles [index++] = r * vertsOnRing + s + 1;
					triangles [index++] = (r + 1) * vertsOnRing + s + 1;

				}
			}//northPole
			for (int s = 0; s < segments; s++) {//segment
				//Debug.Log("index " + index + " s " + s);
				triangles [index++] = vertsOnRing + s + 1;
				triangles [index++] = vertsOnRing + s;
				triangles [index++] = s;
			}
			//southPole
			for (int s = 0; s < segments; s++) {//segment
				//Debug.Log("index " + index + " v " + ((rings + 1) * vertsOnRing + s + 1));
				triangles [index++] = rings * vertsOnRing + s;
				triangles [index++] = rings * vertsOnRing + s + 1;
				triangles [index++] = (rings + 1) * vertsOnRing + s + 1;
			}

			//finish
			Vector3[] normals = null;
			Vector3[] verts = null;
			Vector2[] uv = null;
			if (hardEdges) {
				//disconnect faces from each other
				verts = new Vector3[triangles.Length];
				normals = new Vector3[verts.Length];
				uv = new Vector2[verts.Length];
				for(int i = 0; i < triangles.Length; i++){
					verts[i] = vertices[triangles[i]];
					normals [i] = verts [i];
					verts [i] *= radius;
					uv[i] = uvs [triangles [i]];
					triangles [i] = i;
				}
			} else {
				//normals are smooth as usual
				normals = new Vector3[vertices.Length];
				verts = vertices;
				uv = uvs;
				for(int i = 0; i < normals.Length; i++){
					normals[i] = vertices[i];
					verts[i] *= radius;
				}
			}

			sphere.vertices = verts;
			sphere.normals = normals;
			sphere.triangles = triangles;
			sphere.uv = uv;
			if (hardEdges) {
				sphere.RecalculateNormals();
			}
			return sphere;
		}
	}
}