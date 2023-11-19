using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HightScore : MonoBehaviour
{
    static public int score = 1000;

    // Оновлення викликається один раз на кадр
    private void Awake()
    {
        if (PlayerPrefs.HasKey("HightScore"))
        {
            score = PlayerPrefs.GetInt("HightScore");
        }
        PlayerPrefs.SetInt("HighScore", score);
    }

    // Оновлення викликається один раз на кадр
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "HightScore: " + score;
        if (score > PlayerPrefs.GetInt("HightScore"))
            PlayerPrefs.SetInt("HightScore", score);
    }

}