using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// 메인메뉴에서 스테이지로 넘어갈 때 메인메뉴에서 등록한 무기를 가져오기위한 클래스
/// </summary>
public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;
    [SerializeField] private GameObject[] weapons;
    private List<string> weaponsNames = new List<string>();
    private GameObject weaponPrefab;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void WeaponStart()
    {
        weapons = GameObject.FindGameObjectsWithTag("WeaponTable");
    }

    public bool CheckWeapons()
    {
        XRSocketInteractor socketInteractor = null;
        weaponsNames.Clear();
        foreach (GameObject weapon in weapons)
        {
            socketInteractor = weapon.GetComponent<XRSocketInteractor>();
            if (socketInteractor.GetOldestInteractableSelected() != null)
            {
                weaponsNames.Add(socketInteractor.GetOldestInteractableSelected().transform.name);
            }

            else
            {
                return false;
            }
        }

        return true;
    }
    public void SpawnWeapon(Transform[] spawnPoint)
    {
        int index = 0;
        foreach(string name in weaponsNames)
        {
            weaponPrefab = Resources.Load<GameObject>(name);
            weaponPrefab.GetComponent<OnHitGround>().spawnPoint = spawnPoint[index];
            Instantiate(weaponPrefab, spawnPoint[index].position, spawnPoint[index].localRotation);
            ++index;
        }
    }
}
