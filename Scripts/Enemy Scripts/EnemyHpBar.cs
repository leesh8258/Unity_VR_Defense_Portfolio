using UnityEngine;

/// <summary>
/// 몬스터 HP bar 정면위치 조정 클래스
/// </summary>
public class EnemyHpBar : MonoBehaviour
{
    public Transform mainCamera;

    private void Start()
    {
        mainCamera = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(transform.position + mainCamera.rotation * Vector3.forward, mainCamera.rotation * Vector3.up);
    }
}
