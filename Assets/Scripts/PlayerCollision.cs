using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour {

	public PlayerMovement movement;
	public Text countText;

	private int count;

	void Start ()
	{
		count = 0;
		SetCountText ();		
	}

	void OnCollisionEnter (Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Obstacle")
		{
			movement.enabled = false;
			FindObjectOfType<GameManager>().EndGame();

		}
	}

	void OnTriggerEnter (Collider other)
		{
			if (other.gameObject.CompareTag("Collectable"))
			{
				other.gameObject.SetActive(false);
				count = count + 1;
				SetCountText ();
			}
		}

	void SetCountText ()
	{
		countText.text = count.ToString() + " points";
	}
}