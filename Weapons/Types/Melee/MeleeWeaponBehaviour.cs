using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float destroyAfterSeconds;
    public WeaponScriptableObject weaponData;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected bool currentIsPiercing;

    const string ENEMY = "Enemy";

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    

    void Awake(){
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentIsPiercing = weaponData.IsPiercing;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag(ENEMY)){
            EnemyStats enemy = collider.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
        }
    }


    // Update is called once per frame
}
