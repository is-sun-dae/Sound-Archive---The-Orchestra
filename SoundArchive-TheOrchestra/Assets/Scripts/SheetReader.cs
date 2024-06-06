using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SheetReader : MonoBehaviour
{
    private TextAsset textAsset;
    private StringReader strReader;

    private Sheet sheet;
    private SongManager songManager;

    private string sheetText = "";
    private string songName;
    private string[] textSplit;

    private void Awake()
    {
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
        songManager = GameObject.Find("SongManager").GetComponent<SongManager>();

        songName = songManager.songName;
        textAsset = Resources.Load(songName + "/" + songName + "_data") as TextAsset;
        strReader = new StringReader(textAsset.text);
        
        ReadSheet();
    }

    public void ReadSheet()
    {
        int laneNumber;
        float noteTime;

        sheetText = strReader.ReadLine();

        while (sheetText != null)
        {
            textSplit = sheetText.Split('=');

            if (sheetText == "[HitObjects]")
            {
                sheetText = strReader.ReadLine();

                while (sheetText != null && !sheetText.StartsWith("["))
                {
                    textSplit = sheetText.Split(',');

                    int.TryParse(textSplit[0], out laneNumber);
                    float.TryParse(textSplit[2], out noteTime);

                    if (laneNumber == 64) laneNumber = 1;
                    else if (laneNumber == 192) laneNumber = 2;
                    else if (laneNumber == 320) laneNumber = 3;
                    else if (laneNumber == 448) laneNumber = 4;
                    
                    sheet.SetNote(laneNumber, noteTime);

                    sheetText = strReader.ReadLine();
                }
            }

            sheetText = strReader.ReadLine();
        }
    }
}
