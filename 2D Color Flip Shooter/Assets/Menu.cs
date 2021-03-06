﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    CanvasGroup settingMenuCanvas;
    CanvasGroup gameOverCanvas;
    CanvasGroup mainMenuCanvas;
    EnemySpawn enemySpawn;
    MoveTowardsPlayer MTP;
    PlayerLife playerLife;

    // Use this for initialization
    void Start () {

        settingMenuCanvas = GameObject.Find("SettingMenuCanvas").GetComponent<CanvasGroup>();
        gameOverCanvas = GameObject.Find("GameOverCanvas").GetComponent<CanvasGroup>();
        mainMenuCanvas = GameObject.Find("MainMenuCanvas").GetComponent<CanvasGroup>();
        enemySpawn = GameObject.Find("EnemyManager").GetComponent<EnemySpawn>();
        MTP = Resources.Load<GameObject>("Enemy").GetComponent<MoveTowardsPlayer>();
        playerLife = GameObject.Find("Player").GetComponent<PlayerLife>();
    }
	
	// Update is called once per frame
	void Update () {
        
	
	}

    public void MenuButton()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        playerLife.Reset();
        this.GetComponent<Score>().Reset();
        gameOverCanvas.alpha = 0;
        gameOverCanvas.interactable = false;
        gameOverCanvas.blocksRaycasts = false;
        mainMenuCanvas.alpha = 1;
        mainMenuCanvas.interactable = true;
        mainMenuCanvas.blocksRaycasts = true;
    }

    public void PlayButton()
    {
        enemySpawn.startEnemySpawn();
        MTP.Play();
        mainMenuCanvas.alpha = 0;
        mainMenuCanvas.interactable = false;
        mainMenuCanvas.blocksRaycasts = false;
    }

    public void SettingButton()
    {
        settingMenuCanvas.alpha = 1;
        settingMenuCanvas.interactable = true;
        settingMenuCanvas.blocksRaycasts = true;
    }

    public void SettingBackButton()
    {
        settingMenuCanvas.alpha = 0;
        settingMenuCanvas.interactable = false;
        settingMenuCanvas.blocksRaycasts = false;
    }
}
