using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    // Cached References
    Level level;

    void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    void OnCollisionEnter2D(Collision2D other)
	{
		DestroyBlock();
	}

	private void DestroyBlock()
	{
		AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
		Destroy(gameObject);
		level.BlockDestroyed();
        FindObjectOfType<GameManager>().AddToScore();
	}
}
