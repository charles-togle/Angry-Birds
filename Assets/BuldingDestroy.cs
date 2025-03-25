using UnityEngine;

public class BuldingDestroy : MonoBehaviour
{
    private int Life = 4;
    private int HitTimes = 0;
    [SerializeField] private Sprite[] Buildings;
    private SpriteRenderer spriteRenderer => gameObject.GetComponent<SpriteRenderer>();
    private float timeElapsed = 0;
    private bool gameActive = false;
    [SerializeField] private GameObject GamManager;
    private GameManager gameManager => GamManager.GetComponent<GameManager>();

    private void Start()
    {
        gameManager.addObstacleLife(Life);
    }
    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 1.5)
        {
            gameActive = true;
            timeElapsed = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!gameActive)
        {
            return;
        }

        if (HitTimes % 3 == 0)
        {
            HitTimes++;
            return;
        }
        
        HitTimes = 0;
        Life--;
        gameManager.subtractObstacleLife(1);
        if (Life == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            spriteRenderer.sprite = Buildings[Life - 1];
        }
    }

}
