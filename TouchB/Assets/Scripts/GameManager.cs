using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject RestartText;
    public GameObject titleText;

    public bool gameOver = false;
    private int Score = 0;
    float spawnRate = 1f;

    

    
    IEnumerator spawnobj()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate );
            int index = Random.Range(0, targets.Count);

            Instantiate(targets[index]);
        }
        
    }
    public void UpdateScore(int scoreToadd)
    {
        Score += scoreToadd;
        ScoreText.text = "Score: " + Score;
       

    }

    public void GameOver()
    {

        gameOverText.gameObject.SetActive(true);
        RestartText.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void startGame(int Difficulty)
    {
        spawnRate /= Difficulty;
        StartCoroutine(spawnobj());
        UpdateScore(0);
        titleText.gameObject.SetActive(false);
    }
}
