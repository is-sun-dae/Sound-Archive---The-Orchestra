using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public string songName;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}