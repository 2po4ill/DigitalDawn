using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> propSpawnPoints;
    public List<GameObject> propPrefabs;


    void Start()
    {
        SpawnProps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnProps(){
        foreach (GameObject point in propSpawnPoints)
        {
            int rand = Random.Range(0, propPrefabs.Count);
            GameObject prop = Instantiate(propPrefabs[rand], point.transform.position, Quaternion.identity);
            prop.transform.parent = point.transform;
        }
    }
}
