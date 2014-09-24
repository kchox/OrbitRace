using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed1;
	public float speed2;

	public string searchTag;
	public float scanFreq;
	private GameObject target;

	void Start()
	{
		rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
		ScanForTarget ();
		InvokeRepeating ("ScanForTarget", 0, scanFreq);
	}

	void FixedUpdate ()
	{
		//float moveH = Input.GetAxis ("Horizontal");

		// W/S keys or Up/Down arrows to increase/decrease magnitude of current velocity
		float moveV = Input.GetAxis ("Vertical");
			
		Vector3 movement = rigidbody.velocity.normalized;
			
		rigidbody.AddForce (movement * speed1 * moveV * Time.deltaTime);




		// A/D keys or Left/Right arrows to increase/decrease tangential velocity
		//   relative to closest Planet
		float moveH = Input.GetAxis ("Horizontal");
		Vector3 movement2 = Vector3.Cross (this.transform.position - target.transform.position, new Vector3 (0, 0, 1)).normalized;
		Debug.DrawLine (this.transform.position, target.transform.position);
		Debug.DrawRay (this.transform.position, movement2);
		
		rigidbody.AddForce (movement2 * speed2 * moveH * Time.deltaTime);
	}

	void ScanForTarget () 
	{
		target = GetNearestTaggedObject ();
	}

	GameObject GetNearestTaggedObject ()
	{
		float nearestDistanceSqr = Mathf.Infinity;
		GameObject[] taggedGameObjects = GameObject.FindGameObjectsWithTag (searchTag);
		GameObject nearestObj = null;

		foreach (GameObject obj in taggedGameObjects)
		{
			float distanceSqr = (obj.transform.position - transform.position).sqrMagnitude;

			if (distanceSqr < nearestDistanceSqr)
			{
				nearestObj = obj;
				nearestDistanceSqr = distanceSqr;
			}
		}
		return nearestObj;
	}





}
