using UnityEngine;

using System.Collections;


namespace PlanetGen
{
    public class MouseOrbitImproved : MonoBehaviour
    {


        public Transform target;
        public float distance = 3f;
        //    public int cameraSpeed= 5 ;

        public float xSpeed = 175.0f;
        public float ySpeed = 75.0f;

        private float lastDist = 0;
        //    private float curDist = 0;

        public int yMinLimit = 10; //Lowest vertical angle in respect with the target.
        public int yMaxLimit = 10;

        private float x = 0.0f;
        private float y = 0.0f;

        private float X = 0f;
        private float Y = 0f;

        private Camera cam;
        void Start()
        {
            cam = Camera.main;

            Vector3 angles = transform.eulerAngles;
            x = angles.y;
            y = angles.x;



            // Make the rigid body not change rotation

            if (GetComponent<Rigidbody>())
                GetComponent<Rigidbody>().freezeRotation = true;

        }



        void Update()
        {
            distance -= Input.GetAxis("Mouse ScrollWheel") * 0.5f;
            distance = Mathf.Clamp(distance, 0.9f, 10);
            {



                //Detect mouse drag;

                if (Input.GetMouseButton(1))
                {

                    x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                    y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                }
                y = ClampAngle(y, yMinLimit, yMaxLimit);

                Quaternion rotation = Quaternion.Euler(y, x, 0);
                Vector3 vTemp = new Vector3(0.0f, 0.0f, -distance);
                Vector3 position = rotation * vTemp + target.position;


                transform.position = Vector3.Lerp(transform.position, position, xSpeed * Time.deltaTime + 2);
                transform.rotation = rotation;




            }


        }



        static float ClampAngle(float angle, float min, float max)
        {

            if (angle < -360)
                angle += 360;

            if (angle > 360)
                angle -= 360;

            return Mathf.Clamp(angle, min, max);

        }



    }
}