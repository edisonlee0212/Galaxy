using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SphereGenerator{
	
	#if UNITY_EDITOR
	using UnityEditor;
	[CustomEditor (typeof (SubdividedCubeSphere))]
	public class SubdividedCubeSphereEditor : Editor{
		SubdividedCubeSphere component;
		string filePath;

		[MenuItem("GameObject/3D Object/SphereGenerator/SubdividedCubeSphere")]
		static void spawnSubdividedCubeSphere(){
			GameObject sphere = new GameObject ();
			sphere.AddComponent<SubdividedCubeSphere> ();
		}

		public void OnEnable(){
			component = (SubdividedCubeSphere)target;
		}

		public override void OnInspectorGUI(){
			GUILayout.Label ("SubdividedCubeSphere Properties", EditorStyles.boldLabel);
			component.radius = EditorGUILayout.FloatField("Radius", component.radius);
			component.padding = EditorGUILayout.FloatField("UV Padding", component.padding);
			int maxSubdivision = 6;
			component.subdivision = EditorGUILayout.IntSlider("Subdivisions", component.subdivision, 0, maxSubdivision);
			GUILayout.Label (" ", EditorStyles.miniLabel);
			int vertCountOnRow = component.getEstimatedVertexCountOnRow (component.subdivision);
			GUILayout.Label ("Estimated vertex count " + vertCountOnRow * vertCountOnRow * 6, EditorStyles.miniLabel);
			GUILayout.Label ("Estimated triangle count " + (vertCountOnRow - 1) * (vertCountOnRow - 1) * 2 * 6, EditorStyles.miniLabel);
			GUILayout.Label (" ", EditorStyles.miniLabel);

			GUILayout.Label ("Save mesh in assets folder", EditorStyles.boldLabel);
			filePath = EditorGUILayout.TextField("filePath", filePath);
			if (GUILayout.Button ("Save Mesh")) {
				AssetDatabase.CreateAsset( component.generateMesh(component.subdivision, component.radius, component.padding), "Assets/" + filePath + ".asset" );
				AssetDatabase.SaveAssets();
			}

			if (GUI.changed) {
				component.setMesh();
			}
		}
	}
	#endif

	[ExecuteInEditMode]
	public class SubdividedCubeSphere : MonoBehaviour {
		public int subdivision = 2;
		public float radius = 1.0f;
		public float padding = 0.01f;
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
				mf.sharedMesh = generateMesh(subdivision, radius, padding);
		}

		public void setMesh(){
			if (mf != null) {
				mf.sharedMesh = generateMesh(subdivision, radius, padding);
			}
		}

		int pow(int i, int pow){
			int result = 1;
			for (int s = 0; s < pow; s++) {
				result *= i;
			}return result;
		}

		public int getEstimatedVertexCountOnRow (int subdivision = 0){
			return pow(2, subdivision) + 1;
		}

		public Mesh generateMesh(int subdivision = 0, float radius = 1.0f, float padding = 0.0f){
			if (subdivision < 0) {
				//fail
				Debug.Log("[SubdividedCubeSphere] generateMesh(): Subdivision has to be at least 0");
				return new Mesh();
			}
			//Debug.Log ("+------------");
			int n_vr = getEstimatedVertexCountOnRow(subdivision); //the number of vertices on the row at the final subdivision level
			int quadVertexCount = n_vr * n_vr;
			Vector3[] vertices = new Vector3[quadVertexCount * 6]; //*6 for 6 faces
			Vector2[] uvs = new Vector2[quadVertexCount * 6]; //*6 for 6 faces
			int[] indices = new int[(n_vr - 1) * (n_vr - 1) * 2 * 3 * 6]; //*2 triangles per quad *3 indices per triangle * 6 faces

			//#####################################################################################################
			//TRIANGLES

			int index = 0;
			for(int f = 0; f < 6; f++){ //face
				for(int r = 0; r < n_vr - 1; r++){ //row
					for(int c = 0; c < n_vr - 1; c++){ //collumn
						indices [index++] = f * quadVertexCount + (r + 1) * n_vr + c;
						indices [index++] = f * quadVertexCount + r * n_vr + c;
						indices [index++] = f * quadVertexCount + r * n_vr + c + 1;

						indices [index++] = f * quadVertexCount + (r + 1) * n_vr + c;
						indices [index++] = f * quadVertexCount + r * n_vr + c + 1;
						indices [index++] = f * quadVertexCount + (r + 1) * n_vr + c + 1;
					}
				}
			}

			//#####################################################################################################
			//VERTEX POSITIONS

			//base vertices
			vertices [0] = new Vector3(0.5f, 0.5f, 0.5f).normalized * radius;
			vertices [n_vr - 1] = new Vector3(-0.5f, 0.5f, 0.5f).normalized * radius;
			vertices [n_vr * (n_vr - 1)] = new Vector3(0.5f, -0.5f, 0.5f).normalized * radius;
			vertices [n_vr * n_vr - 1] = new Vector3(-0.5f, -0.5f, 0.5f).normalized * radius;

			for (int s = 1; s < subdivision + 1; s++) {
				int collumnOffset = pow (2, subdivision - s); //specifies the offset to the next interesting vertex at current subdivision
				int n_vrs = getEstimatedVertexCountOnRow (s); //number of vertices in focus in current subdivision
				int rowOffset = n_vr * collumnOffset; //specifies the offset to the next interesting vertex on the next row at current subdivision
				//Debug.Log ("subdivision " + s + "; n_vrs " + n_vrs + "; rowOffset " + rowOffset + "; collumnOffset " + collumnOffset);
				int numRCToModify = n_vrs / 2 + 1; //the number of rows and collumns to be modified (this is used to reduce the number or normilisations to make)
				for (int r = 0; r < numRCToModify; r++) {
					for (int c = 0; c < numRCToModify; c++) {
						index = r * rowOffset + c * collumnOffset;
						if (r % 2 == 0) { //row even
							if (c % 2 == 1) { //collumn not even
								vertices [index] = ((vertices [index - collumnOffset] + vertices [index + collumnOffset]) / 2.0f).normalized * radius;
								//Debug.Log ("re ce  (" + c + ";" + r + ")-( " + (index - collumnOffset) + " ; " + (index + collumnOffset) + " )");
							}
						} else {//row not even
							if (c % 2 == 0) { //collumn even
								vertices [index] = ((vertices [index - rowOffset] + vertices [index + rowOffset]) / 2.0f).normalized * radius;
								//Debug.Log ("rne ce  (" + c + ";" + r + ")-( " + (index - rowOffset) + " ; " + (index + rowOffset) + " )");
							} else { //collumn not even
								vertices [index] = ((vertices [index - rowOffset - collumnOffset] + vertices [index + rowOffset + collumnOffset]) / 2.0f).normalized * radius;
								//Debug.Log ("rne cne  (" + c + ";" + r + ")-( " + (index - rowOffset - collumnOffset) + " ; " + (index + rowOffset + collumnOffset) + " )");
							}
						}
					}
				}
			}

			//rotate section to make one face (not via sin, cos)
			int n_vrc = n_vr / 2; //the number of rows and collumns on one section
			for(int r = 0; r < n_vrc + 1; r++){
				for(int c = 0; c < n_vrc; c++){
					vertices [(r + 1) * n_vr - 1 - c] = vertices [r * n_vr + c];
					vertices [(r + 1) * n_vr - 1 - c].x *= -1;
				}
			}
			for(int r = 0; r < n_vrc; r++){
				for(int c = 0; c < n_vr; c++){
					vertices [n_vr * (n_vr - 1) - r * n_vr + c] = vertices [r * n_vr + c];
					vertices [n_vr * (n_vr - 1) - r * n_vr + c].y *= -1;
					//Debug.Log ((r + 1) * n_vr - 1 - c);
				}
			}

			//rotate face to set other vertex transforms
			int offset = quadVertexCount;
			//top
			Matrix4x4 m = Matrix4x4.Rotate(Quaternion.Euler(-90, 0, 0)); 
			for(int i = 0; i < quadVertexCount; i++) {
				vertices[i + offset] = m.MultiplyPoint3x4(vertices[i]);
			}offset += quadVertexCount;
			//right
			m = Matrix4x4.Rotate(Quaternion.Euler(0, -90, 0));
			for(int i = 0; i < quadVertexCount; i++) {
				vertices[i + offset] = m.MultiplyPoint3x4(vertices[i]);
			}offset += quadVertexCount;
			//back
			m = Matrix4x4.Rotate(Quaternion.Euler(0, -180, 0));
			for(int i = 0; i < quadVertexCount; i++) {
				vertices[i + offset] = m.MultiplyPoint3x4(vertices[i]);
			}offset += quadVertexCount;
			//left
			m = Matrix4x4.Rotate(Quaternion.Euler(0, 90, 0));
			for(int i = 0; i < quadVertexCount; i++) {
				vertices[i + offset] = m.MultiplyPoint3x4(vertices[i]);
			}offset += quadVertexCount;
			//bottom
			m = Matrix4x4.Rotate(Quaternion.Euler(90, 0, 0));
			for(int i = 0; i < quadVertexCount; i++) {
				vertices[i + offset] = m.MultiplyPoint3x4(vertices[i]);
			}offset += quadVertexCount;

			//#####################################################################################################
			//uvs
			Vector2 uvFaceWidth = new Vector2((1.0f - padding * 6) / 3.0f, (1.0f - padding*4) / 2.0f);
			Vector2 uvDelta = new Vector2(uvFaceWidth.x / (n_vr - 1), uvFaceWidth.y /(n_vr - 1));
			Vector2 uvOffset = new Vector2 ();
			//front
			uvOffset.x = padding; uvOffset.y = uvFaceWidth.y + padding;
			for(int r = 0; r < n_vr; r++){
				for(int c = 0; c < n_vr; c++){
					uvs [r * n_vr + c] = new Vector2 (uvOffset.x + c * uvDelta.x, uvOffset.y - r * uvDelta.y);
				}
			}offset = quadVertexCount;
			//top
			uvOffset.x = padding; uvOffset.y = uvFaceWidth.y * 2 + padding * 3;
			for(int r = 0; r < n_vr; r++){
				for(int c = 0; c < n_vr; c++){
					uvs [offset + r * n_vr + c] = new Vector2 (uvOffset.x + c * uvDelta.x, uvOffset.y - r * uvDelta.y);
				}
			}offset += quadVertexCount;
			//right
			uvOffset.x = uvFaceWidth.x + padding * 3; uvOffset.y = uvFaceWidth.y + padding;
			for(int r = 0; r < n_vr; r++){
				for(int c = 0; c < n_vr; c++){
					uvs [offset + r * n_vr + c] = new Vector2 (uvOffset.x + c * uvDelta.x, uvOffset.y - r * uvDelta.y);
				}
			}offset += quadVertexCount;
			//back
			uvOffset.x = uvFaceWidth.x + padding * 3; uvOffset.y = uvFaceWidth.y * 2 + padding * 3;
			for(int r = 0; r < n_vr; r++){
				for(int c = 0; c < n_vr; c++){
					uvs [offset + r * n_vr + c] = new Vector2 (uvOffset.x + c * uvDelta.x, uvOffset.y - r * uvDelta.y);
				}
			}offset += quadVertexCount;
			//left
			uvOffset.x = 2*uvFaceWidth.x + padding * 5; uvOffset.y = uvFaceWidth.y + padding;
			for(int r = 0; r < n_vr; r++){
				for(int c = 0; c < n_vr; c++){
					uvs [offset + r * n_vr + c] = new Vector2 (uvOffset.x + c * uvDelta.x, uvOffset.y - r * uvDelta.y);
				}
			}offset += quadVertexCount;
			//bottom
			uvOffset.x = 2*uvFaceWidth.x + padding * 5; uvOffset.y = uvFaceWidth.y * 2 + padding * 3;
			for(int r = 0; r < n_vr; r++){
				for(int c = 0; c < n_vr; c++){
					uvs [offset + r * n_vr + c] = new Vector2 (uvOffset.x + c * uvDelta.x, uvOffset.y - r * uvDelta.y);
				}
			}offset += quadVertexCount;

			//#####################################################################################################
			//create mesh
			Mesh sphere = new Mesh();
			Vector3[] normals = vertices;
			sphere.vertices = vertices;
			sphere.normals = normals;
			sphere.uv = uvs;
			sphere.triangles = indices;

			return sphere;
		}
	}

}