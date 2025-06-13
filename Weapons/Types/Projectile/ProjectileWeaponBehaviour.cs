using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public WeaponScriptableObject weaponData;
    protected Vector3 direction;
    public float destroyAfterSeconds;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected bool currentIsPiercing;

    ShockwaveController shockwaveController;

    protected const string ENEMY = "Enemy";
    


    void Awake(){
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentIsPiercing = weaponData.IsPiercing;
        shockwaveController = FindObjectOfType<ShockwaveController>();
    }
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 enemyDir, Vector3 playerDir){
        Vector3 dir = enemyDir - playerDir;

        direction = dir.normalized;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag(ENEMY)){
            EnemyStats enemy = collider.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
            shockwaveController.ChangeState();
            CheckPierce();
        }
    }

    void CheckPierce(){
        if (!currentIsPiercing){
            Destroy(gameObject);
        }
    }
}
