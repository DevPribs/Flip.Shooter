using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {

    public Color color1;
    public Color color2;

    int currentColor = 1;
    GameObject background;
    ShootingScript shootingScript;
    EnemySpawn enemySpawn;

	// Use this for initialization
	void Start () {
        background = GameObject.Find("MainBackground");
        shootingScript = GameObject.Find("Player").GetComponent<ShootingScript>();
        enemySpawn = GameObject.Find("EnemyManager").GetComponent<EnemySpawn>();
        shootingScript.changeColor(color2);
        enemySpawn.changeColor(color1);
        background.GetComponent<Renderer>().material.color = color2;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeColor()
    {
        if(currentColor == 2)
        {
            shootingScript.changeColor(color1);
            enemySpawn.changeColor(color2);
            background.GetComponent<Renderer>().material.color = color1;
            currentColor = 1;
        }
        else
        {
            shootingScript.changeColor(color2);
            enemySpawn.changeColor(color1);
            background.GetComponent<Renderer>().material.color = color2;
            currentColor = 2;
        }
        
    }
}
