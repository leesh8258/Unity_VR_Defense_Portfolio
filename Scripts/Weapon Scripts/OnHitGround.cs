using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// 무기가 ground에 닿았을 때 발생할 이벤트 클래스
/// </summary>
public class OnHitGround : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;
    [SerializeField] private float cooltime;
    public Transform spawnPoint = null;
    private Vector3 point;
    private XRBaseInteractable interactable;

    public void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Ground")))
        {
            point = collision.contacts[0].point;
            point.y += 0.2f;
            CreateAttack();
            this.gameObject.SetActive(false);
        }

        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("weapon")))
        {
            WeaponFusion.instance.StartFusion();
        }
    }

    private void OnDisable()
    {
        Invoke("SetActiveTrue", cooltime);
    }

    private void SetActiveTrue()
    {
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = spawnPoint.position;
    }

    private void CreateAttack()
    {
        Instantiate(Prefab, point, Prefab.transform.rotation);
    }

    public void WeaponTagAdd()
    {
        if (!(interactable.GetOldestInteractorSelecting().transform.tag == "WeaponTable")) WeaponFusion.instance.WeaponTagAddList(interactable.tag);
    }

    public void WeaponTagRemove()
    {
       WeaponFusion.instance.WeaponTagRemoveList(interactable.tag);
    }

}
