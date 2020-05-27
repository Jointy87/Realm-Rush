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
	float distToA;
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
			closestEnemy = GetClosestEnemy(closestEnemy, enemy.transform);
		}

		targetEnemy = closestEnemy;
	}

	private Transform GetClosestEnemy(Transform transA, Transform transB)
	{
		var distToA = Vector3.Distance(transA.position, transform.position);
		var distToB = Vector3.Distance(transB.transform.position, transform.position);

		if (distToB < distToA)
		{
			return transB;
		}
		else
		{
			return transA;
		}
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
		float distanceToClosestEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);

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
