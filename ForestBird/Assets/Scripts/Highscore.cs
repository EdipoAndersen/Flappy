using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public static Highscore instance;
    [SerializeField] public SoundManager soundManager;
    [SerializeField] private Text scorePoints;
    [SerializeField] private Text bestPoints;

    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        scorePoints.text = score.ToString();
        bestPoints.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        UpdateBestscore();
    }

    private void UpdateBestscore()
    {
        if (score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);
            bestPoints.text = score.ToString();
        }
    }

    public void UpdateScore()
    {
        soundManager.IncreaseScore();
        score++;
        scorePoints.text = score.ToString();
        UpdateBestscore();
    }

}
