using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveData : MonoBehaviour {

    public Color color1;
    public Color color2;
    public Color textColor1;
    public Color textColor2;
    public int[] highScores;
    public bool loaded = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        load();
        print("Applicaton was enabled");
    }

    void OnApplicationPause()
    {
        print("Application was paused");
    }

    void OnDisable()
    {
        save();
        print("Application was disabled");
    }

    void save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");

        PlayerData playerData = new PlayerData();
        playerData.color1 = color1;
        playerData.color2 = color2;
        playerData.textColor1 = textColor1;
        playerData.textColor2 = textColor2;
        playerData.highScores = highScores;

        binaryFormatter.Serialize(file, playerData);
        file.Close();
    }

    void load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            PlayerData playerData = (PlayerData)binaryFormatter.Deserialize(file);
            file.Close();
            color1 = playerData.color1;
            color2 = playerData.color2;
            textColor1 = playerData.textColor1;
            textColor2 = playerData.textColor2;
            highScores = playerData.highScores;
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
    public Color color1;
    public Color color2;
    public Color textColor1;
    public Color textColor2;

    public int[] highScores;
}
