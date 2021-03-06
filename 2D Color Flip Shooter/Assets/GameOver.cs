﻿using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    CanvasGroup gameOverCanvas;
    EnemySpawn enemySpawn;
    MoveTowardsPlayer MTP;
    PlayerLife playerLife;

	// Use this for initialization
	void Start () {
        gameOverCanvas = GameObject.Find("GameOverCanvas").GetComponent<CanvasGroup>();
        enemySpawn = GameObject.Find("EnemyManager").GetComponent<EnemySpawn>();
        MTP = Resources.Load<GameObject>("Enemy").GetComponent<MoveTowardsPlayer>();
        playerLife = GameObject.Find("Player").GetComponent<PlayerLife>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Dead()
    {
        enemySpawn.stopEnemySpawn();
        MTP.Pause();
        gameOverCanvas.alpha = 1;
        gameOverCanvas.interactable = true;
        gameOverCanvas.blocksRaycasts = true;
    }

    public void Reset()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        playerLife.Reset();
        enemySpawn.startEnemySpawn();
        MTP.Play();
        this.GetComponent<Score>().Reset();
        gameOverCanvas.alpha = 0;
        gameOverCanvas.interactable = false;
        gameOverCanvas.blocksRaycasts = false;
    }
}
