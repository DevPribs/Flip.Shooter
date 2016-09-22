using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy;
    public float spawnTime = 3f;
    private float changedSpawnTime;

    Color currentColor;
    GameObject enemySpawn1;
    GameObject enemySpawn2;
    GameObject enemySpawn3;
    GameObject enemySpawn4;

    // Use this for initialization
    void Start () {

        enemySpawn1 = GameObject.Find("EnemySpawn1");
        enemySpawn2 = GameObject.Find("EnemySpawn2");
        enemySpawn3 = GameObject.Find("EnemySpawn3");
        enemySpawn4 = GameObject.Find("EnemySpawn4");

        changedSpawnTime = spawnTime;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnEnemy()
    {
        int enemySpawnBox = Random.Range(1, 5);
        float x;
        float y;
        float spawnx;
        float spawny;
        Vector3 spawn;
        GameObject enemyClone;

        switch (enemySpawnBox)
        {
            case (1):
                y = enemySpawn1.GetComponent<SpriteRenderer>().bounds.size.y;
                spawny = Random.Range(0, y);
                spawny += enemySpawn1.transform.position.y;
                spawn = new Vector3(enemySpawn1.GetComponent<SpriteRenderer>().bounds.center.x, spawny);
                enemyClone = Instantiate(enemy, spawn, new Quaternion(0, 0, 0, 0)) as GameObject;
                enemyClone.GetComponent<Renderer>().material.color = currentColor;
                break;
            case (2):
                x = enemySpawn2.GetComponent<SpriteRenderer>().bounds.size.x;
                spawnx = Random.Range(0, x);
                spawnx += enemySpawn2.transform.position.x;
                spawn = new Vector3(spawnx, enemySpawn2.GetComponent<SpriteRenderer>().bounds.center.y);
                enemyClone = Instantiate(enemy, spawn, new Quaternion(0, 0, 0, 0)) as GameObject;
                enemyClone.GetComponent<Renderer>().material.color = currentColor;
                break;
            case (3):
                y = enemySpawn3.GetComponent<SpriteRenderer>().bounds.size.y;
                spawny = Random.Range(0, y);
                spawny += enemySpawn3.transform.position.y;
                spawn = new Vector3(enemySpawn3.GetComponent<SpriteRenderer>().bounds.center.x, spawny);
                enemyClone = Instantiate(enemy, spawn, new Quaternion(0, 0, 0, 0)) as GameObject;
                enemyClone.GetComponent<Renderer>().material.color = currentColor;
                break;
            case (4):
                x = enemySpawn4.GetComponent<SpriteRenderer>().bounds.size.x;
                spawnx = Random.Range(0, x);
                spawnx += enemySpawn4.transform.position.x;
                spawn = new Vector3(spawnx, enemySpawn4.GetComponent<SpriteRenderer>().bounds.center.y);
                enemyClone = Instantiate(enemy, spawn, new Quaternion(0, 0, 0, 0)) as GameObject;
                enemyClone.GetComponent<Renderer>().material.color = currentColor;
                break;
        }
    }

    public void stopEnemySpawn()
    {
        CancelInvoke();
    }

    public void startEnemySpawn()
    {
        InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
        InvokeRepeating("increaseEnemySpawn", 10, 10);
        changedSpawnTime = spawnTime;
    }

    void increaseEnemySpawn()
    {

        float increasedSpawn = 0.1f;

        CancelInvoke("SpawnEnemy");

        changedSpawnTime -= increasedSpawn;

        InvokeRepeating("SpawnEnemy", 0, changedSpawnTime);


    }

    public void changeColor(Color color)
    {
        currentColor = color;
    }
}
