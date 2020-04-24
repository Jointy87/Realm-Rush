using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]

public class CubeEditor : MonoBehaviour
{
	//Cache
	Waypoint waypoint;

	private void Awake()
	{
		waypoint = GetComponent<Waypoint>();
	}

	void Update()
	{
		SnapToGrid();
		ShowCubeCoordinates();
	}



	private void SnapToGrid()
	{
		transform.position = new Vector3
			(waypoint.FetchGridPos().x * waypoint.FetchGridSize(), 0, 
			waypoint.FetchGridPos().y * waypoint.FetchGridSize());
	}
	private void ShowCubeCoordinates()
	{
		TextMesh labelTextMesh = GetComponentInChildren<TextMesh>();
		int gridSize = waypoint.FetchGridSize();
		labelTextMesh.text = waypoint.FetchGridPos().x + "," + waypoint.FetchGridPos().y;
		gameObject.name = labelTextMesh.text;
	}
}
