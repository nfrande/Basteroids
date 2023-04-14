using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI instance;

    [SerializeField] TextMeshProUGUI scoreText;

    public int lives = 3;
    public int score = 0;

    [SerializeField] Image Life1;
    [SerializeField] Image Life2;
    [SerializeField] Image Life3;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScore(int scoreChange)
    {
        score += scoreChange;
        scoreText.text = score.ToString();
    }

    public void UpdateLives(int livesChange)
    {
        lives += livesChange;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 2)
        {
            Life3.enabled = false;
        }

        if (lives == 1)
        {
            Life2.enabled = false;
        }

        if (lives == 0)
        {
            Life1.enabled = false;
        }
    }
}
