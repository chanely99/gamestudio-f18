using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
	[Range(50, 200)]
	public float speed = 100; 
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); 

	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis("Horizontal"); 
		float vertical = Input.GetAxis("Vertical");

		Vector3 forceVector = new Vector3(horizontal, 0, vertical); 
		rb.AddForce (forceVector*speed); 
	}
}
