using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	//Config parameters
	[SerializeField] Transform towerTurret;
	[SerializeField] ParticleSystem bulletEmitter;
	[SerializeField] float attackRange;

	//Cache
	bool isShooting = false;
	float distanceToClosestEnemy;

	//State
	Transform targetEnemy;

	void Update()
	{
		SetTargetEnemy();
		LookAtEnemy();
		CheckRange();
	}

	private void SetTargetEnemy()
	{
		var enemiesInScene = FindObjectsOfType<EnemyHealth>();
		if (enemiesInScene.Length == 0) { return; }

		Transform closestEnemy = enemiesInScene[0].transform;

		foreach(EnemyHealth enemy in enemiesInScene)
		{
			float distanceToClosestEnemy = Vector3.Distance(closestEnemy.transform.position, transform.position);
			float distanceToEnemy = Vector3.Distance(enemy.transform.position, transform.position);

			if(distanceToEnemy < distanceToClosestEnemy)
			{
				closestEnemy = enemy.transform;
			}
		}

		targetEnemy = closestEnemy;
	}
	private void LookAtEnemy()
	{
		towerTurret.LookAt(targetEnemy);
	}
	private void CheckRange()
	{
		if (!targetEnemy) 
		{
			Shoot(false);
			return; 
		}

		

		if(distanceToClosestEnemy <= attackRange)
		{
			Shoot(true);
		}
		else
		{
			Shoot(false);
		}
	}

	private void Shoot(bool isActive)
	{
		var bulletEmissionModule = bulletEmitter.emission;
		bulletEmissionModule.enabled = isActive;
	}


}
