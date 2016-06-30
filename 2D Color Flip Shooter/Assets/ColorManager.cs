using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour {

    Color testColor1;
    Color testColor2;
    Color testTextColor1;
    Color testTextColor2;
    Color color1;
    Color color2;
    Color textColor1;
    Color textColor2;
    int currentColorChange = 0;
    CanvasGroup colorPickerCanvas;

    Image background1;
    Image background2;
    Image bullet1;
    Image bullet2;
    Image enemy1;
    Image enemy2;
    Text text1;
    Text text2;

	// Use this for initialization
	void Start () {
        testColor1 = new Color(0, 0, 0);
        testColor2 = new Color(0, 0, 0);
        testTextColor1 = new Color(0, 0, 0);
        testTextColor2 = new Color(0, 0, 0);
        colorPickerCanvas = GameObject.Find("ColorPickerCanvas").GetComponent<CanvasGroup>();
        background1 = GameObject.Find("BackgroundTest1").GetComponent<Image>();
        background2 = GameObject.Find("BackgroundTest2").GetComponent<Image>();
        bullet1 = GameObject.Find("BulletTest1").GetComponent<Image>();
        bullet2 = GameObject.Find("BulletTest2").GetComponent<Image>();
        enemy1 = GameObject.Find("EnemyTest1").GetComponent<Image>();
        enemy2 = GameObject.Find("EnemyTest2").GetComponent<Image>();
        text1 = GameObject.Find("TextTest1").GetComponent<Text>();
        text2 = GameObject.Find("TextTest2").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void colorChangeSelection(int x)
    {
        currentColorChange = x;
        colorPickerCanvas.alpha = 1;
        colorPickerCanvas.interactable = true;
        colorPickerCanvas.blocksRaycasts = true;
    }

    public void cancelColorChange()
    {
        objectResetColor();
        colorPickerCanvas.alpha = 0;
        colorPickerCanvas.interactable = false;
        colorPickerCanvas.blocksRaycasts = false;
    }

    public void okColorChange()
    {
        switch(currentColorChange)
        {
            case (1):
                color1 = testColor1;
                break;
            case (2):
                color2 = testColor2;
                break;
            case (3):
                textColor1 = testTextColor1;
                break;
            case (4):
                textColor2 = testTextColor2;
                break;
        }
        colorPickerCanvas.alpha = 0;
        colorPickerCanvas.interactable = false;
        colorPickerCanvas.blocksRaycasts = false;
    }

    public void changeRed(Slider r)
    {
        switch (currentColorChange)
        {
            case (1):
                testColor1.r = r.value/255f;
                break;
            case (2):
                testColor2.r = r.value/255f;
                break;
            case (3):
                testTextColor1.r = r.value/255f;
                break;
            case (4):
                testTextColor2.r = r.value/255f;
                break;
        }
        objectSetColor();
    }

    public void changeGreen(Slider g)
    {
        switch (currentColorChange)
        {
            case (1):
                testColor1.g = g.value/255f;
                break;
            case (2):
                testColor2.g = g.value/255f;
                break;
            case (3):
                testTextColor1.g = g.value/255f;
                break;
            case (4):
                testTextColor2.g = g.value/255f;
                break;
        }
        objectSetColor();
    }

    public void changeBlue(Slider b)
    {
        switch (currentColorChange)
        {
            case (1):
                testColor1.b = b.value/255f;
                break;
            case (2):
                testColor2.b = b.value/255f;
                break;
            case (3):
                testTextColor1.b = b.value/255f;
                break;
            case (4):
                testTextColor2.b = b.value/255f;
                break;
        }
        objectSetColor();
    }

    public void setColor(Color color)
    {
        switch (currentColorChange)
        {
            case (1):
                testColor1 = color;
                break;
            case (2):
                testColor2 = color;
                break;
            case (3):
                testTextColor1 = color;
                break;
            case (4):
                testTextColor2 = color;
                break;
        }
        objectSetColor();
    }

    void objectSetColor()
    {
        switch(currentColorChange)
        {
            case (1):
                background1.color = testColor1;
                bullet2.color = testColor1;
                enemy2.color = testColor1;
                break;
            case (2):
                background2.color = testColor2;
                bullet1.color = testColor2;
                enemy1.color = testColor2;
                break;
            case (3):
                text1.color = testTextColor1;
                break;
            case (4):
                text2.color = testTextColor2;
                break;
        }
    }

    void objectResetColor()
    {
        switch (currentColorChange)
        {
            case (1):
                background1.color = color1;
                bullet2.color = color1;
                enemy2.color = color1;
                break;
            case (2):
                background2.color = color2;
                bullet1.color = color2;
                enemy1.color = color2;
                break;
            case (3):
                text1.color = textColor1;
                break;
            case (4):
                text2.color = textColor2;
                break;
        }
    }
}
