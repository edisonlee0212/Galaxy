using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.UI;
namespace Galaxy
{
    public class StarMarker : MonoBehaviour
    {
        [SerializeField]
        private RawImage m_RawImage;
        [SerializeField]
        private PlanetSystemInfoWindow m_PlanetSystemInfoWindow;

        private Camera m_Camera;
        private EntityManager m_EntityManager;

        private Entity m_Entity;
        public static Transform Target;

        public Entity Entity
        {
            get => m_Entity;
            set
            {
                if (!m_Entity.Equals(value))
                {
                    m_Entity = value;
                    if (m_Entity != Entity.Null && m_EntityManager.IsCreated && SelectionSystem.ViewType == ViewType.Galaxy)
                    {
                        m_PlanetSystemInfoWindow.gameObject.SetActive(true);
                        m_PlanetSystemInfoWindow.ResetInfo(m_EntityManager.GetComponentData<StarProperties>(m_Entity), m_EntityManager.GetComponentData<StarSystemProperties>(m_Entity));
                    }
                    else
                    {
                        m_PlanetSystemInfoWindow.gameObject.SetActive(false);
                    }
                }
            }
        }

        private void Start()
        {
            m_PlanetSystemInfoWindow = Instantiate(m_PlanetSystemInfoWindow, FindObjectOfType<Canvas>().transform);
            m_Camera = Camera.main;
            m_EntityManager = World.Active.EntityManager;
            Entity = Entity.Null;
            Target = null;
        }
        // Update is called once per frame

        void Update()
        {
            if(m_Entity != Entity.Null)
            {
                float4 pos = m_EntityManager.GetComponentData<LocalToWorld>(m_Entity).Value.c3;
                var position = m_Camera.WorldToScreenPoint(new Vector3(pos.x, pos.y, pos.z));
                position.z = 0;
                transform.position = position;
            }else if(Target != null)
            {
                var position = m_Camera.WorldToScreenPoint(Target.position);
                position.z = 0;
                transform.position = position;
            }
            else
            {
                transform.position = new Vector3(20000, 0, 0);
            }
        }
    }
}
