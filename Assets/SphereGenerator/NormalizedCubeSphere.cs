using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SphereGenerator{
	
	#if UNITY_EDITOR
	using UnityEditor;
	[CustomEditor (typeof (NormalizedCubeSphere))]
	public class NormalizedCubeSphereEditor : Editor{
		NormalizedCubeSphere component;
		string filePath;
		[MenuItem("GameObject/3D Object/SphereGenerator/NormalizedCubeSphere")]
		static void spawnNormalizedCubeSphere(){
			GameObject sphere = new GameObject ();
			sphere.AddComponent<NormalizedCubeSphere> ();
		}

		public void OnEnable(){
			component = (NormalizedCubeSphere)target;
		}

		public override void OnInspectorGUI(){
			GUILayout.Label ("NormalizedCubeSphere Properties", EditorStyles.boldLabel);
			component.UVs = EditorGUILayout.Toggle("UVs", component.UVs);
			component.radius = EditorGUILayout.FloatField("Radius", component.radius);
			int maxSubdivision = 103;
			if (component.UVs)
				maxSubdivision = 102;
			component.subdivision = EditorGUILayout.IntSlider("Subdivisions", component.subdivision, 1, maxSubdivision);
			GUILayout.Label (" ", EditorStyles.miniLabel);
			if (component.UVs) {
				GUILayout.Label ("Estimated vertex count " + (6 * (2 + component.subdivision) * (2 + component.subdivision)), EditorStyles.miniLabel);
				GUILayout.Label ("Estimated triangle count " + ((component.subdivision + 1) * (1 + component.subdivision) * 36), EditorStyles.miniLabel);
			} else {
				GUILayout.Label ("Estimated vertex count " + (4 * (1 + component.subdivision) * (2 + component.subdivision) + 2 * component.subdivision * component.subdivision), EditorStyles.miniLabel);
				GUILayout.Label ("Estimated triangle count " + ((component.subdivision + 1) * (1 + component.subdivision) * 6 * 2 * 3), EditorStyles.miniLabel);
			}
			GUILayout.Label (" ", EditorStyles.miniLabel);

			GUILayout.Label ("Save mesh in assets folder", EditorStyles.boldLabel);
			filePath = EditorGUILayout.TextField("filePath", filePath);
			if (GUILayout.Button ("Save Mesh")) {
				if(component.UVs) AssetDatabase.CreateAsset( component.generateMesh(component.subdivision, component.radius), "Assets/" + filePath + ".asset" );
				else AssetDatabase.CreateAsset( component.generateUVMesh(component.subdivision, component.radius), "Assets/" + filePath + ".asset" );
				AssetDatabase.SaveAssets();
			}
			
			if (GUI.changed) {
				component.setMesh();
			}
		}
	}
	#endif

	[ExecuteInEditMode]
	public partial class NormalizedCubeSphere : MonoBehaviour{

		public int subdivision = 6;
		public float radius = 1.0f;
		public bool UVs = false;
		MeshFilter mf;
		MeshRenderer mr;

		public void setMesh(){
			if (mf != null) {
				if(UVs)	mf.sharedMesh = generateMesh(subdivision, radius);
				else mf.sharedMesh = generateUVMesh(subdivision, radius);
			}
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
			if(mf != null)
				mf.sharedMesh = generateMesh(subdivision, radius);
		}

		public Mesh generateUVMesh(int subdivision = 1, float radius = 1.0f){
			Mesh sphere = new Mesh ();
			if (subdivision < 1) {
				//fail
				Debug.Log("[NormalizedCubeSphere] generateMesh(): Subdivision has to be at least 1");
				return sphere;
			}

			///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			//              CUBE               ////////////////////////////////////////////////////////////////////////////////////
			///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

			int sideVertices = 4*(1 + subdivision)*(2 + subdivision);
			int lidVertices = subdivision*subdivision;
			int vertexCount = sideVertices + 2*lidVertices;
			int triangleIndexCount = (subdivision + 1) * (1 + subdivision)*6*2*3;
			Vector3[] vertices = new Vector3[vertexCount];
			int[] triangles = new int[triangleIndexCount]; 

			int currentIndex = 0;
			//create verts
			float tileWidth = 1.0f / (subdivision + 1);
			//Debug.Log(tileWidth);

			//sides
			//into first row around cube
			Vector3 start = new Vector3(0.5f, 0.5f, 0.5f);
			Vector3 direction = new Vector3(-1.0f, 0.0f, 0.0f);
			for(int i = 0; i < 1 + subdivision; i++){ //each collumn till (subdivision + corner)
				vertices[currentIndex] = start + direction*tileWidth*i;
				currentIndex++;
			}
			start = new Vector3(-0.5f, 0.5f, 0.5f);
			direction = new Vector3(0.0f, 0.0f, -1.0f);
			for(int i = 0; i < 1 + subdivision; i++){ //each collumn till (subdivision + corner)
				vertices[currentIndex] = start + direction*tileWidth*i;
				currentIndex++;
			}
			start = new Vector3(-0.5f, 0.5f, -0.5f);
			direction = new Vector3(1.0f, 0.0f, 0.0f);
			for(int i = 0; i < 1 + subdivision; i++){ //each collumn till (subdivision + corner)
				vertices[currentIndex] = start + direction*tileWidth*i;
				currentIndex++;
			}
			start = new Vector3(0.5f, 0.5f, -0.5f);
			direction = new Vector3(0.0f, 0.0f, 1.0f);
			for(int i = 0; i < 1 + subdivision; i++){ //each collumn till (subdivision + corner)
				vertices[currentIndex] = start + direction*tileWidth*i;
				currentIndex++;
			}
			// copy downward
			int vertexCountLoop = 4*(1 + subdivision);
			//Debug.Log (vertexCountLoop);
			direction = new Vector3(0.0f, -1.0f, 0.0f);
			for(int i = 1; i < 2 + subdivision; i++){ //each collumn till (subdivision + corner)
				for(int j = 0; j < vertexCountLoop; j++){ //each collumn till (subdivision + corner)
					vertices[currentIndex] = vertices[j] + direction*tileWidth*i;
					currentIndex++;
				}
			}

			//upper plane 
			for(int i = 0; i < subdivision; i++){
				for(int j = 0; j < subdivision; j++){
					vertices[currentIndex++] = new Vector3(0.5f - tileWidth, 0.5f, 0.5f - tileWidth) + Vector3.back*tileWidth*j + Vector3.left*tileWidth*i;
				}
			}
			//lower plane 
			for(int i = 0; i < subdivision; i++){
				for(int j = 0; j < subdivision; j++){
					vertices[currentIndex++] = new Vector3(0.5f - tileWidth, -0.5f, 0.5f - tileWidth) + Vector3.back*tileWidth*j + Vector3.left*tileWidth*i;
				}
			}

			//create triangles on the sides
			currentIndex = 0; //reset index
			for(int j = 0; j < 1 + subdivision; j++){
				for(int i = 0; i < vertexCountLoop - 1; i++){
					//first triangle
					triangles[currentIndex++] = vertexCountLoop*(1 + j) + i + 1;
					triangles[currentIndex++] = vertexCountLoop*(1 + j) + i;
					triangles[currentIndex++] = vertexCountLoop*j + i; 
					//Debug.Log ("(" + (vertexCountLoop*(1 + j) + i) + ',' + (vertexCountLoop*(1 + j) + i) + ',' + (vertexCountLoop*j + i) + ')');
					//second triangle
					triangles[currentIndex++] = vertexCountLoop*j + i;
					triangles[currentIndex++] = vertexCountLoop*j + i + 1;
					triangles[currentIndex++] = vertexCountLoop*(1 + j) + i + 1; 
					//Debug.Log ("(" + (vertexCountLoop*j + i) + ',' + (vertexCountLoop*j + i + 1) + ',' + (vertexCountLoop*(1 + j) + i + 1) + ')');
				}
				//last upper triangle
				triangles[currentIndex++] = vertexCountLoop*(j + 1) - 1;
				triangles[currentIndex++] = vertexCountLoop*j;
				triangles[currentIndex++] = vertexCountLoop*(j + 1); 
				//Debug.Log ("(" + (vertexCountLoop*(j + 1) - 1) + ',' + (vertexCountLoop*j) + ',' + (vertexCountLoop*(j + 2)) + ')');
				//last upper triangle
				triangles[currentIndex++] = vertexCountLoop*(j + 1) - 1;
				triangles[currentIndex++] = vertexCountLoop*(j + 1);
				triangles[currentIndex++] = vertexCountLoop*(j + 2) - 1; 
				//Debug.Log ("(" + (vertexCountLoop*(j + 1) - 1) + ',' + (vertexCountLoop*(j + 1)) + ',' + (vertexCountLoop*(j + 2) - 1) + ')');
			}

			int lowerPlaneStartIndex = sideVertices - 4*(1 + subdivision);
			//quads at edges
			//upper
			for(int i = 0; i < subdivision - 1; i++){
				triangles[currentIndex++] = sideVertices + i*subdivision;
				triangles[currentIndex++] = sideVertices + (i + 1)*subdivision; 
				triangles[currentIndex++] = i + 1;
				triangles[currentIndex++] = i + 1;
				triangles[currentIndex++] = sideVertices + (i + 1)*subdivision;
				triangles[currentIndex++] = i + 2;
			}
			for(int i = 0; i < subdivision - 1; i++){
				triangles[currentIndex++] = sideVertices + subdivision*(subdivision - 1) + i;
				triangles[currentIndex++] = sideVertices + subdivision*(subdivision - 1) + i + 1; 
				triangles[currentIndex++] = subdivision + 1 + i + 1;
				triangles[currentIndex++] = subdivision + 1 + i + 1;
				triangles[currentIndex++] = sideVertices + subdivision*(subdivision - 1) + i + 1; 
				triangles[currentIndex++] = subdivision + 2 + i + 1;
			}
			for(int i = 0; i < subdivision - 1; i++){
				triangles[currentIndex++] = sideVertices + subdivision*(subdivision - i) - 1;
				triangles[currentIndex++] = sideVertices + subdivision*(subdivision - i - 1) - 1; 
				triangles[currentIndex++] = 2*(subdivision + 1) + i + 1;
				triangles[currentIndex++] = 2*(subdivision + 1) + i + 1;
				triangles[currentIndex++] = sideVertices + subdivision*(subdivision - i - 1) - 1;
				triangles[currentIndex++] = 2*(subdivision + 1) + i + 2;
			}
			for(int i = 0; i < subdivision - 1; i++){
				triangles[currentIndex++] = sideVertices + subdivision - i - 1;
				triangles[currentIndex++] = sideVertices + subdivision - i - 1 - 1; 
				triangles[currentIndex++] = 3*(subdivision + 1) + i + 1;
				triangles[currentIndex++] = 3*(subdivision + 1) + i + 1;
				triangles[currentIndex++] = sideVertices + subdivision - i - 1 - 1;
				triangles[currentIndex++] = 3*(subdivision + 1) + i + 2;
			}
			//lower
			for(int i = 0; i < subdivision - 1; i++){
				triangles[currentIndex++] = lowerPlaneStartIndex + i + 1;
				triangles[currentIndex++] = lidVertices + sideVertices + (i + 1)*subdivision; 
				triangles[currentIndex++] = lidVertices + sideVertices + i*subdivision;
				triangles[currentIndex++] = lowerPlaneStartIndex + i + 2;
				triangles[currentIndex++] = lidVertices + sideVertices + (i + 1)*subdivision;
				triangles[currentIndex++] = lowerPlaneStartIndex + i + 1;
			}
			for(int i = 0; i < subdivision - 1; i++){
				triangles[currentIndex++] = lowerPlaneStartIndex + subdivision + 1 + i + 1;
				triangles[currentIndex++] = lidVertices + sideVertices + subdivision*(subdivision - 1) + i + 1; 
				triangles[currentIndex++] = lidVertices + sideVertices + subdivision*(subdivision - 1) + i;
				triangles[currentIndex++] = lowerPlaneStartIndex + subdivision + 2 + i + 1;
				triangles[currentIndex++] = lidVertices + sideVertices + subdivision*(subdivision - 1) + i + 1; 
				triangles[currentIndex++] = lowerPlaneStartIndex + subdivision + 1 + i + 1;
			}
			for(int i = 0; i < subdivision - 1; i++){
				triangles[currentIndex++] = lowerPlaneStartIndex + 2*(subdivision + 1) + i + 1;
				triangles[currentIndex++] = lidVertices + sideVertices + subdivision*(subdivision - i - 1) - 1; 
				triangles[currentIndex++] = lidVertices + sideVertices + subdivision*(subdivision - i) - 1;
				triangles[currentIndex++] = lowerPlaneStartIndex + 2*(subdivision + 1) + i + 2;
				triangles[currentIndex++] = lidVertices + sideVertices + subdivision*(subdivision - i - 1) - 1;
				triangles[currentIndex++] = lowerPlaneStartIndex + 2*(subdivision + 1) + i + 1;
			}
			for(int i = 0; i < subdivision - 1; i++){
				triangles[currentIndex++] = lowerPlaneStartIndex + 3*(subdivision + 1) + i + 1;
				triangles[currentIndex++] = lidVertices + sideVertices + subdivision - i - 1 - 1; 
				triangles[currentIndex++] = lidVertices + sideVertices + subdivision - i - 1;
				triangles[currentIndex++] = lowerPlaneStartIndex + 3*(subdivision + 1) + i + 2;
				triangles[currentIndex++] = lidVertices + sideVertices + subdivision - i - 1 - 1;
				triangles[currentIndex++] = lowerPlaneStartIndex + 3*(subdivision + 1) + i + 1;
			}

			//quads at corners
			//upper
			triangles[currentIndex++] = sideVertices;
			triangles[currentIndex++] = 1; 
			triangles[currentIndex++] = 0;
			triangles[currentIndex++] = 0;
			triangles[currentIndex++] = 4*(subdivision + 1) - 1;
			triangles[currentIndex++] = sideVertices; 

			triangles[currentIndex++] = sideVertices + subdivision*(subdivision - 1);
			triangles[currentIndex++] = 1*(subdivision + 1) + 1; 
			triangles[currentIndex++] = 1*(subdivision + 1);
			triangles[currentIndex++] = 1*(subdivision + 1);
			triangles[currentIndex++] = 1*(subdivision + 1) - 1;
			triangles[currentIndex++] = sideVertices + subdivision*(subdivision - 1); 

			triangles[currentIndex++] = sideVertices + subdivision*(subdivision - 0) - 1;
			triangles[currentIndex++] = 2*(subdivision + 1) + 1; 
			triangles[currentIndex++] = 2*(subdivision + 1);
			triangles[currentIndex++] = 2*(subdivision + 1);
			triangles[currentIndex++] = 2*(subdivision + 1) - 1;
			triangles[currentIndex++] = sideVertices + subdivision*(subdivision - 0) - 1; 

			triangles[currentIndex++] = sideVertices + subdivision - 1;
			triangles[currentIndex++] = 3*(subdivision + 1) + 1; 
			triangles[currentIndex++] = 3*(subdivision + 1);
			triangles[currentIndex++] = 3*(subdivision + 1);
			triangles[currentIndex++] = 3*(subdivision + 1) - 1;
			triangles[currentIndex++] = sideVertices + subdivision - 1; 

			//lower
			triangles[currentIndex++] = lowerPlaneStartIndex + 0;
			triangles[currentIndex++] = lowerPlaneStartIndex + 1; 
			triangles[currentIndex++] = lidVertices + sideVertices;
			triangles[currentIndex++] = lidVertices + sideVertices; 
			triangles[currentIndex++] = lowerPlaneStartIndex + 4*(subdivision + 1) - 1;
			triangles[currentIndex++] = lowerPlaneStartIndex + 0;

			triangles[currentIndex++] = lowerPlaneStartIndex + 1*(subdivision + 1);
			triangles[currentIndex++] = lowerPlaneStartIndex + 1*(subdivision + 1) + 1; 
			triangles[currentIndex++] = lidVertices + sideVertices + subdivision*(subdivision - 1);
			triangles[currentIndex++] = lidVertices + sideVertices + subdivision*(subdivision - 1); 
			triangles[currentIndex++] = lowerPlaneStartIndex + 1*(subdivision + 1) - 1;
			triangles[currentIndex++] = lowerPlaneStartIndex + 1*(subdivision + 1);

			triangles[currentIndex++] = lowerPlaneStartIndex + 2*(subdivision + 1);
			triangles[currentIndex++] = lowerPlaneStartIndex + 2*(subdivision + 1) + 1; 
			triangles[currentIndex++] = lidVertices + sideVertices + subdivision*(subdivision - 0) - 1;
			triangles[currentIndex++] = lidVertices + sideVertices + subdivision*(subdivision - 0) - 1; 
			triangles[currentIndex++] = lowerPlaneStartIndex + 2*(subdivision + 1) - 1;
			triangles[currentIndex++] = lowerPlaneStartIndex + 2*(subdivision + 1);

			triangles[currentIndex++] = lowerPlaneStartIndex + 3*(subdivision + 1);
			triangles[currentIndex++] = lowerPlaneStartIndex + 3*(subdivision + 1) + 1; 
			triangles[currentIndex++] = lidVertices + sideVertices + subdivision - 1;
			triangles[currentIndex++] = lidVertices + sideVertices + subdivision - 1; 
			triangles[currentIndex++] = lowerPlaneStartIndex + 3*(subdivision + 1) - 1;
			triangles[currentIndex++] = lowerPlaneStartIndex + 3*(subdivision + 1);

			//lids
			//upper
			for(int i = 0; i < subdivision - 1; i++){
				for (int j = 0; j < subdivision - 1; j++) {
					triangles [currentIndex++] = sideVertices + j + i*subdivision;
					triangles [currentIndex++] = sideVertices + j + i*subdivision + 1; 
					triangles [currentIndex++] = sideVertices + j + 1 + (i + 1)*subdivision;
					triangles [currentIndex++] = sideVertices + j + i*subdivision; 
					triangles [currentIndex++] = sideVertices + j + 1 + (i + 1)*subdivision;
					triangles [currentIndex++] = sideVertices + j + (i + 1)*subdivision;
				}
			}
			//lower
			for(int i = 0; i < subdivision - 1; i++){
				for (int j = 0; j < subdivision - 1; j++) {
					triangles [currentIndex++] = sideVertices + lidVertices + j + 1 + (i + 1)*subdivision;
					triangles [currentIndex++] = sideVertices + lidVertices + j + i*subdivision + 1; 
					triangles [currentIndex++] = sideVertices + lidVertices + j + i*subdivision;
					triangles [currentIndex++] = sideVertices + lidVertices + j + (i + 1)*subdivision;
					triangles [currentIndex++] = sideVertices + lidVertices + j + 1 + (i + 1)*subdivision;
					triangles [currentIndex++] = sideVertices + lidVertices + j + i*subdivision; 
				}
			}

			///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			//              SPHERE             ////////////////////////////////////////////////////////////////////////////////////
			///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			Vector3[] normals = new Vector3[vertexCount];
			for(int i = 0; i < vertexCount; i++){
				normals[i] = vertices[i].normalized;
				vertices[i] = normals[i] * radius;
			}

			sphere.vertices = vertices;
			sphere.normals = normals;
			sphere.triangles = triangles;

			return sphere;
		}
	}

}