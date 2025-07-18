using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

/// <summary>
/// VR 컨트롤러 디바이스 설정 클래스
/// </summary>
public class DeviceInputData : MonoBehaviour
{
    public InputDevice rightController;
    public InputDevice leftController;

    private void Update()
    {
        if (!rightController.isValid || !leftController.isValid)
            InitializeInputDevices();
    }

    private void InitializeInputDevices()
    {
        if (!rightController.isValid)
            InitializeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, ref rightController);
        if (!leftController.isValid)
            InitializeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, ref leftController);

    }

    private void InitializeInputDevice(InputDeviceCharacteristics inputCharacteristics, ref InputDevice inputDevice)
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(inputCharacteristics, devices);

        if (devices.Count > 0)
        {
            inputDevice = devices[0];
        }
    }
}
