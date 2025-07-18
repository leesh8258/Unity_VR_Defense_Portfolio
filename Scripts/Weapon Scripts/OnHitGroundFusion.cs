using UnityEngine;
/// <summary>
/// ���� ����� �� �̺�Ʈ �߻� ���չ��� Ŭ����
/// </summary>
public class OnHitGroundFusion : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;
    private Vector3 point;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Ground")))
        {
            point = collision.contacts[0].point;
            point.y += 0.2f;
            createAttack();
            Destroy(gameObject);
        }
    }
    private void createAttack()
    {
        Instantiate(Prefab, point, Prefab.transform.rotation);
    }

    public void firstSelect()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
    }
}
