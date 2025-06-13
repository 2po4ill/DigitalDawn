using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    const string PLAYER = "Player";

    public GameObject targetMap;
    MapController mapController;

    void Start()
    {
        mapController = FindObjectOfType<MapController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collider){
        if(collider.CompareTag(PLAYER)){
            mapController.currentChunk = targetMap;
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.CompareTag(PLAYER)){
            if(mapController.currentChunk == targetMap){
                mapController.currentChunk = null;
            }
        }
    }
}
