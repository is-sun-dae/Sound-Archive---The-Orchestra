using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheet : MonoBehaviour
{
    public List<float> noteList1;
    public List<float> noteList2;
    public List<float> noteList3;
    public List<float> noteList4;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetNote(int lineNumber, float noteTime)
    {
        if (lineNumber == 1)
            noteList1.Add(noteTime);
        else if (lineNumber == 2)
            noteList2.Add(noteTime);
        else if (lineNumber == 3)
            noteList3.Add(noteTime);
        else if (lineNumber == 4)
            noteList4.Add(noteTime);
    }
}
