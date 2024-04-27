using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TMP_Text MyscoreText;
    private int ScoreNum;
    void Start()
    {
        ScoreNum = 000;
        MyscoreText.text = "Score : " + ScoreNum;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            ScoreNum += 100;
            Destroy(other.gameObject);
            MyscoreText.text = "Score : " + ScoreNum;
        }
    }
}
