using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camera.main.aspect = (float)Screen.width / Screen.height;
    }

}
