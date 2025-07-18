using System.Collections;
using UnityEngine;

/// <summary>
/// 무기 CS들이 공통으로 갖는 최상위부모 클래스
/// 기본적인 무기 기능들을 소유
/// </summary>
public class IsWeapon : MonoBehaviour
{
    [Header("자신을 소환한 Prefab")]
    [SerializeField] protected GameObject parentPrefab;

    [Header("공격 속성")]
    [SerializeField] protected int damage;
    [SerializeField] protected float meze;
    [SerializeField] protected int numberOfAttack;
    [SerializeField] protected float attackDelay;

    private void Start()
    {
        StartCoroutine(OnAttack());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("weapon"))
        {
            WeaponFusion.instance.StartFusion();
        }
    }

    protected virtual IEnumerator OnAttack() { yield return null; }
}
