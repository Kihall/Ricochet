using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOtherBallsPickup : BasePickup
{
    [SerializeField] private Transform ballPrefab;

    protected override void Pickup()
    {
        Transform mainBallTransform = GameObject.FindGameObjectWithTag("Ball").transform;

        int howMuchBallToSpawn = 3;

        for (int i = 0; i < howMuchBallToSpawn; i++)
        {
            Transform ballPrefabTransform = Instantiate(ballPrefab, mainBallTransform.transform.position + new Vector3(-0.2f + (i * 0.2f), 0.2f, 0), Quaternion.identity);

            BallBehaviour ball = ballPrefabTransform.GetComponent<BallBehaviour>();

            FailZone.Instance.AddBallToList(ball);

            ball.SetMovementDirection((ball.transform.position - mainBallTransform.transform.position).normalized);
        }
    }
}
