using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    //스폰 할 여러종류의 몬스터를 지정하기 위한 클래스
    [System.Serializable]
    private class EnemyInfo
    {
        public string enemyType;
        public GameObject prefab;
        public int count;
    }

    //싱글톤 패턴
    public static EnemyManager instance;

    // 오브젝트풀 매니저 준비 완료표시
    public bool IsReady { get; private set; }

    [SerializeField]
    private EnemyInfo[] enemyInfos = null;

    // 생성할 오브젝트의 key값지정을 위한 변수
    private string enemyType;

    // 오브젝트풀들을 관리할 딕셔너리
    private Dictionary<string, IObjectPool<GameObject>> enemyPoolDic = new Dictionary<string, IObjectPool<GameObject>>();

    // 오브젝트풀에서 오브젝트를 새로 생성할때 사용할 딕셔너리
    private Dictionary<string, GameObject> enemyDic = new Dictionary<string, GameObject>();

    // enemy 이름들을 저장해놓을 딕셔너리
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
                Debug.LogFormat("{0} 이미 등록된 적 종류 입니다.", enemyInfos[index].enemyType);
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
            Debug.LogFormat("{0} 없는 몬스터 타입입니다.", _enemyType);
            return null;
        }

        return enemyPoolDic[enemyType].Get();
    }

    public string GetEnemyName(int index)
    {
        return enemyIndexToName[index];
    }
}
