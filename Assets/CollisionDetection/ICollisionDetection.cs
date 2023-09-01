// ICollisionDetection.cs
using UnityEngine;

namespace Abilities
{
    public interface ICollisionDetection
    {
        void CheckCollision(Vector3 targetPosition);
    }
}
