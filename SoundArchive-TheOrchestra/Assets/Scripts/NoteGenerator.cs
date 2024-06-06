using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    private Sheet sheet;

    public GameObject notePrefab;
    
    private float noteCorrectRate = 0.001f;

    private float notePosY;
    private float noteStartPosY;
    private float offset;
    public float scrollSpeed;

    public bool isGenFin;

    private void Start()
    {
        scrollSpeed = 17f;
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
        notePosY = scrollSpeed;
        noteStartPosY = scrollSpeed * 3.0f;
    }

    private void Update()
    {
        if (isGenFin.Equals(false))
        {
            GenNote();
            isGenFin = true;
        }
    }

    private void GenNote()
    {
        GenNoteList(sheet.noteList1, notePrefab, new Vector3(-1.5f, 0, 0));
        GenNoteList(sheet.noteList2, notePrefab, new Vector3(-0.5f, 0, 0));
        GenNoteList(sheet.noteList3, notePrefab, new Vector3(0.5f, 0, 0));
        GenNoteList(sheet.noteList4, notePrefab, new Vector3(1.5f, 0, 0));
    }

    private void GenNoteList(List<float> noteList, GameObject notePrefab, Vector3 positionOffset)
    {
        float posY;
        foreach (float noteTime in noteList)
        {
            posY = noteStartPosY + notePosY * (noteTime * noteCorrectRate) + positionOffset.y;
            Instantiate(notePrefab, new Vector3(positionOffset.x, posY, positionOffset.z), Quaternion.identity);
        }
    }
}
