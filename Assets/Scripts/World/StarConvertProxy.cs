using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
namespace Galaxy
{
    [RequiresEntityConversion]
    public class StarConvertProxy : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var properties = new StarProperties { };
            var orbitproperties = new OrbitProperties { };
            dstManager.AddComponentData(entity, properties);
            dstManager.AddComponentData(entity, orbitproperties);
        }
    }
}
