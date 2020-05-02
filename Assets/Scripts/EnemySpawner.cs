using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	//Parameters
	[SerializeField] float spawnInterval;
	[SerializeField] GameObject enemyToSpawn;
	
	bool isRunning = true;
	void Start()
	{
		while (isRunning)
		{
			StartCoroutine(SpawnEnemies());
		}
	}

	IEnumerator SpawnEnemies()
	{
		yield return new WaitForSeconds(spawnInterval);
		GameObject enemySpawned = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
	}
}
