using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;

    private int currentScoreAmount;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScoreAmount;
    }

    public void AddScore(int scoreAmount)
    {
        currentScoreAmount += scoreAmount;
        UpdateScoreText();
    }

    public int GetScoreAmount()
    {
        return currentScoreAmount;
    }
}
