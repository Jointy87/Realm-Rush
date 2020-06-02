using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
	//Config parameters
	[SerializeField] public Tower towerPrefab;
	[SerializeField] int towerLimit = 5;

	Queue<Tower> towerQueue = new Queue<Tower>();

	public void AddTower(Waypoint waypoint)
	{
		//read amount of towers in-game from queue instead of towersSpawned
		if(towerQueue.Count < towerLimit)
		{
			SpawnTower(waypoint);
		}
		else
		{
			MoveOldestTower(waypoint);
		}

	}
	private void SpawnTower(Waypoint waypoint)
	{
		Tower towerToSpawn = Instantiate(towerPrefab, waypoint.transform.position, Quaternion.identity);
		towerQueue.Enqueue(towerToSpawn);
		towerToSpawn.myWaypoint = waypoint;
	}

	private void MoveOldestTower(Waypoint waypoint)
	{
		Tower oldestTower = DequeueTower();
		QueueAndMoveTower(waypoint, oldestTower);
	}

	private Tower DequeueTower()
	{
		Tower oldestTower = towerQueue.Dequeue();
		oldestTower.myWaypoint.isPlaceable = true;
		return oldestTower;
	}

	private void QueueAndMoveTower(Waypoint waypoint, Tower oldestTower)
	{
		oldestTower.transform.position = waypoint.transform.position;
		towerQueue.Enqueue(oldestTower);
		oldestTower.myWaypoint = waypoint;
		oldestTower.myWaypoint.isPlaceable = false;
	}
}
