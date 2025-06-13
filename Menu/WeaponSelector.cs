using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static WeaponSelector instance;
    public GameObject weapon;


    void Awake()
    {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public static GameObject GetData(){
        return instance.weapon;
    }

    public void SelectWeapon(GameObject selectedWeapon){
        weapon = selectedWeapon;
    }
}
