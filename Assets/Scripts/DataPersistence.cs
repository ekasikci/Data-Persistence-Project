using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DataPersistence : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static DataPersistence Instance;

    public int score;
    public int bestScore;
    public string name;
    public string bestScoreName;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string bestScoreName;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.bestScoreName = bestScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            bestScoreName = data.bestScoreName;
        }
    }
}
