using System.Collections;
using UnityEngine;

/// <summary>
/// ���� CS���� �������� ���� �ֻ����θ� Ŭ����
/// �⺻���� ���� ��ɵ��� ����
/// </summary>
public class IsWeapon : MonoBehaviour
{
    [Header("�ڽ��� ��ȯ�� Prefab")]
    [SerializeField] protected GameObject parentPrefab;

    [Header("���� �Ӽ�")]
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
