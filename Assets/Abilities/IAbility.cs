// IAbility.cs
using UnityEngine;

namespace Abilities
{
    public interface IAbility
    {
        void Activate(Target target);
        TargetingType GetTargetingType();
    }
}
