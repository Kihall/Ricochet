using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePickup : MonoBehaviour
{
    private void Update()
    {
        float moveSpeed = 2f;
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PaddleController paddle = other.GetComponent<PaddleController>();
        if (paddle != null)
        {
            Pickup();
            Destroy(gameObject);
        }

        FailZone failZone = other.GetComponent<FailZone>();
        if (failZone != null)
        {
            Destroy(gameObject);
        }
    }

    protected abstract void Pickup();
}
