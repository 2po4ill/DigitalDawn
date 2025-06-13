using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Transform player;
    EnemyStats enemy;

    Vector3 direction;
    float destroyAfterSeconds = 3;

    float currentDamage = 1;
    float currentSpeed = 10;
    float currentCooldownDuration = 3;
    const string PLAYER = "Player";

    void Start()
    {
        enemy = GetComponent<EnemyStats>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemy.currentMoveSpeed * Time.deltaTime);
        
    }
}
