using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	public Transform thisTransform;
	public Rigidbody2D rigt;
	public float speed;
	public float jumpspeed;
	public bool grounded;
	public AudioSource sound;
	public AudioSource[] AudioClips = null;
	public AudioSource sound1;
	public AudioSource sound2;
	public GUITexture gameover;
	void Start () {
		thisTransform = GetComponent (typeof(Transform)) as Transform;
		rigt= GetComponent (typeof( Rigidbody2D)) as Rigidbody2D;
		AudioClips= GetComponents<AudioSource>();
		sound1=AudioClips[0];
		sound2 = AudioClips [1];
	}
	

	void Update () {
		thisTransform.Translate (Vector3.right * speed * Time.deltaTime);
		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			grounded = false;
			rigt.AddForce (Vector2.up * jumpspeed);
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Pick ups") {
			//grounded = true;
			other.gameObject.SetActive (false);

		} else {
			//grounded = false;
		}

		if (other.gameObject.tag == "Ground") {
			grounded = true;
		
			sound1.Play ();

		}


		if (other.gameObject.tag == "obstacle") {	
			sound2.Play ();
			Gameover();
		}

	}


	/*void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ground") {
			grounded = true;
		} else {
			grounded = false;
		}

		if (other.gameObject.tag == "Pick ups") {
			other.gameObject.SetActive (true);
			grounded = true;
		}
	}*/

	void Gameover(){
		Destroy (GetComponent (typeof(Animator))as Animator);
		Destroy (GetComponent (typeof(Collider2D))as Collider2D);
		Destroy (this);
		gameover.enabled = true;	
	}


}