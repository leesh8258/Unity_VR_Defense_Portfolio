using System.Collections;
using UnityEngine;

public class WaterOrb : IsWeapon
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
                hitEnemy.transform.GetComponent<IsEnemy>().HitPointDown(damage);
            }

            yield return new WaitForSeconds(attackDelay);
        }
        Destroy(this.gameObject);
    }
}
