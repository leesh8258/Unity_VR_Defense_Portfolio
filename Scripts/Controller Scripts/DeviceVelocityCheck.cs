using UnityEngine;
using UnityEngine.XR;

/// <summary>
/// ��Ʈ�ѷ��� ���� �ӵ��� ����Ͽ� �����ϴ� Ŭ����
/// </summary>

public class DeviceVelocityCheck : MonoBehaviour
{
    public static DeviceVelocityCheck instance;
    [HideInInspector] public float leftVelocity = 0f;
    [HideInInspector] public float rightVelocity = 0f;

    private DeviceInputData deviceInputData;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        deviceInputData = GetComponent<DeviceInputData>();

    }

    void Update()
    {
        CheckDeviceVelocity();
    }

    private void CheckDeviceVelocity()
    {
        if (deviceInputData.leftController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 leftVelocity))
            this.leftVelocity = leftVelocity.magnitude;

        if (deviceInputData.rightController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 rightVelocity))
            this.rightVelocity = rightVelocity.magnitude;
    }
}
