using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    Text text;
    int score = 0;
    double multiplier = 1;
    Slider multiplierSlide;

    // Use this for initialization
    void Start()
    {

        text = GameObject.Find("Score").GetComponent<Text>();
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
        text.text = "" + score;
        multiplierSlide.value += 10;
        if(multiplierSlide.value == 100)
        {
            multiplierSlide.value = 0;
            multiplier++;
        }
    }
}
