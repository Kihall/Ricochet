using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public static BrickSpawner Instance { get; private set; }

    [Range(1, 8)]
    [SerializeField] private int brickCountX;
    [Range(1, 8)]
    [SerializeField] private int brickCountY;

    [SerializeField] private List<Transform> brickPrefabs;
    [SerializeField] private Color[] colors;

    private List<Brick> bricksList = new List<Brick>();

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (bricksList.Count == 0)
        {
            GameOverUI.Instance.Show();
        }
    }

    private void Start()
    {
        SpawnBricks();
    }

    private void SpawnBricks()
    {
        int colorId = 0;

        for (int y = 0; y < brickCountY; y++)
        {
            for (int x = -(brickCountX / 2); x < (brickCountX / 2); x++)
            {
                Vector3 pos = new Vector3(0.8f + (x * 1.6f), 1 + (y * 0.4f), 0);
                Transform brickTransform = Instantiate(brickPrefabs[Random.Range(0, brickPrefabs.Count)], pos, Quaternion.identity);
                Brick brick = brickTransform.GetComponent<Brick>();
                brick.GetSpriteRenderer().color = colors[colorId];
                bricksList.Add(brick);
            }

            colorId++;

            if (colorId == colors.Length)
                colorId = 0;
        }
    }

    public List<Brick> GetBricksList()
    {
        return bricksList;
    }
}
