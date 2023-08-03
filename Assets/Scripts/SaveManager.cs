using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public static string _collectCount = "collectCount";
    public static int crystals;

    public void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        if (PlayerPrefs.HasKey(_collectCount))
        {
            crystals = PlayerPrefs.GetInt(_collectCount);
        }
        else
        {
            crystals = 0;
            PlayerPrefs.SetInt(_collectCount, crystals);
        }
    }
    public static void IncrementCrystals()
    {
        crystals++;
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        crystals = 0;
        PlayerPrefs.SetInt(_collectCount, crystals);
        PlayerPrefs.Save();
        Debug.Log("Current Crystals Count: " + crystals);

    }

    public static int LoadCrystals()
    {
        return PlayerPrefs.GetInt(_collectCount, 0);
    }
}
