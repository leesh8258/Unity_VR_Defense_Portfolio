using System.Collections;
using UnityEngine;

public class GroundOrb : IsWeapon
{
    protected override IEnumerator OnAttack()
    {
        int num = 0;

        while (numberOfAttack > num)
        {
            ++num;
            RaycastHit[] attackHits = Physics.SphereCastAll(transform.position, 4, Vector3.up, 0f, LayerMask.GetMask("Enemy"));
            foreach (RaycastHit hitEnemy in attackHits)
            {
                hitEnemy.transform.GetComponent<Enemy>().SlowDebuff(meze, attackDelay);
            }

            yield return new WaitForSeconds(attackDelay);
        }
        Destroy(this.gameObject);
    }
}
