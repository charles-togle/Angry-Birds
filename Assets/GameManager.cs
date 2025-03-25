using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float ObstacleLives = 0;
    private float Damage = 0;
    [SerializeField] private GameObject GameOver;

    [SerializeField] private TextMeshProUGUI ScoreText;
    public void addObstacleLife(float life)
    {
        ObstacleLives += life;
    }


    public void subtractObstacleLife(float damage)
    {
        Damage += damage;
    }

    private float timeFromGameOver = 0;
    private void Update()
    {
        float progress = 100 - (((ObstacleLives - Damage) / ObstacleLives) * 100);
        string progressText = progress.ToString("F0");
        ScoreText.text = "Progress: " + progressText + "%";
        if (progress >= 100)
        {
            timeFromGameOver += Time.deltaTime;
            ScoreText.text = "You Win!";
        }
        if (timeFromGameOver >= 3)
        {
            GameOver.SetActive(true);
        }
    }
}
