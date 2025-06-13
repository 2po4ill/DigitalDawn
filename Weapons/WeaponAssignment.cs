using System.Collections.Generic;
using UnityEngine;

public class WeaponAssignment : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject weapon;


    void Awake()
    {
        weapon = WeaponSelector.GetData();
        Debug.Log("weapon");
        AsignWeapon(weapon);
    }

    void AsignWeapon(GameObject weapon){
        GameObject spawnedWeapon = Instantiate(weapon);
        spawnedWeapon.transform.position = transform.position;
        spawnedWeapon.transform.parent = transform;
    }
}
