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
		foreach (Waypoint waypoint in path)
		{
			transform.position = waypoint.transform.position;
			yield return new WaitForSeconds(moveSpeed);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Destroy(other); 
	}

}
