using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Brick : MonoBehaviour
{
    [SerializeField] private int brickLifeMax = 1;
    [SerializeField] private TextMeshProUGUI hitText;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BasePickup basePickupPrefab;

    private int brickLife;


    private void Start()
    {
        brickLife = brickLifeMax;

        UpdateText();
    }

    private void Damage()
    {
        brickLife -= 1;
        UpdateText();

        if (brickLife == 0)
        {
            if (basePickupPrefab != null)
            {
                Instantiate(basePickupPrefab, transform.position, Quaternion.identity);
            }
            ScoreManager.Instance.AddScore(brickLifeMax);
            BrickSpawner.Instance.GetBricksList().Remove(this);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        BallBehaviour ball = other.GetComponent<BallBehaviour>();
        if (ball != null)
        {
            Damage();
        }
    }

    private void UpdateText()
    {
        hitText.text = "" + brickLife;
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }
}
