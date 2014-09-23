using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;

	void FixedUpdate ()
	{
		//float moveH = Input.GetAxis ("Horizontal");

		// W/S keys or Up/Down arrows to increase/decrease magnitude of current velocity
		float moveV = Input.GetAxis ("Vertical");
			
		Vector3 movement = rigidbody.velocity.normalized;
			
		rigidbody.AddForce (movement * speed * moveV * Time.deltaTime);




		// A/D keys or Left/Right arrows to increase/decrease tangential velocity
		//   relative to closest Planet
		float moveH = Input.GetAxis ("Horizontal");
		Vector3 movement2 = rigidbody.velocity.normalized - rigidbody.position * Vector3.Dot(rigidbody.velocity.normalized, rigidbody.position);
		
		rigidbody.AddForce (movement2.normalized * speed * moveH * Time.deltaTime);
	}
}
