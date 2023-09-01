// FireballAbilityConfig.cs
using UnityEngine;

namespace Abilities
{
[CreateAssetMenu(fileName = "FireballAbilityConfig", menuName = "Abilities/Fireball Ability")]
public class FireballAbilityConfig : AbilityConfig
{
    [Header("Fireball Settings")]
    public GameObject fireballPrefab;
    public float fireballSpeed = 10f;
}
}