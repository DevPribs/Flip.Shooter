﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BulletHit : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Enemy")
        {
            Destroy(col.gameObject);
            GameObject.Find("GameManager").GetComponent<Score>().AddScore(10);
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
