using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private GameSetting gameSetting;
    private NoteProcess noteProcess;

    private KeyCode key1;
    private KeyCode key2;
    private KeyCode key3;
    private KeyCode key4;
    
    private void Start()
    {
        gameSetting = GameObject.Find("GameSetting").GetComponent<GameSetting>();
        noteProcess = GameObject.Find("NoteProcess").GetComponent<NoteProcess>();

        key1 = KeyCode.A;
        key2 = KeyCode.S;
        key3 = KeyCode.K;
        key4 = KeyCode.L;

        // key1 = gameSetting.key1;
        // key2 = gameSetting.key2;
        // key3 = gameSetting.key3;
        // key4 = gameSetting.key4;
    }

    private void Update()
    {
        if (Input.GetKeyDown(key1))
        {
            noteProcess.ProcessNote(1);
        }
        if (Input.GetKeyDown(key2))
        {
            noteProcess.ProcessNote(2);
        }
        if (Input.GetKeyDown(key3))
        {
            noteProcess.ProcessNote(3);
        }
        if (Input.GetKeyDown(key4))
        {
            noteProcess.ProcessNote(4);
        }
    }
}
