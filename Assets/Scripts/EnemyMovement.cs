using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] float moveSpeed = 1f;
	private void Start()
	{
		Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
		List<Waypoint> path = pathfinder.FetchPath();
		StartCoroutine(FollowPath(path));
	}

	
	IEnumerator FollowPath(List<Waypoint> path)
	{
		//print("Starting patrol");
		foreach (Waypoint waypoint in path)
		{
			transform.position = waypoint.transform.position;
			//print("On Block: " + waypoint.gameObject.name);
			yield return new WaitForSeconds(moveSpeed);
		}
		//print("ending patrol");
	}

	private void OnTriggerEnter(Collider other)
	{
		Destroy(other); 
	}

}
