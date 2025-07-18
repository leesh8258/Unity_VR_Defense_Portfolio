using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class IsEnemy : MonoBehaviour
{
    [SerializeField] private Image hpBar = null;

    [SerializeField] protected float speed;
    [SerializeField] protected int hitPoint;
    [SerializeField] protected int currentHitPoint;
    [SerializeField] protected int attackPoint;
    protected Transform[] destinations = null;
    protected Transform destination = null;
    protected Animator animator;

    public IObjectPool<GameObject> Pool { get; set; }
    
    public void Awake()
    {
        animator = GetComponent<Animator>();
        currentHitPoint = hitPoint;
        InitHpBarSize();
        if(GameObject.Find("Destinations") != null) destinations = GameObject.Find("Destinations").GetComponentsInChildren<Transform>();
    }

    private void InitHpBarSize()
    {
        if (hpBar != null) hpBar.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void ReleaseObject()
    {
        Pool.Release(gameObject);
        currentHitPoint = hitPoint;
    }

    public void HitPointDown(int damage)
    {
        currentHitPoint -= damage;
        hpBar.rectTransform.localScale = new Vector3((float)currentHitPoint / (float)hitPoint, 1f, 1f);
    }

    public void CurrentHitPointZero()
    {
        currentHitPoint = 0;
    }

}
