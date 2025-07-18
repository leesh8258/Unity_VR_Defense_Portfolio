using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    //���� �� ���������� ���͸� �����ϱ� ���� Ŭ����
    [System.Serializable]
    private class EnemyInfo
    {
        public string enemyType;
        public GameObject prefab;
        public int count;
    }

    //�̱��� ����
    public static EnemyManager instance;

    // ������ƮǮ �Ŵ��� �غ� �Ϸ�ǥ��
    public bool IsReady { get; private set; }

    [SerializeField]
    private EnemyInfo[] enemyInfos = null;

    // ������ ������Ʈ�� key�������� ���� ����
    private string enemyType;

    // ������ƮǮ���� ������ ��ųʸ�
    private Dictionary<string, IObjectPool<GameObject>> enemyPoolDic = new Dictionary<string, IObjectPool<GameObject>>();

    // ������ƮǮ���� ������Ʈ�� ���� �����Ҷ� ����� ��ųʸ�
    private Dictionary<string, GameObject> enemyDic = new Dictionary<string, GameObject>();

    // enemy �̸����� �����س��� ��ųʸ�
    private Dictionary<int, string> enemyIndexToName = new Dictionary<int, string>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        Init();
    }

    private void Init()
    {
        IsReady = false;
        for(int index = 0; index < enemyInfos.Length; index++)
        {
            IObjectPool<GameObject> pool = new ObjectPool<GameObject>(CreateEnemy, TakeEnemy, ReturnEnemy, DestroyEnemy,
                true, enemyInfos[index].count, enemyInfos[index].count);

            if (enemyDic.ContainsKey(enemyInfos[index].enemyType))
            {
                Debug.LogFormat("{0} �̹� ��ϵ� �� ���� �Դϴ�.", enemyInfos[index].enemyType);
                return;
            }

            enemyDic.Add(enemyInfos[index].enemyType, enemyInfos[index].prefab);
            enemyPoolDic.Add(enemyInfos[index].enemyType, pool);
            enemyIndexToName.Add(index, enemyInfos[index].enemyType);

            for(int i =0; i < enemyInfos[index].count; i++)
            {
                enemyType = enemyInfos[index].enemyType;
                IsEnemy _isEnemy = CreateEnemy().GetComponent<IsEnemy>();
                _isEnemy.Pool.Release(_isEnemy.gameObject);
            }

            IsReady = true;
        }
    }

    private GameObject CreateEnemy()
    {
        GameObject enemy = Instantiate(enemyDic[enemyType]);
        enemy.GetComponent<IsEnemy>().Pool = enemyPoolDic[enemyType];
        enemy.transform.SetParent(this.transform);
        return enemy;
    }

    private void TakeEnemy(GameObject enemy)
    {
        enemy.SetActive(true);
    }

    private void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
    }

    private void DestroyEnemy(GameObject enemy)
    {
        Destroy(enemy);
    }

    public GameObject GetEnemy(string _enemyType)
    {
        enemyType = _enemyType;

        if(enemyDic.ContainsKey(enemyType) == false)
        {
            Debug.LogFormat("{0} ���� ���� Ÿ���Դϴ�.", _enemyType);
            return null;
        }

        return enemyPoolDic[enemyType].Get();
    }

    public string GetEnemyName(int index)
    {
        return enemyIndexToName[index];
    }
}
