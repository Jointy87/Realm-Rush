using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
	//Config parameters
	[SerializeField] Text scoreDisplay;

	//Cache
	int totalPoints;

	private void Start()
	{
		totalPoints = 0;
		scoreDisplay.text = "Score: " + totalPoints;
	}

	public void addToScore(int pointsWorth)
	{
		totalPoints += pointsWorth;
		scoreDisplay.text = "Score: " + totalPoints;
	}
}
