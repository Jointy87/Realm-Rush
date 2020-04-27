using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
	//Parameters
	[SerializeField] Color startColor;
	[SerializeField] Color endColor;
	[SerializeField] Color exploredColor;
	const int gridSize = 10;

	//public is ok here as this is a data class 
	public bool isExplored = false;
	public Waypoint exploredFrom;

	//Cache
	MeshRenderer topMeshRenderer;
	Pathfinder pathfinder;
	private void Start()
	{
		pathfinder = FindObjectOfType<Pathfinder>();
	}
	private void Update()
	{
		//ColorWaypointsAccordingly();
	}

	//private void ColorWaypointsAccordingly()
	//{
	//	if (this == pathfinder.FetchStartWaypoint())
	//	{
	//		SetTopColor(startColor);
	//	}
	//	else if (this == pathfinder.FetchEndWaypoint())
	//	{
	//		SetTopColor(endColor);
	//	}
	//	else if (isExplored)
	//	{
	//		SetTopColor(exploredColor);
	//	}
	//}

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

	//public void SetTopColor(Color color)
	//{
	//	topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
	//	topMeshRenderer.material.color = color;
	//}

	public Waypoint FetchOrigin()
	{
		return exploredFrom;
	}
}
