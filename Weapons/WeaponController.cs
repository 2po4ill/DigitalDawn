using UnityEngine;
using UnityEngine.Timeline;


    public class WeaponController : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        [Header("Weapon Stats")]
        public WeaponScriptableObject weaponData;
        float currentCooldown;
        bool isKeyRequired;

        protected PlayerMovement playerMovement;

        public GameObject[] enemies;
        public GameObject player;
        public Vector3 closestEnemyPosition;

        float minimalDistance;


        protected virtual void Start()
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
            currentCooldown = weaponData.cooldownDuration;
            isKeyRequired = weaponData.isKeyRequired;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if (isKeyRequired){
                if(Input.GetKeyDown(KeyCode.Space))
                Attack();
            }
            else{
                currentCooldown -= Time.deltaTime;
                if(currentCooldown <= 0f){
                    Attack();
                }
            }
            
        }

        protected virtual void Attack(){
            currentCooldown = weaponData.cooldownDuration;
            UpdateEnemies();
        }

        void UpdateEnemies(){
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            player = GameObject.FindGameObjectWithTag("Player");
            FindClosestEnemy();
        }

        void FindClosestEnemy(){
            closestEnemyPosition = enemies[0].transform.position;
            minimalDistance = CalculateDistance(enemies[0].transform.position, player.transform.position);
            foreach (GameObject enemy in enemies){
                if (minimalDistance > CalculateDistance(enemy.transform.position, player.transform.position)){
                    closestEnemyPosition = enemy.transform.position;
                }
            }
        }

        float CalculateAxis(float x, float y){
            return Mathf.Abs(x-y);
        }

        float CalculateDistance(Vector3 x, Vector3 y){
            return CalculateAxis(x.x, y.x) + CalculateAxis(x.y, y.y);
        }
    }

