using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    public int score = 0;
    public Text score_txt;
    public Text highscore_txt;

    int highscore;

    private void Start()
    {
        if(PlayerPrefs.HasKey("highscore"))
        {
            highscore = PlayerPrefs.GetInt("highscore");
        }
        else
        {
            highscore = 0;
        }

        highscore_txt.text = highscore.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("obstacle"))
        {
            score++;
            score_txt.text = score.ToString();

            if(score > highscore)
            {
                highscore = score;
                PlayerPrefs.SetInt("highscore", highscore);
                highscore_txt.text = highscore.ToString();
            }
        }
    }
}
