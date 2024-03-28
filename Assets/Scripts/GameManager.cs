using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform PlayerPaddle;
    public Transform EnemyPaddle;

    public BallController ballController;

    public int playerScore = 0;
    public int enemyScore = 0;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;

    public int winPoints = 2;

    public GameObject screenEndGame;

    public TextMeshProUGUI textEndGame;
   

    private void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        EnemyPaddle.position = new Vector3(-7f, 0f, 0f);
        PlayerPaddle.position = new Vector3(7f, 0f, 0f);

        ballController.ResetBall();

        playerScore = 0;
        enemyScore = 0;

        textPointsEnemy.text = enemyScore.ToString();
        textPointsPlayer.text = playerScore.ToString();

        screenEndGame.SetActive(false);
    }

    public void ScorePlayer()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }

    public void ScoreEnemy()
    {
        enemyScore++;
        textPointsPlayer.text = enemyScore.ToString();
        CheckWin();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EndGame();

        }
    }

    public void CheckWin()
    {
        if (enemyScore >= winPoints || playerScore >= winPoints)
        {
            //ResetGame();
            EndGame();
        }
    }
    public void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveController.Instance.GetName(playerScore > enemyScore);
        textEndGame.text = "Vitória " + winner;
        SaveController.Instance.SaveWinner(winner);

        Invoke("LoadMenu", 2f);
    }
    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}

