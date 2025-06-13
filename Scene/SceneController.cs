using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SceneChange(string name){
        SceneManager.LoadScene(name);
    }
}
