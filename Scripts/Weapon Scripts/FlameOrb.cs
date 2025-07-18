using System.Collections;
using UnityEngine;

public class FlameOrb : IsWeapon
{
    protected override IEnumerator OnAttack()
    {
        RaycastHit[] attackHits = Physics.SphereCastAll(transform.position, 4, Vector3.up, 0f, LayerMask.GetMask("Enemy"));
        foreach(RaycastHit hitEnemy in attackHits)
        {
            hitEnemy.transform.GetComponent<IsEnemy>().HitPointDown(damage);
        }

        yield return null;
    }

}
