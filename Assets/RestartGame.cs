using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void RestartGameEvent(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
