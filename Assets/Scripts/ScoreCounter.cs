using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static int scoreValue = 0;
    private Text scoreText;
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "Score: " + scoreValue + "/" + EnemySpawner.numOfEnemies;
    }
}
