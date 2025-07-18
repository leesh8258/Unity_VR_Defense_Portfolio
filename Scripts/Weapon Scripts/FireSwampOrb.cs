using System.Collections;
using UnityEngine;

public class FireSwampOrb : IsWeapon
{
    protected override IEnumerator OnAttack()
    {
        int num = 0;

        while (numberOfAttack > num)
        {
            ++num;
            RaycastHit[] attackHits = Physics.SphereCastAll(transform.position, 3, Vector3.up, 0f, LayerMask.GetMask("Enemy"));

            foreach (RaycastHit hitEnemy in attackHits)
            {
                hitEnemy.transform.GetComponent<Enemy>().SlowDebuff(meze, attackDelay);
                hitEnemy.transform.GetComponent<IsEnemy>().HitPointDown(damage);
            }

            yield return new WaitForSeconds(attackDelay);
        }
        Destroy(this.gameObject);
    }

}
