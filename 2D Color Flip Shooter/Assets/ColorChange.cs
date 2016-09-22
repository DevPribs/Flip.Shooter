using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorChange : MonoBehaviour {

    public Color color1;
    public Color color2;
    public Color textColor1;
    public Color textColor2;

    int currentColor = 2;
    GameObject background;
    ShootingScript shootingScript;
    EnemySpawn enemySpawn;
    Text lifes;
    Text score;
    SaveData saveDataScript;

	// Use this for initialization
	void Start () {
        background = GameObject.Find("MainBackground");
        shootingScript = GameObject.Find("Player").GetComponent<ShootingScript>();
        enemySpawn = GameObject.Find("EnemyManager").GetComponent<EnemySpawn>();
        lifes = GameObject.Find("Lifes").GetComponent<Text>();
        score = GameObject.Find("Score").GetComponent<Text>();
        saveDataScript = GameObject.Find("GameManager").GetComponent<SaveData>();

        if(saveDataScript.loaded)
        {
            color1 = saveDataScript.getColor1();
            color2 = saveDataScript.getColor2();
            textColor1 = saveDataScript.getTextColor1();
            textColor2 = saveDataScript.getTextColor2();
        }
        else
        {
            saveDataScript.color1 = color1;
            saveDataScript.color2 = color2;
            saveDataScript.textColor1 = textColor1;
            saveDataScript.textColor2 = textColor2;
        }
        shootingScript.changeColor(color2);
        enemySpawn.changeColor(color1);
        background.GetComponent<Renderer>().material.color = color2;
        lifes.color = textColor1;
        score.color = textColor1;
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
            lifes.color = textColor1;
            score.color = textColor1;
            currentColor = 1;
        }
        else
        {
            shootingScript.changeColor(color2);
            enemySpawn.changeColor(color1);
            background.GetComponent<Renderer>().material.color = color2;
            lifes.color = textColor2;
            score.color = textColor2;
            currentColor = 2;
        }
        
    }

    public void setColor1(Color color)
    {
        color1 = color;
        enemySpawn.changeColor(color1);
    }

    public void setColor2(Color color)
    {
        color2 = color;
        shootingScript.changeColor(color2);
        background.GetComponent<Renderer>().material.color = color2;
    }

    public void setTextColor1(Color color)
    {
        textColor1 = color;
        lifes.color = textColor1;
        score.color = textColor1;
    }

    public void setTextColor2(Color color)
    {
        textColor2 = color;
        lifes.color = textColor2;
        score.color = textColor2;
    }

    public Color getColor1()
    {
        return color1;
    }

    public Color getColor2()
    {
        return color2;
    }

    public Color getTextColor1()
    {
        return textColor1;
    }

    public Color getTextColor2()
    {
        return textColor2;
    }
}
