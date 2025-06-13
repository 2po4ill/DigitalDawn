using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public EnemyScriptableObject enemyData;

    [HideInInspector] public float currentMoveSpeed;
    [HideInInspector] public float currentHealth;
    [HideInInspector] public float currentDamage;
    [HideInInspector] public bool hasRangeAttack;
    [HideInInspector] public GameObject projPrefab;

    

    const string PLAYER = "Player";
    const string IS_DEAD = "IsDead";

    public float despawnDistance = 20f;
    Transform player;

    Animator animator;

    void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
        hasRangeAttack = enemyData.HasRangeAttack;
        projPrefab = enemyData.ProjPrefab;
    }

    void Start(){
        player = FindObjectOfType<PlayerStats>().transform;
        animator = GetComponent<Animator>();
    }

    void Update(){
        if(Vector2.Distance(transform.position, player.position) >= despawnDistance){
            ReturnEnemy();
        }
    }

    public void TakeDamage(float dmg){
        currentHealth -= dmg;

        if (currentHealth <= 0){
            currentMoveSpeed = 0;
            animator.SetBool(IS_DEAD, true);
            Invoke("Kill", 1f);
        }
    }

    public void Kill(){
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.CompareTag(PLAYER)){
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage);
        }
    }

    private void OnDestroy(){
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        spawner.OnEnemyKilled();
    }

    void ReturnEnemy(){
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        transform.position = player.position + spawner.relativeSpawnPoints[Random.Range(0, spawner.relativeSpawnPoints.Count)].position;
    }
}
