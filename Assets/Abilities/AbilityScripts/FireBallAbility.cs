// FireballAbility.cs
using UnityEngine;
namespace Abilities
{
public class FireballAbility : BaseAbility
{
    private FireballAbilityConfig fireballConfig;

    public FireballAbility(FireballAbilityConfig config) : base(config)
    {
        fireballConfig = config;
    }

    public override void Activate(Transform targetTransform, Vector3 targetPosition)
    {
        base.Activate(targetTransform, targetPosition);
        
        GameObject fireball = GameObject.Instantiate(fireballConfig.fireballPrefab, abilityConfig.defaultPosition, Quaternion.identity);
        Vector3 directionToTarget = (targetPosition - abilityConfig.defaultPosition).normalized;
        Rigidbody fireballRb = fireball.GetComponent<Rigidbody>();
        fireballRb.velocity = directionToTarget * fireballConfig.fireballSpeed;
    }
}

}