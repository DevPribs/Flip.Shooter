using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerLife : MonoBehaviour {

    public int life = 5;
    int lifeLeft;
    Text text;
    GameOver gameOver;

	// Use this for initialization
	void Start () {
        lifeLeft = life;
        text = GameObject.Find("Lifes").GetComponent<Text>();
        text.text = "Life: " + lifeLeft;
        gameOver = GameObject.Find("GameManager").GetComponent<GameOver>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == ("Enemy")|| col.gameObject.name == ("Enemy(Clone)"))
        {
            lifeLeft--;
            Destroy(col.gameObject);
            text.text = "Life: " + lifeLeft;
            if(lifeLeft == 0)
            {
                gameOver.Dead();
            }
        }
    }

    public void Reset()
    {
        lifeLeft = life;
    }
}
