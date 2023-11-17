using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HightScore : MonoBehaviour
{
    static public int score = 1000;
    // Update is called once per frame
    private void Awake()
    {
        if (PlayerPrefs.HasKey("HightScore"))
        {
            score = PlayerPrefs.GetInt("HightScore");
        }
        PlayerPrefs.SetInt("HighScore", score);
    }
    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "HightScore: " + score;
        if (score > PlayerPrefs.GetInt("HightScore"))
            PlayerPrefs.SetInt("HightScore", score);
    }
}
