using System.Collections;
using UnityEngine;
/// <summary>
/// Enemy 행동 모음 클래스
/// </summary>
public class Enemy : IsEnemy
{
    private float minusSpeedPercent = 0f;
    private Coroutine slowCoroutine;
    private float currentSpeed;

    private Vector3 currentPos;

    private void OnEnable()
    {
        StartCoroutine(DestinationCheck());
        StartCoroutine(SpeedCtrl());
        StartCoroutine(StateCheck());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void FixedUpdate()
    {
        if (this.gameObject.activeSelf == true && this.currentHitPoint > 0 && destination != null)
        {
            this.transform.LookAt(destination);
            currentPos = transform.position;

            if (Vector3.Distance(destination.position, currentPos) <= 2f)
            {
                animator.SetBool("Move", false);
                animator.SetBool("isAttack", true);
            }

            else
            {
                animator.SetBool("Move", true);
                animator.SetBool("isAttack", false);
                this.transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
            }
            
        }
    }

    private IEnumerator DestinationCheck()
    {
        while (true)
        {
            if (this.gameObject.activeSelf == true && this.currentHitPoint > 0)
            {
                float min = float.MaxValue;
                Transform desReturn = null;
                foreach (Transform des in destinations)
                {
                    float temp = (des.position - transform.position).sqrMagnitude;
                    if (min > temp)
                    {
                        min = temp;
                        desReturn = des;
                    }
                }

                destination = desReturn;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator StateCheck()
    {
        while (true)
        {
            if (this.currentHitPoint <= 0)
            {
                StopAllCoroutines();
                StartCoroutine(EnemyDie());
                yield break;
            }
            
            yield return new WaitForSeconds(0.2f);
        }

    }

    private IEnumerator EnemyDie()
    {
        this.gameObject.layer = LayerMask.NameToLayer("DeadEnemy");
        animator.SetBool("isDie", true);
        WaveManager.instance.KillEnemy();
        yield return new WaitForSeconds(1.5f);
        ReleaseObject();
    }

    private IEnumerator SpeedCtrl()
    {
        while (true)
        {
            currentSpeed = speed * (1f - minusSpeedPercent);
            animator.SetFloat("WalkAnimationSpeed", currentSpeed);
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void SlowDebuff(float percent, float duration)
    {
        if (slowCoroutine != null) StopCoroutine(slowCoroutine);
        slowCoroutine = StartCoroutine(Slow(percent, duration));
    }

    //Animation Event에서 발동되는 함수
    private void AttackPlayer()
    {
        PlayerManager.instance.BaseOnTheAttack(this.attackPoint);
    }

    private IEnumerator Slow(float percent, float duration)
    {
        minusSpeedPercent = percent;
        yield return new WaitForSeconds(duration);
        minusSpeedPercent = 0f;

        slowCoroutine = null;
    }

    public void SetTriggerTaunt()
    {
        animator.SetTrigger("Taunt");
    }

}
