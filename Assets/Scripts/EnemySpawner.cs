using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	//Parameters
	[SerializeField] float spawnInterval;
	[SerializeField] EnemyHealth enemyToSpawn;
	[SerializeField] AudioClip spawnSFX;

	void Start()
	{
		StartCoroutine(SpawnEnemies());
	}

	IEnumerator SpawnEnemies()
	{
		while (true) //Another way of saying forever
		{
			yield return new WaitForSeconds(spawnInterval);
			EnemyHealth enemySpawned = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
			enemySpawned.transform.parent = transform;
			GetComponent<AudioSource>().PlayOneShot(spawnSFX);

		}
	}
}
