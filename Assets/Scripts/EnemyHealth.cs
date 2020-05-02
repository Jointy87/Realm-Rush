using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	//Parameters
	[SerializeField] int healthPoints;
	[SerializeField] ParticleSystem hitFX;
	[SerializeField] ParticleSystem deathFX;

	bool isAlive = true;

	private void Update()
	{
		if (isAlive)
		{
			CheckForDestruction();
		}
	}
	private void OnParticleCollision(GameObject other)
	{
		healthPoints--;
		TriggerHitFX();
	}

	private void CheckForDestruction()
	{
		if(healthPoints <= 0)
		{
			ProcessDestruction();
			isAlive = false;
		}
	}

	private void ProcessDestruction()
	{
		TriggerDeathFX();
		Destroy(gameObject);
	}

	private void TriggerDeathFX()
	{
		ParticleSystem deathExplosion = Instantiate(deathFX, transform.position, Quaternion.identity);
		Destroy(deathExplosion.gameObject, 1f);
	}

	private void TriggerHitFX()
	{
		ParticleSystem hitSparks = Instantiate(hitFX, transform.position, Quaternion.identity);
		Destroy(hitSparks.gameObject, 1f);
	}
}
