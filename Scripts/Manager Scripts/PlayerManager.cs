using System.Collections;
using UnityEngine;
using TMPro;


public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [SerializeField] private GameObject playerHitObject;
    [SerializeField] private TextMeshProUGUI playerHealthText; 

    private Coroutine shake;
    private int playerHitPoint = 500;
    private int currentPlayerHitPoint;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        currentPlayerHitPoint = playerHitPoint;
        UpdateHealthUI(); 
    }

    public void BaseOnTheAttack(int attackDamage)
    {
        if (currentPlayerHitPoint > 0)
        {
            currentPlayerHitPoint -= attackDamage;
            currentPlayerHitPoint = Mathf.Max(currentPlayerHitPoint, 0); 
            if (shake == null) shake = StartCoroutine(Shake());
            UpdateHealthUI(); 
        }
       
    }

    private IEnumerator Shake()
    {
        float time = 1f;
        float shakePower = 0.5f;
        Vector3 origin = playerHitObject.transform.position;

        while (time > 0f)
        {
            time -= 0.05f;
            playerHitObject.transform.position = origin + (Vector3)Random.insideUnitCircle * shakePower * time;
            yield return null;
        }

        playerHitObject.transform.position = origin;
        shake = null;
    }

    public int ReturnCurrentHitPoint()
    {
        return currentPlayerHitPoint;
    }

    private void UpdateHealthUI()
    {
        playerHealthText.text = "남은 체력: " + currentPlayerHitPoint.ToString() + "/" + playerHitPoint.ToString();
    }
}