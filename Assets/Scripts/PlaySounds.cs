using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    void PlayOnCollect(float i, AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
        //audioSource.Play();
    }

    void PlayOnJump(int i, AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    void OnEnable()
    {
        Collectable.collect += PlayOnCollect;
        PlayerJump.jumpSound += PlayOnJump;
    }

    void OnDisable()
    {
        Collectable.collect -= PlayOnCollect;
        PlayerJump.jumpSound -= PlayOnJump;
    }
}
