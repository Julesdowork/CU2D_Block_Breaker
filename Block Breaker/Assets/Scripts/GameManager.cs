using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Configuration Parameters
    [Range(0.25f, 4f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    // State
    [SerializeField] int currentScore = 0;

    void Awake()
    {
        int gameManagerCount = FindObjectsOfType<GameManager>().Length;
        if (gameManagerCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = gameSpeed;
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
}
