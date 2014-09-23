using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {
	public GameObject player;
	public float gravityStrength = 1;

	private Vector3 gravityVec;
	void FixedUpdate () {
		gravityVec = this.transform.position - player.transform.position;
		player.rigidbody.AddForce (gravityVec.normalized * gravityStrength/gravityVec.sqrMagnitude);
	}
}
