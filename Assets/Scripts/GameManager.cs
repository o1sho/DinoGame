using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;
    public Button retryButton;

    private Player _player;
    private Spawner _spawner;

    private float _score;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else DestroyImmediate(gameObject);
    }

    private void OnDestroy()
    {
        if(instance == this) instance = null;
    }

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _spawner = FindObjectOfType<Spawner>();
        NewGame();     
    }

    public void NewGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        gameSpeed = initialGameSpeed;

        _score = 0f;

        enabled = true;
        _player.gameObject.SetActive(true);
        _spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        UpdateHiscore();
    }

    public void GameOver()
    {
        gameSpeed = 0;
        enabled = false;

        _player.gameObject.SetActive(false);
        _spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);

        UpdateHiscore();
    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        _score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(_score).ToString("D5");
    }

    private void UpdateHiscore()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if (_score > hiscore)
        {
            hiscore = _score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }

        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
    }

}
