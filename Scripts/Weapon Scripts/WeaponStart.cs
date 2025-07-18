using UnityEngine;

/// <summary>
/// GameObject Component용
/// </summary>
public class WeaponStart : MonoBehaviour
{
    private void Start()
    {
        WeaponManager.instance.WeaponStart();
    }
}
