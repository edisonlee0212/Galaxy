using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SphereGenerator{
		
	public partial class NormalizedCubeSphere : MonoBehaviour {
		public Mesh generateMesh(int subdivision = 1, float radius = 1.0f){
			Mesh sphere = new Mesh ();
			if (subdivision < 1) {
				//fail
				Debug.Log("[UVNormalizedCubeSphere] generateMesh(): Subdivision has to be at least 1");
				return sphere;
			}
			///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			//              CUBE               ////////////////////////////////////////////////////////////////////////////////////
			///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			int verticesOnRow = 2 + subdivision;
			int verticesOnFace = intPow (verticesOnRow, 2);
			int vertexCount = verticesOnFace*6;
			Vector3[] vertices = new Vector3[vertexCount];
			Vector2[] uvs = new Vector2[vertexCount];
			int[] triangles = new int[intPow(1 + subdivision, 2)*36];
			float delta = 1f / (subdivision + 1); //distance between two verteices on same collumn/row
			Vector3 down, right, origin; //the vectors indicating the direction/position the next vertex is going to be at
			int currentFace;

			////CREATE VERTICES
			//front
			currentFace = 0;
			down = new Vector3(0f, -delta, 0f); 
			right = new Vector3(delta, 0f, 0f); 
			origin = new Vector3 (-0.5f, 0.5f, 0.5f);
			for (int r = 0; r < verticesOnRow; r++) {//row
				for (int c = 0; c < verticesOnRow; c++) {//collumn
					vertices[currentFace*verticesOnFace + r*verticesOnRow + c] = origin + right*c + down*r;
				}
			}
			//back
			currentFace = 1;
			down = new Vector3(0f, delta, 0f); 
			right = new Vector3(delta, 0f, 0f); 
			origin = new Vector3 (-0.5f, -0.5f, -0.5f);
			for (int r = 0; r < verticesOnRow; r++) {//row
				for (int c = 0; c < verticesOnRow; c++) {//collumn
					vertices[currentFace*verticesOnFace + r*verticesOnRow + c] = origin + right*c + down*r;
				}
			}
			//top
			currentFace = 2;
			down = new Vector3(0f, 0f, delta); 
			right = new Vector3(delta, 0f, 0f); 
			origin = new Vector3 (-0.5f, 0.5f, -0.5f);
			for (int r = 0; r < verticesOnRow; r++) {//row
				for (int c = 0; c < verticesOnRow; c++) {//collumn
					vertices[currentFace*verticesOnFace + r*verticesOnRow + c] = origin + right*c + down*r;
				}
			}
			//bottom
			currentFace = 3;
			down = new Vector3(0f, 0f, -delta); 
			right = new Vector3(delta, 0f, 0f); 
			origin = new Vector3 (-0.5f, -0.5f, 0.5f);
			for (int r = 0; r < verticesOnRow; r++) {//row
				for (int c = 0; c < verticesOnRow; c++) {//collumn
					vertices[currentFace*verticesOnFace + r*verticesOnRow + c] = origin + right*c + down*r;
				}
			}
			//right
			currentFace = 4;
			down = new Vector3(0f, -delta, 0f); 
			right = new Vector3(0f, 0f, -delta); 
			origin = new Vector3 (0.5f, 0.5f, 0.5f);
			for (int r = 0; r < verticesOnRow; r++) {//row
				for (int c = 0; c < verticesOnRow; c++) {//collumn
					vertices[currentFace*verticesOnFace + r*verticesOnRow + c] = origin + right*c + down*r;
				}
			}
			//left
			currentFace = 5;
			down = new Vector3(0f, -delta, 0f); 
			right = new Vector3(0f, 0f, delta); 
			origin = new Vector3 (-0.5f, 0.5f, -0.5f);
			for (int r = 0; r < verticesOnRow; r++) {//row
				for (int c = 0; c < verticesOnRow; c++) {//collumn
					vertices[currentFace*verticesOnFace + r*verticesOnRow + c] = origin + right*c + down*r;
				}
			}

			////CREATE UVS
			for (int r = 0; r < verticesOnRow; r++) {//row
				for (int c = 0; c < verticesOnRow; c++) {//collumn
					uvs[r*verticesOnRow + c] = new Vector2(0 + delta*c, 1f - delta*r);
				}
			}
			for (int i = 1; i < 6; i++) {
				for (int v = 0; v < verticesOnFace; v++) {
					uvs [i * verticesOnFace + v] = uvs [v];
				}
			}

			////CREATE TRIANGLES
			int index = 0;
			for (int f = 0; f < 6; f++) {//current Face
				int triangleOffset = f*verticesOnFace;
				for (int r = 0; r < verticesOnRow - 1; r++) {//row
					for (int c = 0; c < verticesOnRow - 1; c++) {//collumn
						//Debug.Log("index " + index + " f " +f + " r " + r + " c " + c);
						triangles [index++] = triangleOffset + r * verticesOnRow + c;
						triangles [index++] = triangleOffset + (r + 1) * verticesOnRow + c;
						triangles [index++] = triangleOffset + (r + 1) * verticesOnRow + c + 1;

						triangles [index++] = triangleOffset + (r + 1) * verticesOnRow + c + 1;
						triangles [index++] = triangleOffset + r * verticesOnRow + c + 1;
						triangles [index++] = triangleOffset + r * verticesOnRow + c;
					}
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
			sphere.uv = uvs;

			return sphere;
		}

		int intPow(int i, int p){
			int result = i;
			for(int t = 1; t < p; t++){
				result *= i;
			}
			return result;
		}
	}
}