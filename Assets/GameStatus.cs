using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    [SerializeField] GameObject startGameScreen;

    private void Start()
    {
        Debug.Log(PlayerPrefs.GetString("isGameRestarted") );
        if (PlayerPrefs.GetString("isGameRestarted") == "true")
        {
            startGameScreen.SetActive(false);
            PlayerPrefs.SetString("isGameRestarted", "false");
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetString("isGameRestarted", "false");
            PlayerPrefs.Save();
            Application.Quit();
        } 
    }

    public void StartGame()
    {
        startGameScreen.SetActive(false);
    }

    public void RestartGameEvent(){
        PlayerPrefs.SetString("isGameRestarted", "true");
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
