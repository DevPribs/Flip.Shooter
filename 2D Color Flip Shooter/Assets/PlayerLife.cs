using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerLife : MonoBehaviour {

    public int life = 5;
    int lifeLeft;
    Text text;
    GameOver gameOver;
    Score score;

	// Use this for initialization
	void Start () {
        lifeLeft = life;
        text = GameObject.Find("Lifes").GetComponent<Text>();
        text.text = "Life: " + lifeLeft;
        gameOver = GameObject.Find("GameManager").GetComponent<GameOver>();
        score = GameObject.Find("GameManager").GetComponent<Score>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            lifeLeft--;
            Destroy(col.gameObject);
            text.text = "Life: " + lifeLeft;
            score.ResetMultiplier();
            if(lifeLeft == 0)
            {
                gameOver.Dead();
            }
        }
    }

    public void Reset()
    {
        lifeLeft = life;
        text.text = "Life: " + lifeLeft;
    }
}
