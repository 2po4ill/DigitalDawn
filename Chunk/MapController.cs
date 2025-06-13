using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    const string RIGHT = "Right";
    const string LEFT = "Left";
    const string UP = "Up";
    const string DOWN = "Down";
    const string RIGHTUP = "Right-Up";
    const string RIGHTDOWN = "Right-Down";
    const string LEFTUP = "Left-Up";
    const string LEFTDOWN = "Left-Down";


    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;

    public GameObject currentChunk;
    PlayerMovement playerMovement;

    [Header("Optimisation")]
    public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxOptimizedDist;
    float optimizedDist;

    float optimizationCooldown;
    public float optimizationDuration;
    
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }

    //todo find a better option -> generate 3 chunks for each direction separatly -> then find solution to compact the code

    void ChunkChecker(){
        if(!currentChunk){
            return;
        }
        if (playerMovement.moveDir.x > 0) // move right
        {
            SpawnChunkTrajectory(RIGHT);
            SpawnChunkTrajectory(RIGHTUP);
            SpawnChunkTrajectory(RIGHTDOWN);
        }
        else if (playerMovement.moveDir.x < 0) // move left
        {
            SpawnChunkTrajectory(LEFT);
            SpawnChunkTrajectory(LEFTUP);
            SpawnChunkTrajectory(LEFTDOWN);
        }
        else if (playerMovement.moveDir.y > 0) // move up
        {
            SpawnChunkTrajectory(UP);
            SpawnChunkTrajectory(LEFTUP);
            SpawnChunkTrajectory(RIGHTUP);
        }
        else if (playerMovement.moveDir.y < 0) // move down
        {
            SpawnChunkTrajectory(DOWN);
            SpawnChunkTrajectory(LEFTDOWN);
            SpawnChunkTrajectory(RIGHTDOWN);
        }
    }

    void SpawnChunk(){
        int rand = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }

    void SpawnChunkTrajectory(string trajectory){
        if(!Physics2D.OverlapCircle(currentChunk.transform.Find(trajectory).position, 
            checkerRadius, terrainMask)){
                noTerrainPosition = currentChunk.transform.Find(trajectory).position;
                SpawnChunk();            
            }
    }

    void ChunkOptimizer(){
        optimizationCooldown -= Time.deltaTime;
        if (optimizationCooldown <= 0f)
        {
            optimizationCooldown = optimizationDuration;
        }
        else{
            return;
        }
        foreach(GameObject chunk in spawnedChunks){
            optimizedDist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (optimizedDist > maxOptimizedDist){
                chunk.SetActive(false);
            }
            else{
                chunk.SetActive(true);
            }
        }
    }
}
