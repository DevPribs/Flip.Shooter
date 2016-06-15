using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestCords : MonoBehaviour {

    Vector2 currentPosition;
    Text text;
    Text text2;
    GameObject player;

	// Use this for initialization
	void Start () {
        text = GameObject.Find("Cords").GetComponent<Text>();
        text2 = GameObject.Find("Cords2").GetComponent<Text>();
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        int numberTouches = Input.touchCount;

        if (numberTouches > 0)
        {
            Touch touch = Input.GetTouch(0);
            currentPosition = touch.position;
            text.text = (int)currentPosition.x + ", " + (int)currentPosition.y;
            text2.text = (int)(currentPosition.x - Screen.width/2) + ", " + (int)(currentPosition.y - Screen.height/2);


            if (touch.phase == TouchPhase.Ended)
            {
                
            }
        }
    }
}
