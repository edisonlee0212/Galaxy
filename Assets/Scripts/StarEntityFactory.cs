using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    [CreateAssetMenu]
    public class StarEntityFactory : ScriptableObject
    {
        [SerializeField]
        Mesh[] m_StarMeshes;
        [SerializeField]
        Material[] m_Materials;
        [SerializeField]
        Color[] m_Colors;
        public void Start()
        {

        }

    }
}
