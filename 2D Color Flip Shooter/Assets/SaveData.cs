using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveData : MonoBehaviour {

    public Color color1;
    public Color color2;
    public Color textColor1;
    public Color textColor2;
    public int highScore = 0;
    public bool loaded = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        loadPlayerData();
        print("Applicaton was enabled");
    }

    void OnApplicationPause()
    {
        print("Application was paused");
    }

    void OnDisable()
    {
        savePlayerData();
        print("Application was disabled");
    }

    void savePlayerData()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");

        PlayerData playerData = new PlayerData();
        playerData.color1 = new SerializableColor(color1);
        playerData.color2 = new SerializableColor(color2);
        playerData.textColor1 = new SerializableColor(textColor1);
        playerData.textColor2 = new SerializableColor(textColor2);
        playerData.highScore = highScore;

        binaryFormatter.Serialize(file, playerData);
        file.Close();
    }

    void loadPlayerData()
    {
        if(File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            print(Application.persistentDataPath);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            PlayerData playerData = (PlayerData)binaryFormatter.Deserialize(file);
            file.Close();
            color1 = playerData.color1.GetColor();
            color2 = playerData.color2.GetColor();
            textColor1 = playerData.textColor1.GetColor();
            textColor2 = playerData.textColor2.GetColor();
            highScore = playerData.highScore;
            loaded = true;
        }
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

[System.Serializable]
class PlayerData
{
    public SerializableColor color1;
    public SerializableColor color2;
    public SerializableColor textColor1;
    public SerializableColor textColor2;

    public int highScore;
}

[System.Serializable]
class SerializableColor
{
    public float r;
    public float g;
    public float b;
    public float a;

    public SerializableColor(Color color)
    {
        r = color.r;
        g = color.g;
        b = color.b;
        a = color.a;
    }

    public Color GetColor()
    {
        return new Color(r, g, b, a);
    }
}
