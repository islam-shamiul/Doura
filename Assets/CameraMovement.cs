using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public Transform player;
	public Transform cam;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		cam = GetComponent (typeof(Transform)) as Transform;
		offset = cam.position;
	}
	
	// Update is called once per frame
	void Update () {
		cam.position = Vector3.right * player.position.x + offset;
	}
}
