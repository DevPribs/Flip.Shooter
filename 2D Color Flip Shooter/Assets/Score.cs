using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    Text scoreText;
    Text gameOverScoreText;
    int score = 0;
    double multiplier = 1;
    Slider multiplierSlide;

    // Use this for initialization
    void Start()
    {

        scoreText = GameObject.Find("Score").GetComponent<Text>();
        gameOverScoreText = GameObject.Find("GameOverScore").GetComponent<Text>();
        multiplierSlide = GameObject.Find("MultiplierSlide").GetComponent<Slider>();
        multiplierSlide.value = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int points)
    {
        score += (int)((double)points * multiplier);
        scoreText.text = "" + score;
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
}
