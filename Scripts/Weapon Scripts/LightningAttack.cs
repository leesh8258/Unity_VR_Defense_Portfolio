using System.Collections;
using UnityEngine;

public class LightningAttack : IsWeapon
{
    [SerializeField] private float speed;
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    protected override IEnumerator OnAttack()
    {
        int num = 0;

        while (numberOfAttack > num)
        {
            ++num;
            RaycastHit[] attackHits = Physics.SphereCastAll(transform.position, 0.5f, Vector3.up, 0f, LayerMask.GetMask("Enemy"));
            foreach (RaycastHit hitEnemy in attackHits)
            {
                hitEnemy.transform.GetComponent<Enemy>().HitPointDown(damage);
            }
            yield return new WaitForSeconds(attackDelay);
        }
    }
}
