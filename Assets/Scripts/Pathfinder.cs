﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
	//Parameters
	[SerializeField] Waypoint startWaypoint, endWaypoint;
	
	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	Queue<Waypoint> waypointQueue = new Queue<Waypoint>();
	
	//Cache
	bool isRunning = true;
	bool startWaypointFound = false;
	Waypoint searchCenter;
	private List<Waypoint> path = new List<Waypoint>();

	Vector2Int[] directions = 
		{
			Vector2Int.up,
			Vector2Int.right,
			Vector2Int.down,
			Vector2Int.left
		};

	public List<Waypoint> FetchPath()
	{
		if(path.Count == 0)
		{
			LoadBlocks();
			BreadthFirstSearch();
			CreatePath();
		}

		return path;
	}

	private void LoadBlocks()
	{
		Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
		foreach (Waypoint waypoint in waypoints)
		{
			var gridPos = waypoint.FetchGridPos();

			if (grid.ContainsKey(gridPos))
			{
				Debug.LogWarning("Overlapping block " + waypoint);
			}
			else
			{
				grid.Add(gridPos, waypoint);
			}
		}
	}
	
	private void BreadthFirstSearch()
	{
		waypointQueue.Enqueue(startWaypoint);
		
		while(waypointQueue.Count > 0 && isRunning)			
		{
			searchCenter = waypointQueue.Dequeue(); //Dequeued waypoint gets named searchcenter
			searchCenter.isExplored = true;

			HaltIfEndFound();

			ExploreNeightbours();
		}
	}

	private void HaltIfEndFound()
	{
		if (searchCenter.FetchGridPos() == endWaypoint.FetchGridPos())
		{
			isRunning = false;
		}
	}

	private void ExploreNeightbours()
	{
		if(!isRunning) { return; }

		foreach (Vector2Int direction in directions)
		{
			Vector2Int neighbourCoordinates = searchCenter.FetchGridPos() + direction;

			if(grid.ContainsKey(neighbourCoordinates))
			{
				QueueNeighbours(neighbourCoordinates);
			}
		}
	}

	private void QueueNeighbours(Vector2Int neighbourCoordinates)
	{
		Waypoint neighbour = grid[neighbourCoordinates];

		if (neighbour.isExplored || waypointQueue.Contains(neighbour)) { return; }

		waypointQueue.Enqueue(neighbour);
		//print("Queueing " + neighbour);

		SaveOrigin(neighbour);
	}

	private void SaveOrigin(Waypoint neighbour)
	{
		neighbour.exploredFrom = searchCenter;
	}
	private void CreatePath()
	{
		SetAsPath(endWaypoint);

		Waypoint previous = endWaypoint.exploredFrom;

		while (previous != startWaypoint)
		{
			SetAsPath(previous);
			previous = previous.exploredFrom;
		}

		SetAsPath(startWaypoint);
		path.Reverse();
	}

	private void SetAsPath(Waypoint waypoint)
	{
		path.Add(waypoint);
		waypoint.isPlaceable = false;
	}

	public Waypoint FetchStartWaypoint()
	{
		return startWaypoint;
	}
	public Waypoint FetchEndWaypoint()
	{
		return endWaypoint;
	}

}
