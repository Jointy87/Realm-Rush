using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	//Parameters
	[SerializeField] int healthPoints;
	[SerializeField] int pointsWorth;
	[SerializeField] ParticleSystem hitFX;
	[SerializeField] ParticleSystem deathFX;

	bool isAlive = true;
	GameObject fxParent;

	private void Start()
	{
		fxParent = GameObject.Find("Spawned At Runtime");
	}

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
			ScoreHandler sh = FindObjectOfType<ScoreHandler>();
			sh.addToScore(pointsWorth);
		}
	}

	public void ProcessDestruction()
	{
		TriggerDeathFX();
		Destroy(gameObject);
	}

	private void TriggerDeathFX()
	{
		ParticleSystem deathExplosion = Instantiate(deathFX, transform.position, Quaternion.identity);
		deathExplosion.transform.parent = fxParent.transform;
	}

	private void TriggerHitFX()
	{
		ParticleSystem hitSparks = Instantiate(hitFX, transform.position, Quaternion.identity);
		hitSparks.transform.parent = fxParent.transform;
	}
}
