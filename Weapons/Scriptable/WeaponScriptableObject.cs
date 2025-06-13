using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "Weapon/WeaponScriptableOnject")]
public class WeaponScriptableObject : ScriptableObject
{   
    
    [SerializeField] GameObject prefab;
    [SerializeField] public float damage;
    [SerializeField] public float speed;
    [SerializeField] public float cooldownDuration;
    [SerializeField] public bool isKeyRequired;
    [SerializeField] public bool isPiercing;

    public GameObject Prefab {get => prefab; private set => prefab = value;}
    public float Damage {get => damage; private set => damage = value;}
    public float Speed {get => speed; private set => speed = value;}
    public float CooldownDuration {get => cooldownDuration; private set => cooldownDuration = value;}
    public bool IsPiercing {get => isPiercing; private set => isPiercing = value;}
    public bool IsKeyRequired {get => isKeyRequired; private set => isKeyRequired = value;}

}
