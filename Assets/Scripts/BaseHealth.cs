using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
	//Parameters
	[SerializeField] int baseHP = 10;
	[SerializeField] Text hpDisplay;

	private void Start()
	{
		hpDisplay.text = "HP: " + baseHP.ToString();
	}

	public void decreaseHP()
	{
		baseHP -= 1;
		hpDisplay.text = "HP: " + baseHP.ToString();

		if (baseHP <= 0)
		{
			//Gameover screen
			print("Game Over");
		}
	}
}