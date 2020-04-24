using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	private void Start()
	{
		Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
		List<Waypoint> path = pathfinder.FetchPath();
		StartCoroutine(FollowPath(path));
	}

	
	IEnumerator FollowPath(List<Waypoint> path)
	{
		print("Starting patrol");
		foreach (Waypoint waypoint in path)
		{
			transform.position = waypoint.transform.position;
			print("On Block: " + waypoint.gameObject.name);
			yield return new WaitForSeconds(0.5f);
		}
		print("ending patrol");
	}

}
