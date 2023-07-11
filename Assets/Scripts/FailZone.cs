using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailZone : MonoBehaviour
{
    public static FailZone Instance { get; private set; }

    public event EventHandler OnBallDestroyed;
    public event EventHandler OnLifePickedup;

    [SerializeField] private Transform ballPrefab;

    private List<BallBehaviour> ballsList = new List<BallBehaviour>();
    private int ballsLiveLeft = 3;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        BallBehaviour ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallBehaviour>();
        AddBallToList(ball);
    }

    private void DecreaseLivesLeft()
    {
        ballsLiveLeft -= 1;

        if (ballsLiveLeft < 0)
        {
            ballsLiveLeft = 0;
        }

        if (ballsLiveLeft == 0)
        {
            GameOverUI.Instance.Show();
        }
    }

    public void GetExtraLife(int lifeAmount)
    {
        ballsLiveLeft += lifeAmount;

        OnLifePickedup?.Invoke(this, EventArgs.Empty);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        BallBehaviour ball = other.GetComponent<BallBehaviour>();
        if (ball != null)
        {
            ballsList.Remove(ball);
            if (ballsList.Count <= 0)
            {
                DecreaseLivesLeft();
                OnBallDestroyed?.Invoke(this, EventArgs.Empty);
                Transform ballPrefabTransform = Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                AddBallToList(ballPrefabTransform.GetComponent<BallBehaviour>());
            }
            Destroy(ball);
        }
    }

    public void AddBallToList(BallBehaviour ball)
    {
        ballsList.Add(ball);
    }

    public int GetBallsLivesLeft()
    {
        return ballsLiveLeft;
    }
}
