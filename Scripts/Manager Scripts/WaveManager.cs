using UnityEngine;
/// <summary>
/// 게임 내 wave 관리 클래스
/// 적 킬 수, 웨이브 단계를 프로퍼티로 제공
/// </summary>
public class WaveManager : MonoBehaviour
{
    public static WaveManager instance; 

    public int waveCount { get; private set; }
    public int killCount { get; private set; }
    private const int NEXTWAVECOUNT = 100;
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
        waveCount = 1;
        killCount = 0;
        
    }

    //적 오브젝트가 죽을 시 실행
    public void KillEnemy()
    {
        ++killCount;
        MonsterManager.instance.IncreaseKills(killCount);
        if (killCount / waveCount >= NEXTWAVECOUNT)
        {
            waveCount += 1;
        }

        Debug.Log(killCount);
    }
}
