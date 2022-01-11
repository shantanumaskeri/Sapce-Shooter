using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;

	public int scoreValue;
	private  GameController gameController;

	void Start ()
	{
		GameObject gameControllerObj = GameObject.FindGameObjectWithTag ("GameController");
		gameController = gameControllerObj.GetComponent<GameController>();	
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.CompareTag ("Boundary") || col.gameObject.CompareTag ("Enemy"))
		{
			return;
		}

		if (explosion != null)
		{
			Instantiate (explosion, transform.position, transform.rotation);	
		}

		if (col.gameObject.CompareTag ("Bolt"))
		{
			gameController.AddScore (scoreValue);	
		}

		if (col.gameObject.CompareTag ("Player"))
		{
			Instantiate (playerExplosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
			gameController.GameOver ();
		}

		Destroy (col.gameObject);
		Destroy (gameObject);
	}
}
