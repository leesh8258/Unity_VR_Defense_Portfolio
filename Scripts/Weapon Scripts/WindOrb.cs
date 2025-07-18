using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindOrb : IsWeapon
{
    protected override IEnumerator OnAttack()
    {
        RaycastHit[] attackHits = Physics.SphereCastAll(transform.position, 4, Vector3.up, 0f, LayerMask.GetMask("Enemy"));
        foreach (RaycastHit hitEnemy in attackHits)
        {
            hitEnemy.transform.GetComponent<Rigidbody>().AddForce(-hitEnemy.transform.forward * meze, ForceMode.Impulse);
        }

        yield return null;
    }
}
