using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{

    [System.Serializable] public class Wave {
        public string waveName;
        public List<EnemyGroup> enemyGroups;
        public int waveQuota;
        public float spawnInterval;
        public int spawnCount;
    }

    [System.Serializable] public class EnemyGroup{
        public string enemyName;
        public int enemyCount;
        public int spawnCount;
        public GameObject enemyPrefab;

    }

    public List<Wave> waves;
    public int currentWaveCount;

    [Header("Spawn Attributes")]
    float spawnTimer;
    public float waveInterval;
    public int enemiesAlive;
    public int maxEnemiesAllowed;
    public bool maxEnemiesReached = false;

    public int enemiesKilled = 0;
    bool isInWave = true;

    public int EnemiesLeft {
        get { return waves[CurrentWaveCount].waveQuota - enemiesKilled; }
        set {
            if (waves[CurrentWaveCount].waveQuota - enemiesKilled != value){
                value = waves[CurrentWaveCount].waveQuota - enemiesKilled;
                if(GameManager.instance != null){
                    GameManager.instance.currentEnemiesLeftDisplay.text = "Enemies left: " + (waves[CurrentWaveCount].waveQuota - enemiesKilled);
                }
            }
        }
    }
    

    public int CurrentWaveCount {
        get { return currentWaveCount; }
        set {
            if (currentWaveCount != value){
                currentWaveCount = value;
                if(GameManager.instance != null){
                    GameManager.instance.currentWaveCountDisplay.text = "Current Wave: " + (currentWaveCount + 1);
                }
            }
        }
    }
    

    [Header("Spawn Positions")]
    public List<Transform> relativeSpawnPoints;


    Transform player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindObjectOfType<PlayerStats>().transform;
        CalculateWaveQuota();
        if(GameManager.instance != null){
                
                    GameManager.instance.currentWaveCountDisplay.text = "Current Wave: " + (currentWaveCount + 1);
                    int currentValue = waves[CurrentWaveCount].waveQuota - enemiesKilled;
                    GameManager.instance.currentEnemiesLeftDisplay.text = "Enemies left: " + currentValue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isInWave)
        {
            BeginNextWave();
        }

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= waves[CurrentWaveCount].spawnInterval){
            spawnTimer = 0f;
            SpawnEnemies();
        }

        
    }

    void BeginNextWave(){
        isInWave = true;
        if (CurrentWaveCount < waves.Count - 1){
            CurrentWaveCount++;
            Invoke("WaveStart", waveInterval);
        }
        else {
            GameManager.instance.Victory();
        }
    }

    void WaveStart(){
        enemiesKilled = 0;
        Debug.Log("da ya rabotay epta");
        CalculateWaveQuota();
        if(GameManager.instance != null){
            int currentValue = waves[CurrentWaveCount].waveQuota - enemiesKilled;
            GameManager.instance.currentEnemiesLeftDisplay.text = "Enemies left: " + currentValue;
        }
    }

    void CalculateWaveQuota(){
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[CurrentWaveCount].enemyGroups){
            currentWaveQuota += enemyGroup.enemyCount;
        }
        waves[CurrentWaveCount].waveQuota = currentWaveQuota;
        Debug.LogWarning(currentWaveQuota);
    }

    void SpawnEnemies(){
        if(waves[CurrentWaveCount].spawnCount < waves[CurrentWaveCount].waveQuota && !maxEnemiesReached){
            foreach(var enemyGroup in waves[CurrentWaveCount].enemyGroups){
                if(enemyGroup.spawnCount < enemyGroup.enemyCount){

                    if(enemiesAlive >= maxEnemiesAllowed){
                        maxEnemiesReached = true;
                        return;
                    }

                    Instantiate(enemyGroup.enemyPrefab, player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity);

                    enemyGroup.spawnCount++;
                    waves[CurrentWaveCount].spawnCount++;
                    enemiesAlive++;
                } 
            }
        }
        if(enemiesAlive < maxEnemiesAllowed){
            maxEnemiesReached = false;
        } 
    }

    public void OnEnemyKilled(){
        EnemiesLeft--;
        enemiesKilled++;
        enemiesAlive--;
        if (enemiesKilled == waves[CurrentWaveCount].waveQuota){
            isInWave = false;
        }
    }

    public void GameOver(){
        waves.Clear();
    }
}
