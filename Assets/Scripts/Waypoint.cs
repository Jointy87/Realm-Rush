using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
	//Parameters
	[SerializeField] Tower towerPrefab;
	const int gridSize = 10;

	//public is ok here as this is a data class 
	public bool isExplored = false;
	public Waypoint exploredFrom;
	public bool isPlaceable = true;
	private bool hasTower = false;

	public int FetchGridSize()
	{
		return gridSize;
	}

	public Vector2Int FetchGridPos()
	{
		return new Vector2Int
			(Mathf.RoundToInt(transform.position.x / gridSize),
			Mathf.RoundToInt(transform.position.z / gridSize));
	}

	public Waypoint FetchOrigin()
	{
		return exploredFrom;
	}

	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0) && isPlaceable && hasTower == false)
		{
			Tower towerToSpawn = Instantiate(towerPrefab, transform.position, Quaternion.identity);
			hasTower = true;
		}

	}
}
