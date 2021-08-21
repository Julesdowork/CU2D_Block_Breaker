using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject impactEffect;

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
