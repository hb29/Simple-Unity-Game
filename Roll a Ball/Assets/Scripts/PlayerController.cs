using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;

	public Text countText;

	public float jumpHeight;

	public bool playerJump;

	public bool isPlayer1 = true;

	public int count;

	public Text winText;

	public bool player1;

	public bool player2;

	private GameObject player1GO;
	private GameObject player2GO;
	

		void Update () 
	{
		if (Input.GetButtonDown ("Player 1 Jump") && playerJump == false && isPlayer1 == true) {
			rb.AddForce (Vector3.up * jumpHeight);
			playerJump = true;
		} else if (Input.GetButtonDown ("Player 2 Jump") && playerJump == false && isPlayer1 == false) {
			rb.AddForce (Vector3.up * jumpHeight);
			playerJump = true;
		}
	}

	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		setCountText ();
		winText.text = "";

		player1GO = GameObject.FindGameObjectWithTag ("Player");
		player2GO = GameObject.FindGameObjectWithTag ("Player 2");
	}

	void FixedUpdate () 
	{

		if (isPlayer1 == true) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			
			rb.AddForce (movement);
		}
			else if(isPlayer1 == false) { 
			float moveHorizontal = Input.GetAxis ("Player 2 Horizontal");
			float moveVertical = Input.GetAxis ("Player 2 Vertical");
			
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			
			rb.AddForce (movement);
			}
		}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			setCountText ();
		}
	}

	void setCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 10) 
		{
			winText.text = "You Win!";
		}
	}


	void OnCollisionEnter(Collision col) {
	if (col.transform.name == "Ground") {
		playerJump = false;
	}
		if (col.gameObject.tag == "Wall") {
			count--;
			if (count < 0)
			{
				count = 0;
			}

		}
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Player2") {
			print ("made contact");
			if (player1GO.transform.position.y > (player2GO.transform.position.y)) {
				player1GO.GetComponent<PlayerController>().count++;
				print ("added point to p1");
			}
			else if (player1GO.transform.position.y < (player2GO.transform.position.y))
			{
				print ("added point to p2");
				player2GO.GetComponent<PlayerController>().count++;
			}
		}
	}
}


