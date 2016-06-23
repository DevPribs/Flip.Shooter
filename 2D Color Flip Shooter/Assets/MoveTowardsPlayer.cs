using UnityEngine;
using System.Collections;

public class MoveTowardsPlayer : MonoBehaviour {

    GameObject player;
    static bool pause;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        pause = false;
    }
	
	// Update is called once per frame
	void Update () {
        //Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        //Vector2 playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        if(!pause)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0.1F);
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
