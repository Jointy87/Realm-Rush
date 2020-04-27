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

	bool isShooting = false;

	void Update()
	{
		LookAtEnemy();
		Shoot();
	}

	private void Shoot()
	{
		var bulletEmissionModule = bulletEmitter.emission;

		if (isShooting)
		{
			bulletEmissionModule.enabled = true;
		}
		else
		{
			bulletEmissionModule.enabled = false;
		}
	}

	private void LookAtEnemy()
	{
		towerTurret.LookAt(targetEnemy)	;
	}

	private void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			isShooting = true;
		}
	}
}
