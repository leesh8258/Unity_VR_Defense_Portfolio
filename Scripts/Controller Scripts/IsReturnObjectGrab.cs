using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// XRDirectIneteractor class�� ����Ͽ� ���� ��Ʈ�ѷ��� ��ȣ�ۿ��ϰ� �ִ� GameObject�� ��ȯ�ϴ� Ŭ����
/// </summary>
public class IsReturnObjectGrab : MonoBehaviour
{
    private XRDirectInteractor interactor;

    private void Start()
    {
        interactor = GetComponent<XRDirectInteractor>();
    }

    public GameObject ReturnInteractorObject()
    {
        if (interactor.GetOldestInteractableSelected() != null)
        {
            GameObject obj = interactor.GetOldestInteractableSelected().transform.gameObject;
            return obj;
        }

        return null;
    }
}
