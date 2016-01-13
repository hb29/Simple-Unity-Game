using UnityEngine;
using System.Collections;

public class RestartScript : MonoBehaviour 
{	void Start () 
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}