using System.Collections;
using UnityEngine;

public class LightningOrb : IsWeapon
{
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private GameObject lightning;

    protected override IEnumerator OnAttack()
    {
        RaycastHit[] attackHits = Physics.SphereCastAll(transform.position, 0.5f, Vector3.up, 0f, LayerMask.GetMask("Enemy"));
        foreach (RaycastHit hitEnemy in attackHits)
        {
            hitEnemy.transform.GetComponent<IsEnemy>().HitPointDown(damage);
        }

        foreach(Transform attackPoint in spawnPoint)
        {
            Instantiate(lightning, attackPoint.position, attackPoint.rotation, attackPoint);
        }
        
        yield return new WaitForSeconds(3f);

        Destroy(this.gameObject);
    }

    
}
