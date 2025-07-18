using UnityEngine;

/// <summary>
/// 무기 융합 조합식을 위한 SO클래스
/// </summary>
[CreateAssetMenu(fileName = "fusionWeapon Data", menuName = "Scriptable Object/fusionWeapon Data")]
public class fusionWeapons : ScriptableObject
{
    [SerializeField]
    private string combination_first;
    public string Combination_first { get { return combination_first; } }

    [SerializeField]
    private string combination_second;
    public string Combination_second { get { return combination_second; } }

    [SerializeField]
    private string result;
    public string Result { get { return result; } }
}
