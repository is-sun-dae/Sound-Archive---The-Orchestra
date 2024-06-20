using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public AudioSource music;
    public AudioClip clip;
    
    public string songName;
    public bool isGameFin;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        music = GetComponent<AudioSource>();
    }

    public void PlayAudioForPlay()
    {
        music.timeSamples = 0;
        music.PlayDelayed(3.0f);
    }
}
