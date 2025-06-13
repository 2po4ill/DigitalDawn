using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public enum GameState {
        Gameplay,
        Paused,
        GameOver,
        Victory
    }

    public GameState currentState;

    public GameState previousState;

    public Text currentHealthDisplay;

    public Text currentWaveCountDisplay;
    public Text currentEnemiesLeftDisplay;

    public Text gameTimeDisplay;

    public Text finalTime;

    public bool isGameOver = false;

    public bool isVictory = false;

    [Header("UI")] public GameObject pauseScreen;
    [Header("UI")] public GameObject endScreen;
    [Header("UI")] public GameObject resultScreen;
    [Header("UI")] public GameObject resultTimer;

    GameObject[] enemies;
    EnemySpawner enemySpawner;

    float startTime;
    float gameTime = 0f;
    bool isTimerRunning = false;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Debug.LogWarning("EXTRA " + this + " DELETED");
        }
        DisableScreens();
        isTimerRunning = true;
        startTime = Time.time;
    }

    void Update(){

        if(isTimerRunning)
        {
            float currentTime = Time.time;
            gameTime += currentTime - startTime;
            UpdateTimeDisplay();
            startTime = currentTime;
        }

        switch (currentState){
            case GameState.Gameplay:
                CheckForPauseAndResume();
                break;
            case GameState.Paused:
                CheckForPauseAndResume();
                break;
            case GameState.GameOver:
                if(!isGameOver){
                    isGameOver = true;
                    isTimerRunning = false;
                    finalTime.text = "Time: " + gameTime;
                    Debug.Log("GAME IS OVER");
                    Invoke("DisplayEndScreen", 1f);
                }
                break;

            case GameState.Victory:
                if(!isVictory){
                    isVictory = true;
                    isTimerRunning = false;
                    finalTime.text = "Time: " + gameTime;
                    Debug.Log("Victory");
                    Invoke("DisplayResultScreen", 1f);
                }
                break;

            default:
                Debug.Log("State does not exist");
                break;
        }
    }

    public void PauseGame(){
        if(currentState != GameState.Paused){
            previousState = currentState;
            ChangeState(GameState.Paused);
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
            isTimerRunning = false;
            Debug.Log("Game is paused");
        }
        
    }

    public void ResumeGame(){
        if(currentState == GameState.Paused){
            ChangeState(previousState);
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
            isTimerRunning = true;
            startTime = Time.time;
            Debug.Log("Game is resumed");
        }
    }

    public void ChangeState(GameState newState){
        currentState = newState;
    }

    void CheckForPauseAndResume(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(currentState == GameState.Paused){
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
    }

    void DisableScreens(){
        pauseScreen.SetActive(false);
        resultScreen.SetActive(false);
        endScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GameOver(){
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemySpawner = FindObjectOfType<EnemySpawner>();
        enemySpawner.GameOver();
        foreach(GameObject enemy in enemies){
            EnemyStats enemyStats = enemy.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(10000f);
        }
        ChangeState(GameState.GameOver);
    }

    public void Victory(){
        ChangeState(GameState.Victory);
    }

    void DisplayResultScreen(){
        Time.timeScale = 0f;
        resultScreen.SetActive(true);
        resultTimer.SetActive(true);
    }

    void DisplayEndScreen()
    {
        Time.timeScale = 0f;
        endScreen.SetActive(true);
        resultTimer.SetActive(true);
    }

    void UpdateTimeDisplay()
    {
        gameTimeDisplay.text = "" + gameTime;
    }
}
