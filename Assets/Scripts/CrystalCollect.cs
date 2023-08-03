using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrystalCollect : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;
    float crystalScore;
    private SaveManager saveManager;

    void Start()
    {
        saveManager = SaveManager.instance;
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
        int crystals = SaveManager.crystals;
        crystalScore = SaveManager.LoadCrystals();
        scoreText.text = "Score: " + crystals; ;
    }


    void OnEnable()
    {
        Collectable.collect += IncrementScore;
    }

    void IncrementScore(float score, AudioClip clip)
    {
        crystalScore += score;
        scoreText.text = "Score: " + crystalScore;
    }

    void OnDisable()
    {
        Collectable.collect -= IncrementScore;
    }
}
