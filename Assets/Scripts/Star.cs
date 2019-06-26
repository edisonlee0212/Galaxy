using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
namespace Galaxy
{

    public class Star : OnlineObject
    {
        private int m_StarId = int.MinValue;
        private StarFactory m_StarFactory;
        public int StarId
        {
            get
            {
                return m_StarId;
            }
            set
            {
                if (m_StarId == int.MinValue && value != int.MinValue)
                {
                    m_StarId = value;
                }
                else
                {
                    Debug.LogError("Not allowed to change starId.");
                }
            }
        }

        public StarFactory StarFactory { get => m_StarFactory; set => m_StarFactory = value; }

        public override void Spawn()
        {
            transform.localScale = Vector3.one * Mathf.Sqrt(World.Active.EntityManager.GetComponentData<StarProperties>(entity).mass);
            base.Spawn();
        }

        public override void Despawn()
        {
            base.Despawn();
            m_StarFactory.Reclaim(this);
        }


    }
}
