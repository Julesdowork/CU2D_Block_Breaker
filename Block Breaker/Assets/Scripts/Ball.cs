using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    // State
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cached References
    AudioSource audioSource;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();

        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
	{
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0, randomFactor), Random.Range(0, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);
            rb.velocity += velocityTweak;
        }
    }

	private void LockBallToPaddle()
	{
		Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
		transform.position = paddlePos + paddleToBallVector;
	}

	private void LaunchOnMouseClick()
	{
		if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
	}
}
