using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Header ("Sub stuff")]
	public float speed = 5;
	public Transform cameraTransform;
	public Transform subHolder;


	[Header ("Torpedo things")]
	public Transform torpedoPrefab;
	public Transform firePointTransform;


	[Header ("Hide")]
	public bool alive = true;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (alive) {
            /*
            //Moving submarine around scene with keyboard controls...But why would you want this? It sucks
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //Moving forward
                gameObject.transform.Translate(transform.forward * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                //Moving back
                gameObject.transform.Translate(-transform.forward * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                //Moving right
                gameObject.transform.Translate(transform.right * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                //Moving left
                gameObject.transform.Translate(-transform.right * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.PageUp)) {
                // Rotating
                gameObject.transform.Rotate(transform.up * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.PageDown))
            {
                //Rotating
                gameObject.transform.Rotate(-transform.up * speed * Time.deltaTime);
            }
            */

           // gameObject.transform.position += Input.mousePosition;


            //Move player forward
            gameObject.transform.position += cameraTransform.transform.forward * speed * Time.deltaTime;

            //Rotate submarine shell
            Quaternion subRotation = subHolder.transform.rotation;
			Quaternion cameraRotation = cameraTransform.transform.rotation;
			subHolder.transform.rotation = Quaternion.Slerp (subRotation, cameraRotation, 5f * Time.deltaTime);
           
			//Enable pew pew pews!! (updated 2018-03-30)
			 if (Input.GetButtonDown("Fire1")) {

				Instantiate (torpedoPrefab, firePointTransform.position, subRotation);
				//cleaner way
				//TorpedoController torpedoController = torpedo.GetComponent<TorpedoController> ();
				//torpedoController.playerController = this;
			} 
        }
	}

	void OnTriggerEnter(Collider other)
	{
		alive = false;
		Debug.Log ("Triggered with " + other.name);

		//Update UI Message
		UIHelper_Example.ChangeText("You Lose! :(");
	}
	
	
}