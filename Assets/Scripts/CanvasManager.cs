using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

    private Text _scoreText;
    private Text _bestScoreText;
    private Text _gameStatus;
    private int _score;
    private int _bestScore;
    void Awake()
    {
        _scoreText = GameObject.Find("Score").GetComponent<Text>();
        _scoreText.text = "Score : "+ _score;

        _bestScoreText = GameObject.Find("BestScore").GetComponent<Text>();
        _bestScore = PlayerPrefs.GetInt("score");
        _bestScoreText.text = "Best :" + _bestScore;

        _gameStatus = GameObject.Find("GameStatus").GetComponent<Text>();
        _gameStatus.text = "";


        //Zapic.Start(""1.0.3");
    }

    public void AddScore()
    {
        _score++;
        _scoreText.text = "Score : " + _score;

        if(_score>_bestScore)
            _bestScoreText.text = "Best : " + _score;

        if (_score == GameSettings.brickCount)
            Victory();

        /*
         *if(_score ==16) 
               Zapic.SubmitEvent(GameSettings.LevelName+"LevelCompleted");
         
         */

    }

    public void GameOver()
    {
        _gameStatus.text = "Game Over!";
        if(_score >= _bestScore)
            PlayerPrefs.SetInt("score", _score);
        GameSettings.gameState = EnumTypes.GameState.FinishedMode;
        StartCoroutine(BackToMenu());
    }

    public void Victory() {

        _gameStatus.text = "You Won!";
        PlayerPrefs.SetInt("score", _score);
        GameSettings.gameState = EnumTypes.GameState.FinishedMode;
        StartCoroutine(BackToMenu());
    }

    public void Reset()
    {
        _score = 0;
        _scoreText.text = "Score : " + _score;

        _bestScore = PlayerPrefs.GetInt("score");
        _bestScoreText.text = "Best :" + _bestScore;

        _gameStatus.text = "";

    }

    IEnumerator BackToMenu(){
        yield return new WaitForSeconds(2);
        Camera.main.transform.Rotate(0, 180, 0);

    }

	
}
