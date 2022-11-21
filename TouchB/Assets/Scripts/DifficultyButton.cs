using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DifficultyButton : MonoBehaviour
{
    Button button;
    GameManager _gameManager;

    public int Difficulty;
    
    
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    
    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        _gameManager.startGame( Difficulty);

    }
}
