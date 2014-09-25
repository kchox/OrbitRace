using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PredictorController : MonoBehaviour
{
	public GameObject predictorPrefab;
	public GameObject player;
	public int numIndicators;
	public float stepsize;
	
	private GameObject[] indicatorList;
	
	void Start()
	{
		indicatorList = new GameObject[numIndicators+1];
		indicatorList[0] = player;
		for (int i = 1; i < indicatorList.Length; i++)
		{
			indicatorList[i] = (GameObject)Instantiate(predictorPrefab);
			indicatorList[i].transform.parent = this.gameObject.transform;
		}
	}

	// Very simple prediction algorithm using straight line movement
	//    NOTE: smaller stepsize for better accuracy, but need more dots for length!
	void FixedUpdate()
	{
		for (int i = 1; i < indicatorList.Length; i++)
		{
			indicatorList[i].transform.position = indicatorList[i-1].transform.position
				+ indicatorList[i-1].rigidbody.velocity * stepsize;
			indicatorList[i].rigidbody.velocity = indicatorList[i-1].rigidbody.velocity
				+ GravityController.CalculateGravity( indicatorList[i-1].transform.position ) * stepsize;
		}
	}
}
