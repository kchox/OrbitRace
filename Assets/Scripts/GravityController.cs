using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravityController: MonoBehaviour
{
	private static List<GravityComponent> gravityList = new List<GravityComponent>();
	private static List<Rigidbody> rigidbodyList = new List<Rigidbody>();

	public static void AddGravityComponent(GravityComponent newGravity)
	{
		gravityList.Add(newGravity);
	}

	public static void RemoveGravityComponent(GravityComponent deadGravity)
	{
		gravityList.Remove(deadGravity);
	}
	
	public static void AddRigidbodyObject(Rigidbody rb) 
	{
		rigidbodyList.Add (rb);
	}
	
	public static void RemoveRigidbodyObject(Rigidbody rb) 
	{
		rigidbodyList.Remove (rb);
	}
	
	public static Vector3 CalculateGravity(Vector3 pos)
	{
		Vector3 grav = Vector3.zero;
		foreach (GravityComponent gc in gravityList)
		{
			grav += gc.GetGravity(pos);
		}
		return grav;
	}
	
	void FixedUpdate()
	{
		foreach (Rigidbody target in rigidbodyList)
		{
			Vector3 grav = CalculateGravity(target.transform.position);
			target.AddForce(grav);
		}
	}
}
