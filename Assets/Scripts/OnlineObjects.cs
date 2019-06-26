using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Assertions;

namespace Galaxy
{
    public struct BodyComponents
    {
        public Vector3 position;
        public Quaternion rotation;
    }
    public class OnlineObject : MonoBehaviour
    {
        public Entity entity;
        public Translation position;
        public Rotation rotation;
        public IsDead isDead;

        //Set the gameobject position and sync with the ECS.
        public void OnlineObjectsStart(ref BodyComponents bodyComponents)
        {
            Assert.IsTrue(isDead.value);
            transform.SetPositionAndRotation(bodyComponents.position, bodyComponents.rotation);
            position.Value = bodyComponents.position;
            rotation.Value = bodyComponents.rotation;
            UploadPosition();
            Spawn();
        }

        public virtual void SyncRigidBody()
        {
            Vector3 position = World.Active.EntityManager.GetComponentData<Translation>(entity).Value;
            transform.position = position;
            Quaternion rotation = World.Active.EntityManager.GetComponentData<Rotation>(entity).Value;
            transform.rotation = rotation;
        }

        protected virtual void UploadRigidBody()
        {
            UploadPosition();
            UploadRotation();
        }

        protected virtual void UploadPosition()
        {
            position.Value = transform.position;
            World.Active.EntityManager.SetComponentData(entity,
                    position);
        }

        protected virtual void UploadRotation()
        {
            rotation.Value = transform.rotation;
            World.Active.EntityManager.SetComponentData(entity,
                    rotation);
        }

        public virtual void Spawn()
        {
            gameObject.SetActive(true);
            isDead.value = false;
            World.Active.EntityManager.SetComponentData(entity,
                    isDead);
        }

        public virtual void Despawn()
        {
            gameObject.SetActive(false);
            isDead.value = true;
            World.Active.EntityManager.SetComponentData(entity,
                    isDead);
        }
    }
}
