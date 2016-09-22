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
    ColorChange colorChangeScript;
    SaveData saveDataScript;

    Image background1;
    Image background2;
    Image bullet1;
    Image bullet2;
    Image enemy1;
    Image enemy2;
    Text text1;
    Text text2;
    Slider r;
    Slider g;
    Slider b;

	// Use this for initialization
	void Start () {
        colorChangeScript = GameObject.Find("GameManager").GetComponent<ColorChange>();
        saveDataScript = GameObject.Find("GameManager").GetComponent<SaveData>();
        color1 = colorChangeScript.getColor1();
        color2 = colorChangeScript.getColor2();
        testColor1 = color1;
        testColor2 = color2;
        textColor1 = colorChangeScript.getTextColor1();
        textColor2 = colorChangeScript.getTextColor2();
        testTextColor1 = textColor1;
        testTextColor2 = textColor2;
        colorPickerCanvas = GameObject.Find("ColorPickerCanvas").GetComponent<CanvasGroup>();
        background1 = GameObject.Find("BackgroundTest1").GetComponent<Image>();
        background2 = GameObject.Find("BackgroundTest2").GetComponent<Image>();
        bullet1 = GameObject.Find("BulletTest1").GetComponent<Image>();
        bullet2 = GameObject.Find("BulletTest2").GetComponent<Image>();
        enemy1 = GameObject.Find("EnemyTest1").GetComponent<Image>();
        enemy2 = GameObject.Find("EnemyTest2").GetComponent<Image>();
        text1 = GameObject.Find("TextTest1").GetComponent<Text>();
        text2 = GameObject.Find("TextTest2").GetComponent<Text>();
        r = GameObject.Find("RedSlider").GetComponent<Slider>();
        g = GameObject.Find("GreenSlider").GetComponent<Slider>();
        b = GameObject.Find("BlueSlider").GetComponent<Slider>();

        background1.color = color1;
        background2.color = color2;
        bullet1.color = color2;
        bullet2.color = color1;
        enemy1.color = color2;
        enemy2.color = color1;
        text1.color = textColor1;
        text2.color = textColor2;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void colorChangeSelection(int x)
    {
        currentColorChange = x;
        switch(x)
        {
            case (1):
                r.value = color1.r * 255;
                g.value = color1.g * 255;
                b.value = color1.b * 255;
                break;
            case (2):
                r.value = color2.r * 255;
                g.value = color2.g * 255;
                b.value = color2.b * 255;
                break;
            case (3):
                r.value = textColor1.r * 255;
                g.value = textColor1.g * 255;
                b.value = textColor1.b * 255;
                break;
            case (4):
                r.value = textColor2.r * 255;
                g.value = textColor2.g * 255;
                b.value = textColor2.b * 255;
                break;
        }
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
                saveDataScript.color1 = testColor1;
                colorChangeScript.setColor1(color1);
                break;
            case (2):
                color2 = testColor2;
                saveDataScript.color2 = testColor2;
                colorChangeScript.setColor2(color2);
                break;
            case (3):
                textColor1 = testTextColor1;
                saveDataScript.textColor1 = testTextColor1;
                colorChangeScript.setTextColor1(textColor1);
                break;
            case (4):
                textColor2 = testTextColor2;
                saveDataScript.textColor2 = testTextColor2;
                colorChangeScript.setTextColor2(textColor2);
                break;
        }
        colorPickerCanvas.alpha = 0;
        colorPickerCanvas.interactable = false;
        colorPickerCanvas.blocksRaycasts = false;
    }

    public void changeRed()
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

    public void changeGreen()
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

    public void changeBlue()
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
