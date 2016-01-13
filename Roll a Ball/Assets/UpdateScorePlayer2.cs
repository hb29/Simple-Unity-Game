using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateScorePlayer2 : MonoBehaviour 
{

	private GameObject player2;
	
	void Start()
	{
		player2 = GameObject.FindGameObjectWithTag ("Player 2");
	}
	
	void Update()
	{
		int score = player2.GetComponent<PlayerController> ().count;
		GetComponent<Text> ().text = "Count: " + score;
	}
}
