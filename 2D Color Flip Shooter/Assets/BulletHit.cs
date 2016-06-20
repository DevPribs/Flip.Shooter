using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BulletHit : MonoBehaviour {

    Text text;
    int score = 0;

	// Use this for initialization
	void Start () {

        text = GameObject.Find("Score").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Enemy")
        {
            Destroy(col.gameObject);
            score += 10;
            text.text = "" + score;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "BoundsWall")
        {
            Destroy(this.gameObject);
        }
    }
}
