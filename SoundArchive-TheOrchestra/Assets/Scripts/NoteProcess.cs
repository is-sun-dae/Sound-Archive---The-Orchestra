using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteProcess : MonoBehaviour
{
    private Sheet sheet;
    private Score score;
    private SongManager songManager;

    private float currentTime;
    private float currentNoteTime1;
    private float currentNoteTime2;
    private float currentNoteTime3;
    private float currentNoteTime4;

    private float perfectRate = 3.0f;
    private float greatRate = 7.0f;
    private float goodRate = 10.0f;
    private float missRate = 14.0f;

    private int lineNum;

    private Queue<float> processLane1 = new Queue<float>();
    private Queue<float> processLane2 = new Queue<float>();
    private Queue<float> processLane3 = new Queue<float>();
    private Queue<float> processLane4 = new Queue<float>();

    private void Start()
    {
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
        SetQueue();
        score = GameObject.Find("Score").GetComponent<Score>();
        songManager = GameObject.Find("SongManager").GetComponent<SongManager>();
    }

    private void Update()
    {
        currentTime = songManager.music.timeSamples;

        if (processLane1.Count > 0)
        {
            currentNoteTime1 = processLane1.Peek();
            currentNoteTime1 = currentNoteTime1 * 0.001f * songManager.music.clip.frequency;
        }
        
        if (processLane2.Count > 0)
        {
            currentNoteTime2 = processLane2.Peek();
            currentNoteTime2 = currentNoteTime2 * 0.001f * songManager.music.clip.frequency;
        }
        
        if (processLane3.Count > 0)
        {
            currentNoteTime3 = processLane3.Peek();
            currentNoteTime3 = currentNoteTime3 * 0.001f * songManager.music.clip.frequency;
        }
        
        if (processLane4.Count > 0)
        {
            currentNoteTime4 = processLane4.Peek();
            currentNoteTime4 = currentNoteTime4 * 0.001f * songManager.music.clip.frequency;
        }
    }

    public void ProcessNote(int laneNum)
    {
        lineNum = laneNum;

        if (lineNum.Equals(1))
        {
            if (Mathf.Abs(currentNoteTime1 - currentTime) <= perfectRate)
            {
                processLane1.Dequeue();
                score.ProcessScore(4);
            }
            else if (Mathf.Abs(currentNoteTime1 - currentTime) <= greatRate)
            {
                processLane1.Dequeue();
                score.ProcessScore(3);
            }
            else if (Mathf.Abs(currentNoteTime1 - currentTime) <= goodRate)
            {
                processLane1.Dequeue();
                score.ProcessScore(2);
            }
            else if (currentNoteTime1 + missRate <= currentTime)
            {
                processLane1.Dequeue();
                score.ProcessScore(1);
            }
        }
        
        if (lineNum.Equals(2))
        {
            if (Mathf.Abs(currentNoteTime2 - currentTime) <= perfectRate)
            {
                processLane2.Dequeue();
                score.ProcessScore(4);
            }
            else if (Mathf.Abs(currentNoteTime2 - currentTime) <= greatRate)
            {
                processLane2.Dequeue();
                score.ProcessScore(3);
            }
            else if (Mathf.Abs(currentNoteTime2 - currentTime) <= goodRate)
            {
                processLane2.Dequeue();
                score.ProcessScore(2);
            }
            else if (currentNoteTime2 + missRate <= currentTime)
            {
                processLane2.Dequeue();
                score.ProcessScore(1);
            }
        }
        
        if (lineNum.Equals(3))
        {
            if (Mathf.Abs(currentNoteTime3 - currentTime) <= perfectRate)
            {
                processLane3.Dequeue();
                score.ProcessScore(4);
            }
            else if (Mathf.Abs(currentNoteTime3 - currentTime) <= greatRate)
            {
                processLane3.Dequeue();
                score.ProcessScore(3);
            }
            else if (Mathf.Abs(currentNoteTime3 - currentTime) <= goodRate)
            {
                processLane3.Dequeue();
                score.ProcessScore(2);
            }
            else if (currentNoteTime3 + missRate <= currentTime)
            {
                processLane3.Dequeue();
                score.ProcessScore(1);
            }
        }
        
        if (lineNum.Equals(4))
        {
            if (Mathf.Abs(currentNoteTime4 - currentTime) <= perfectRate)
            {
                processLane4.Dequeue();
                score.ProcessScore(4);
            }
            else if (Mathf.Abs(currentNoteTime4 - currentTime) <= greatRate)
            {
                processLane4.Dequeue();
                score.ProcessScore(3);
            }
            else if (Mathf.Abs(currentNoteTime4 - currentTime) <= goodRate)
            {
                processLane4.Dequeue();
                score.ProcessScore(2);
            }
            else if (currentNoteTime4 + missRate <= currentTime)
            {
                processLane4.Dequeue();
                score.ProcessScore(1);
            }
        }
    }

    private void SetQueue()
    {
        foreach (float noteTime in sheet.noteList1)
            processLane1.Enqueue(noteTime + 100);
        foreach (float noteTime in sheet.noteList2)
            processLane2.Enqueue(noteTime + 100);
        foreach (float noteTime in sheet.noteList3)
            processLane3.Enqueue(noteTime + 100);
        foreach (float noteTime in sheet.noteList4)
            processLane4.Enqueue(noteTime + 100);
    }
}
