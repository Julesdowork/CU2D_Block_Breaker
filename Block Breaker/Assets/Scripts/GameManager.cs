using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Configuration Parameters
    [Range(0.25f, 4f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;

    // State
    [SerializeField] int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = gameSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }
}