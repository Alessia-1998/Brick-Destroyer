using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField]
    GameObject touchToPlayPanel, gameOverPanel, gameWonPanel;

    Rigidbody2D ball;

    bool gameStarted = false, gameOver = false;

    int spawnedBricks = 0;

    private void Awake()
    {
        gameManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetGameScene();
    }

    // Update is called once per frame
    void Update()
    {
        if ( gameOver && Input.GetMouseButtonDown(0))
        {
            gameOverPanel.SetActive(false);
            ResetGameScene();
        }

        else if ( !gameStarted && Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            touchToPlayPanel.SetActive(false);
            ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
            ball.AddForce(Vector2.up);
        }
    }

    void ResetGameScene()
    {
        if( SceneManager.GetSceneByName("GameScene").name == "GameScene" )
        {
            SceneManager.UnloadScene("GameScene");
        }

        SceneManager.LoadScene("GameScene", LoadSceneMode.Additive);
        gameOver = false;
        gameStarted = false;
        touchToPlayPanel.SetActive(true);
        spawnedBricks = 0;
        if (gameWonPanel == true) gameWonPanel.SetActive(false);
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void GameWon()
    {
        Destroy(ball.gameObject);
        gameWonPanel.SetActive(true);
        gameOver = true;
    }

    public void SetSpawnedBricks(int value)
    {
        spawnedBricks = value;
    }

    public void BrickDestroyed()
    {
        spawnedBricks--;
        if ( spawnedBricks <= 0 )
        {
            GameWon();
        }
    }
}
