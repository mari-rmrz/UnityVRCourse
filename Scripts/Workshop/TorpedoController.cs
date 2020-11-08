using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoController : MonoBehaviour {

	public float speed = 20;
	public float maxLifetime = 10f;
	public GameObject explosionPrefab;
	public GameObject conf;
	GameObject confet = (GameObject)Instantiate(Resources.Load("Confetti"));
	

	protected float lifetime = 0;

	// Use this for initialization
	void Start () {
		confet.tag = "Confetti";
		confet.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += gameObject.transform.forward * Time.deltaTime * speed;

		lifetime += Time.deltaTime;
		if (lifetime > maxLifetime) {
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter (Collider other)
	{
		Debug.Log ("Torpedo hit " + other.name);

		if (other.tag == "Destroy") {
			Destroy (other.gameObject);


			int count = GameObject.FindGameObjectsWithTag ("Destroy").Length -1;
			Debug.Log ("There are " + count + " mines left");

			//No more mines to hit, user won the game :) 
			if (count == 0) {
				GameObject player = GameObject.FindGameObjectWithTag("Player");
				PlayerController playerController = player.GetComponent<PlayerController> ();
				UIHelper_Example.ChangeText ("YOU WON! :)");
				playerController.alive = false;

				if (playerController.alive == false)
				{
					// Make confetti appear wherever the player is
					GameObject confet = GameObject.FindGameObjectWithTag("Confetti");
					confet.SetActive(true);
					Instantiate(confet, playerController.transform.position + (player.transform.right * 3) , playerController.transform.rotation);
				}
			
			}
		}

		//if torpedo hit, create explosion
		if (explosionPrefab != null) {
			Instantiate (explosionPrefab, gameObject.transform.position, Quaternion.identity);
		} else {
			Debug.Log ("You forgot to assign your explosion prefab");
		}
	
	}

}