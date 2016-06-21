using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerLife : MonoBehaviour {

    public int life = 5;
    Text text;

	// Use this for initialization
	void Start () {
        text = GameObject.Find("Lifes").GetComponent<Text>();
        text.text = "Life: " + life;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == ("Enemy")|| col.gameObject.name == ("Enemy(Clone)"))
        {
            life--;
            Destroy(col.gameObject);
            text.text = "Life: " + life;
        }
    }
}
