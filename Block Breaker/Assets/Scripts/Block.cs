using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject impactEffect;
    [SerializeField] int maxHits;

    // State
    [SerializeField] int timesHit;      // TODO deserialize when done debugging

    // Cached References
    Level level;

    void Start()
	{
		CountBreakableBlocks();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
        if (gameObject.CompareTag("Breakable"))
		{
			HandleHit();
		}
	}

	private void HandleHit()
	{
		timesHit++;
		if (timesHit >= maxHits)
			DestroyBlock();
	}

	private void CountBreakableBlocks()
	{
		level = FindObjectOfType<Level>();
		if (gameObject.CompareTag("Breakable"))
			level.CountBlocks();
	}

	private void DestroyBlock()
	{
        FindObjectOfType<GameSession>().AddToScore();
		AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        TriggerImpactEffect();
		Destroy(gameObject);
		level.BlockDestroyed();
	}

    private void TriggerImpactEffect()
    {
        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
    }
}
