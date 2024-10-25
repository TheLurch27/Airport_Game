using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool isGamePaused = false;

    void Awake()
    {
        // Singleton Pattern to ensure only one GameManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Preserve GameManager across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager
        }
    }

    void Start()
    {
        // Initialize game state if needed
        Debug.Log("Game Started");
    }

    public void StartGame()
    {
        // Start the game logic, load the first scene, etc.
        Debug.Log("Game Starting...");
        SceneManager.LoadScene("GameScene");
    }

    public void PauseGame()
    {
        if (!isGamePaused)
        {
            Time.timeScale = 0; // Pauses the game
            isGamePaused = true;
            Debug.Log("Spiel befindet sich im Pausenmodus");
        }
    }

    public void ResumeGame()
    {
        if (isGamePaused)
        {
            Time.timeScale = 1; // Resumes the game
            isGamePaused = false;
            Debug.Log("Spiel befindet sich wieder im Spielmodus");
        }
    }

    public void RestartGame()
    {
        // Reload the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1; // Make sure the game is not paused when restarting
        Debug.Log("Spiel wurde neugestartet");
    }

    public void QuitGame()
    {
        // Quit the application
        Debug.Log("Spiel wurde beendet");
        Application.Quit();
    }
}
