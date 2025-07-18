using UnityEngine;
/// <summary>
/// ���� �� wave ���� Ŭ����
/// �� ų ��, ���̺� �ܰ踦 ������Ƽ�� ����
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

    //�� ������Ʈ�� ���� �� ����
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
