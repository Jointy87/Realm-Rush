using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	//Parameters
	[SerializeField] Transform towerTurret;
	[SerializeField] Transform targetEnemy;
	[SerializeField] ParticleSystem bulletEmitter;
	[SerializeField] float attackRange;

	bool isShooting = false;

	void Update()
	{
		LookAtEnemy();
		CheckRange();
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

		float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, transform.position);

		if(distanceToEnemy <= attackRange)
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
