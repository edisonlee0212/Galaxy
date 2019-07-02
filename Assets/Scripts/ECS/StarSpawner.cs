using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
namespace Galaxy
{
    public class StarSpawner : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
    {
        public GameObject m_StarPrefab;
        public int m_Count;
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var spawnerData = new SpawnerProperties
            {
                Count = m_Count,
                Prefab = conversionSystem.GetPrimaryEntity(m_StarPrefab)
            };
            dstManager.AddComponentData(entity, spawnerData);
        }

        public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        {
            referencedPrefabs.Add(m_StarPrefab);
        }
    }
}
