using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float maxMoveSpeed = 25f;
    [SerializeField] private float movementSpeedIncrement = 0.1f;

    private Vector3 movementDirection;
    private float startMovingAfterSeconds = 3f;
    private bool startMoving;

    private void Update()
    {
        startMovingAfterSeconds -= Time.deltaTime;

        if (startMovingAfterSeconds < 0 && !startMoving)
        {
            movementDirection = Vector3.down;
            startMoving = true;
        }

        transform.position += movementDirection * moveSpeed * Time.deltaTime;
    }

    private void IncrementSpeed()
    {
        moveSpeed += movementSpeedIncrement;

        if (moveSpeed > maxMoveSpeed)
        {
            moveSpeed = maxMoveSpeed;
        }
    }

    private void BallMovementDirection(Collider2D other)
    {
        if (other.CompareTag("Paddle") || other.CompareTag("Brick"))
        {
            movementDirection = (transform.position - other.transform.position).normalized;
        }
        if (other.CompareTag("TopWall"))
        {
            movementDirection = new Vector3(movementDirection.x, -movementDirection.y, 0);
        }
        if (other.CompareTag("LeftWall"))
        {
            movementDirection = new Vector3(-movementDirection.x, movementDirection.y, 0);
        }
        if (other.CompareTag("RightWall"))
        {
            movementDirection = new Vector3(-movementDirection.x, movementDirection.y, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        BallMovementDirection(other);

        IncrementSpeed();

        if (other.CompareTag("FailZone"))
        {
            Destroy(gameObject);
        }
    }

    public void SetMovementDirection(Vector3 newMovementDirection)
    {
        movementDirection = newMovementDirection;
        startMoving = true;
    }
}
