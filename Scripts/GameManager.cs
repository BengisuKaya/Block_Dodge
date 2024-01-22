using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;
    public GameObject tapText;
    public TextMeshProUGUI scoreText;
    int score = -1;

    bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted)
        {
                        
            tapText.SetActive(false);
            gameStarted = true;
            StartSpawning();
        }
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnBlocks", 0.05f , spawnRate);
    }

    void SpawnBlocks()
    {
        Vector3 spawnPosition = spawnPoint.position;
        spawnPosition.x = Random.Range(-maxX, maxX);
        Instantiate(block, spawnPosition, Quaternion.identity);
        score++;
        scoreText.text = score.ToString();
    }
}
