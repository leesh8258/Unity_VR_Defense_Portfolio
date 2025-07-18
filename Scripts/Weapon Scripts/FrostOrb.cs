using System.Collections;
using UnityEngine;

public class FrostOrb : IsWeapon
{
    protected override IEnumerator OnAttack()
    {
        RaycastHit[] attackHits = Physics.SphereCastAll(transform.position, 3, Vector3.up, 0f, LayerMask.GetMask("Enemy"));
        foreach (RaycastHit hitEnemy in attackHits)
        {
            hitEnemy.transform.GetComponent<Enemy>().SlowDebuff(meze, attackDelay);
        }

        yield return null;
    }
}
