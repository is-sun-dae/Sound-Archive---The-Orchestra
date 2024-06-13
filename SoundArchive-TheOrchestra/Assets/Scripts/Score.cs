using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int songScore;

    [SerializeField] private TextMeshProUGUI rankText;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        rankText.text = "";

        songScore = 0;
    }

    public void ProcessScore(int rank)
    {
        if (rank.Equals(5))
        {
            rankText.text = "PERFECT";
        }
        else if (rank.Equals(4))
        {
            rankText.text = "GREAT";
        }
        else if (rank.Equals(3))
        {
            rankText.text = "GOOD";
        }
        else if (rank.Equals(2))
        {
            rankText.text = "BAD";
        }
        else if (rank.Equals(1))
        {
            rankText.text = "MISS";
        }
    }
}
