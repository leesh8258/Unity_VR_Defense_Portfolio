using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 컨트롤러 속도를 가져와 융합가능한 무기 2종을 빠르게 부딪히면 융합무기가 생성되는 기능을 담당하는 클래스
/// </summary>
public class WeaponFusion : MonoBehaviour
{
    public static WeaponFusion instance;
    public fusionWeapons[] _fusionWeapons;
    private GameObject leftDirectInteractor;
    private GameObject rightDirectInteractor;
    private List<string> weapons = new List<string>();
    private Coroutine isFusion = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    public void StartFusion()
    {
        if (isFusion == null) isFusion = StartCoroutine(Fusion());
    }

    private string CompareTwoWeapons()
    {
        foreach(fusionWeapons weapon in _fusionWeapons)
        {
            if ( (weapons[0].Equals(weapon.Combination_first) && weapons[1].Equals(weapon.Combination_second)) ||
                    (weapons[1].Equals(weapon.Combination_first) && weapons[0].Equals(weapon.Combination_second)) )
            {
                return weapon.Result;
            }
        }

        return null;
    }

    private IEnumerator Fusion()
    {
        if (weapons.Count >= 2 && (DeviceVelocityCheck.instance.leftVelocity >= 1.1f || DeviceVelocityCheck.instance.rightVelocity >= 1.1f))
        {
            string fusionWeaponName = CompareTwoWeapons();
            if (fusionWeaponName == null) yield return null;
            
            else
            {
                leftDirectInteractor = GameObject.FindWithTag("leftDirect");
                rightDirectInteractor = GameObject.FindWithTag("rightDirect");
                Debug.Log(leftDirectInteractor + " " + rightDirectInteractor);
                if (leftDirectInteractor != null && rightDirectInteractor != null)
                {
                    GameObject leftObj = leftDirectInteractor.GetComponent<IsReturnObjectGrab>().ReturnInteractorObject();
                    GameObject rightObj = rightDirectInteractor.GetComponent<IsReturnObjectGrab>().ReturnInteractorObject();

                    Vector3 spawnPoint = (leftObj.transform.position + rightObj.transform.position) / 2;
                    leftObj.SetActive(false);
                    rightObj.SetActive(false);
                    GameObject weapon = Resources.Load<GameObject>(fusionWeaponName);
                    Instantiate(weapon, spawnPoint, Quaternion.identity);
                }
            }
        } 

        yield return new WaitForSeconds(1f);
        isFusion = null;
    }

    public void WeaponTagAddList(string tag)
    {
        weapons.Add(tag);

    }

    public void WeaponTagRemoveList(string tag)
    {
        if (weapons.Contains(tag)) weapons.Remove(tag);
    }

}
