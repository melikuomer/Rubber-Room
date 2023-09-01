// IAbility.cs
using UnityEngine;

namespace Abilities
{
    public interface IAbility
    {
        void Activate(Transform targetTransform, Vector3 targetPosition);
        TargetingType GetTargetingType();
    }
}
