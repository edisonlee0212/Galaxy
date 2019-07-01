using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Galaxy {
    [CreateAssetMenu]
    public class StarFactory : ScriptableObject
    {
        [SerializeField]
        Star[] m_StarPrefabs;

        List<Star>[] m_StarPools;
        Scene m_PoolScene;

        [SerializeField]
        RenderMesh m_RenderMesh;

        public void Start()
        {
            m_StarPools = new List<Star>[m_StarPrefabs.Length];
            for (int i = 0; i < m_StarPools.Length; i++)
            {
                m_StarPools[i] = new List<Star>();
            }

            if (Application.isEditor)
            {
                m_PoolScene = SceneManager.GetSceneByName("Main");
                if (m_PoolScene.isLoaded)
                {
                    GameObject[] rootObjects = m_PoolScene.GetRootGameObjects();
                    for (int i = 0; i < rootObjects.Length; i++)
                    {
                        Star pooledStars = rootObjects[i].GetComponent<Star>();
                        SceneManager.MoveGameObjectToScene(pooledStars.gameObject, m_PoolScene);
                        if (!pooledStars.gameObject.activeSelf)
                        {
                            m_StarPools[pooledStars.StarId].Add(pooledStars);
                        }
                    }
                    return;
                }
            }
            m_PoolScene = SceneManager.CreateScene(name);

        }

        public void Reclaim(Star starToRecycle)
        {
            m_StarPools[starToRecycle.StarId].Add(starToRecycle);
        }

        public Star Get(StarProperties starProperties, OrbitProperties orbitProperties, int starId = 0)
        {
            Star instance;
            List<Star> pool = m_StarPools[starId];
            int lastIndex = pool.Count - 1;
            if (lastIndex >= 0)
            {
                instance = pool[lastIndex];
                pool.RemoveAt(lastIndex);
            }
            else
            {
                instance = Instantiate(m_StarPrefabs[starId]);
                instance.StarFactory = this;
                instance.StarId = starId;
                instance.entity = World.Active.EntityManager.CreateEntity(GalaxyEntityArchetypes.StarEntityArchetype);
                SceneManager.MoveGameObjectToScene(instance.gameObject, m_PoolScene);
            }
            World.Active.EntityManager.SetComponentData(instance.entity, starProperties);
            World.Active.EntityManager.SetComponentData(instance.entity, orbitProperties);

            //World.Active.EntityManager.AddSharedComponentData<RenderMesh>(instance.entity, m_RenderMesh);
            instance.Spawn();
            return instance;
        }
    }
}