using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerText : MonoBehaviour 
{
	float seconds = 120;

	private GameObject player1;
	private GameObject player2;

	void Start()
	{
		player1 = GameObject.FindGameObjectWithTag ("Player");
		player2 = GameObject.FindGameObjectWithTag ("Player 2");
	}

	void Update()
	{
		if (seconds < 0) {
			this.GetComponent<Text>().text = "Game Over- The player with the higher score wins!";
			player1.SetActive (false);
			player2.SetActive (false);
			
		} else {
			if (seconds < 10) 
				this.GetComponent<Text>().color = Color.red;
			this.GetComponent<Text>().text = "Time: " + seconds;
		}
	}

	void FixedUpdate()
	{
		seconds = (int)(120 - Time.timeSinceLevelLoad);

	}
}
