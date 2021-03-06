﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    Text scoreText;
    Text gameOverScoreText;
    Text gameOverHighScoreText;
    int score = 0;
    int highScore = 0;
    double multiplier = 1;
    Slider multiplierSlide;

    SaveData saveDataScript;

    // Use this for initialization
    void Start()
    {

        scoreText = GameObject.Find("Score").GetComponent<Text>();
        gameOverScoreText = GameObject.Find("GameOverScore").GetComponent<Text>();
        gameOverHighScoreText = GameObject.Find("GameOverHighScore").GetComponent<Text>();
        multiplierSlide = GameObject.Find("MultiplierSlide").GetComponent<Slider>();
        multiplierSlide.value = 0;

        saveDataScript = GameObject.Find("GameManager").GetComponent<SaveData>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int points)
    {
        score += (int)((double)points * multiplier);
        scoreText.text = "" + score;
        if( score > highScore )
        {
            highScore = score;
            saveDataScript.highScore = highScore;
            gameOverHighScoreText.text = "High Score: " + highScore;
        }
        gameOverScoreText.text = "Score: " + score;
        multiplierSlide.value += 10;
        if(multiplierSlide.value == 100)
        {
            multiplierSlide.value = 0;
            multiplier++;
        }
    }

    public void Reset()
    {
        score = 0;
        scoreText.text = "" + score;
        gameOverScoreText.text = "Score: " + score;
        multiplierSlide.value = 0;
        multiplier = 1;
    }

    public void ResetMultiplier()
    {
        multiplierSlide.value = 0;
        multiplier = 1;
    }
}
