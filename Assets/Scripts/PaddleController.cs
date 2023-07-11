using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private float maximumMovementSpaceX = 6f;
    private bool isSticky;

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -maximumMovementSpaceX, maximumMovementSpaceX), transform.position.y, 0);

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
