using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] Vector2 screenBounds;

    // Cached References
    GameSession gameSession;
    Ball ball;


    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), screenBounds.x, screenBounds.y);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (gameSession.IsAutoplaying())
            return ball.transform.position.x;
        else
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    }
}
