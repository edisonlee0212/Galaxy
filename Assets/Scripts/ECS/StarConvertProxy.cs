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
            var starSystemProperties = new StarSystemProperties { };
            var scale = new Scale { };
            dstManager.AddComponentData(entity, properties);
            dstManager.AddComponentData(entity, orbitproperties);
            dstManager.AddComponentData(entity, scale);
            dstManager.AddComponentData(entity, starSystemProperties);
        }
    }
}
