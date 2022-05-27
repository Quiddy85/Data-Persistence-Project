using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    // Create an instance
    public static SaveData Instance;

    // public variables
    public int highScore = 0;
    public InputField playerNameInput;
    public Text displayHighScore;
    public string playerNameText;
    public string highScorePlayerNameText;

    private void Awake()
    {
        // If the object exists, destroy the copy
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Load save file
        LoadInformation();

        // This instance
        Instance = this;
        DontDestroyOnLoad(gameObject); // Don't destroy when we change scenes

        displayHighScore.text= "Player : " + highScorePlayerNameText +  " Score : " +  highScore;
    }

    // This is where we make our save points
    [System.Serializable]
    class SaveInfo
    {
        public int highScore = 0;
        public InputField playerNameInput;
        public string playerNameText;
        public string highScorePlayerNameText;
    }

    public void SaveInformation()
    {
        // Create new SaveData
        SaveInfo data = new SaveInfo();

        //Put 'class SaveInfo' variables here as data.variable = variable made at the top
        data.highScore = highScore;
        data.highScorePlayerNameText = highScorePlayerNameText;

    // Load the JsonUtility and give it the data
    string json = JsonUtility.ToJson(data); // Create json variable
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); // Set the save path and file. Give it the json variable

        Debug.Log("Data saved");
    }

    public void LoadInformation()
    {
        // Get file and set path variable
        string path = Application.persistentDataPath + "/savefile.json";

        // if the file exists laod it, otherwise ignore
        if (File.Exists(path))
        {
            // Read the file to the json variable
            string json = File.ReadAllText(path);
            SaveInfo data = JsonUtility.FromJson<SaveInfo>(json);

            // set variables to the loaded data with variable declared at the top = data.variable
            highScore = data.highScore;
            highScorePlayerNameText = data.highScorePlayerNameText;

            Debug.Log("Data loaded");
        }
    }
}
