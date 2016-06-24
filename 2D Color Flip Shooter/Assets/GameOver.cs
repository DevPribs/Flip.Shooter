using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    CanvasGroup canvasGroup;
    EnemySpawn enemySpawn;
    MoveTowardsPlayer MTP;
    PlayerLife playerLife;

	// Use this for initialization
	void Start () {
        canvasGroup = GameObject.Find("GameOverCanvas").GetComponent<CanvasGroup>();
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
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
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
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
