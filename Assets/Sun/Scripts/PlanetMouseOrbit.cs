using UnityEngine;
using System;

[AddComponentMenu("Camera-Control/Mouse Orbit")]

public class PlanetMouseOrbit:MonoBehaviour{
    public Transform target;
    public float distance = 10.0f;
    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;
    public int yMinLimit = -20;
    public int yMaxLimit = 80;
    public int zoomRate = 25;
    
    float x = 0.0f;
    float y = 0.0f;
    
    public void Start() {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }
    	
    public void Update() {
    	if (target != null) {
    	
          
    		
    		x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
          
            distance += -(Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * zoomRate * Mathf.Abs(distance);
          
           		
     		y = ClampAngle(y, (float)yMinLimit, (float)yMaxLimit);
     		       
            Quaternion rotation = Quaternion.Euler(y, x, 0.0f);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;
            
            transform.rotation = rotation;
            transform.position = position;
             
        }
    	
    
    }
    
    public static float ClampAngle(float angle,float min,float max) {
    	if (angle < -360)
    		angle += 360.0f;
    	if (angle > 360)
    		angle -= 360.0f;
    	return Mathf.Clamp (angle, min, max);
    }
}