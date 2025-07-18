using System.Collections;
using UnityEngine;

/// <summary>
/// 몬스터 스폰 관련 클래스
/// </summary>
public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public static readonly WaitForSeconds waitSpawnTime = new WaitForSeconds(2f);
    private const int MAXKILLCOUNT = 300;
    
    [Header("스폰위치"), SerializeField] private Transform spawnPoint;
    [Header("가중치"), SerializeField] private float[] enemyDatas;
    [Header("스폰 수"), SerializeField] private int[] enemySpawnNums;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private int RandomIndex()
    {
        float total = 0;

        for(int i = 0; i < enemyDatas.Length; i++)
        {
            total += enemyDatas[i];
        }

        float pivot = Random.Range(0, total);
        for (int i = 0; i < enemyDatas.Length; i++)
        {
            if(pivot < enemyDatas[i])
            {
                return i;
            }

            else
            {
                pivot -= enemyDatas[i];
            }
        }

        return enemyDatas.Length - 1;
    }


    private void EnemySpawnPoint(string enemyName)
    {
        int num = 0;
        if (enemyName == "SmallEnemy") num = enemySpawnNums[0];
        else if (enemyName == "NormalEnemy") num = enemySpawnNums[1];
        else if (enemyName == "BigEnemy") num = enemySpawnNums[2];

        for (int i = 0; i < num; i++)
        {
            GameObject enemy = EnemyManager.instance.GetEnemy(enemyName);
            Vector3 pos = spawnPoint.position + (Random.insideUnitSphere * 4f);
            pos.y = 0;
            enemy.transform.position = pos;
            enemy.layer = LayerMask.NameToLayer("Enemy");
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(WaveManager.instance.killCount < MAXKILLCOUNT && PlayerManager.instance.ReturnCurrentHitPoint() > 0)
        {
            int index = RandomIndex();
            string enemyName = EnemyManager.instance.GetEnemyName(index);
            EnemySpawnPoint(enemyName);
            yield return waitSpawnTime;
        }

        if (PlayerManager.instance.ReturnCurrentHitPoint() > 0)
        {
            StageManager.instance.playerWin();
        }

        else
        {
            StageManager.instance.playerLose();
        }
    }


}
