using UnityEngine;
using System.Collections;

public class PredictorController : MonoBehaviour {

	public GameObject predictorPrefab;
	public GameObject player;

	public GameObject planetParent;
	void FixedUpdate ()
	{
		GameObject newObj = (GameObject)Instantiate (predictorPrefab, player.transform.position, player.transform.rotation);
		foreach (Transform child in planetParent.GetComponentInChildren<Transform>()) 
		{
			newObj.rigidbody.AddForce(child.gameObject.GetComponent<Planet>().GetGravity(this.transform.position));
		}
	//	newObj.rigidbody.
	}
}
