using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerLivesText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ballsLeftText;

    private void Start()
    {
        FailZone.Instance.OnBallDestroyed += FailZone_OnBallDestroyed;
        FailZone.Instance.OnLifePickedup += FailZone_OnLifePickedup;

        UpdateText();
    }

    private void UpdateText()
    {
        ballsLeftText.text = "Lives: " + FailZone.Instance.GetBallsLivesLeft();
    }

    private void FailZone_OnBallDestroyed(object sender, EventArgs e)
    {
        UpdateText();
    }

    private void FailZone_OnLifePickedup(object sender, EventArgs e)
    {
        UpdateText();
    }
}
