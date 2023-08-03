using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;
using TMPro;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    float value = 100f;
    public static Action<float, AudioClip> collect;
    private SaveManager saveManager;
    private TextMeshProUGUI scoreText;
    [SerializeField] 
    AudioClip clip;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = CrystalObjectPool.instance.transform.position;
            
            collect?.Invoke(value, clip);
            gameObject.SetActive(false);

            SaveManager.IncrementCrystals();
            int crystals = SaveManager.crystals;
        }
    }
}
