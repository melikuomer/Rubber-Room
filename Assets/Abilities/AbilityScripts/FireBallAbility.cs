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

    public override void Activate(Target target)
    {
        base.Activate(target);
        
        GameObject fireball = GameObject.Instantiate(fireballConfig.fireballPrefab, abilityConfig.defaultPosition, Quaternion.identity);
        Vector3 directionToTarget = (target.position - abilityConfig.defaultPosition).normalized;
        Rigidbody fireballRb = fireball.GetComponent<Rigidbody>();
        fireballRb.velocity = directionToTarget * fireballConfig.fireballSpeed;
    }
}

}