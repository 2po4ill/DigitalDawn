using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static CharacterSelector instance;
    public CharacterScriptableObject characterData;
    void Awake()
    {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Debug.LogWarning("EXTRA" + this + "DELETED");
            Destroy(gameObject);
        }
    }
    public static CharacterScriptableObject GetData(){
        return instance.characterData;
    }

    public void SelectCharacter(CharacterScriptableObject character){
        characterData = character;
    }

    public void DestroySingleton(){
        instance = null;
        Destroy(gameObject);
    }
}
