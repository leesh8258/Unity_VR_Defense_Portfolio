using UnityEngine;

/// <summary>
/// ���� HP bar ������ġ ���� Ŭ����
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
