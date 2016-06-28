using UnityEngine;
using System.Collections;

public class MoveTowardsPlayer : MonoBehaviour {

    GameObject player;
    Renderer background;
    Renderer enemy;
    static bool pause;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        background = GameObject.Find("MainBackground").GetComponent<Renderer>();
        enemy = this.GetComponent<Renderer>();
        pause = false;
    }
	
	// Update is called once per frame
	void Update () {
        //Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        //Vector2 playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        if (!pause && background.material.color != enemy.material.color)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0.05F);
        }

	}

    public void Pause()
    {
        pause = true;
    }

    public void Play()
    {
        pause = false;
    }
}
