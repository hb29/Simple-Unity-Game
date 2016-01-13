using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour 
{
	private GameObject player1;

	void Start()
	{
		player1 = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update()
	{
		int score = player1.GetComponent<PlayerController> ().count;
		this.GetComponent<Text> ().text = "Count: " + score;
	}

}
