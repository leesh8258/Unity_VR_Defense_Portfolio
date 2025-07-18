using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// XRDirectIneteractor class를 사용하여 현재 컨트롤러가 상호작용하고 있는 GameObject를 반환하는 클래스
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
