using UnityEngine;
using System.Collections;
namespace PlanetGen
{
    public class Rotate : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.up * Time.deltaTime);
        }
    }
}
