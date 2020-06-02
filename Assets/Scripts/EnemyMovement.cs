using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	//Parameters
	[SerializeField] float moveSpeed = 1f;

	//Cache
	BaseHealth baseHP;

	private void Awake()
	{
		baseHP = FindObjectOfType<BaseHealth>();
	}
	private void Start()
	{ 
		Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
		var path = pathfinder.FetchPath();
		StartCoroutine(FollowPath(path));
	}

	IEnumerator FollowPath(List<Waypoint> path)
	{
		foreach (Waypoint waypoint in path)
		{
			transform.position = new Vector3(waypoint.transform.position.x, waypoint.transform.position.y + 3, waypoint.transform.position.z);
			yield return new WaitForSeconds(moveSpeed);
		}

		EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
		enemyHealth.ProcessDestruction();
		baseHP.decreaseHP();
	}
}
