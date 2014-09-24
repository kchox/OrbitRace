using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {
	public GameObject player;
	public float gravityStrength = 1;

	void FixedUpdate () {
		player.rigidbody.AddForce ( GetGravity (player.transform.position) );
	}

	public Vector3 GetGravity (Vector3 pos)
	{
		Vector3 gVec = this.transform.position - pos;
		return gVec.normalized * gravityStrength / gVec.sqrMagnitude;
	}
}
