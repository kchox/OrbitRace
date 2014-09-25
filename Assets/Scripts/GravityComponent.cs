using UnityEngine;
using System.Collections;

public class GravityComponent : MonoBehaviour
{
	public float gravityStrength;

	void Start()
	{
		GravityController.AddGravityComponent(this);
	}

	void OnDestroy()
	{
		GravityController.RemoveGravityComponent(this);
	}

	public Vector3 GetGravity(Vector3 pos)
	{
		if (this.enabled)
		{
			Vector3 gVec = this.transform.position - pos;
			return gVec.normalized * gravityStrength / gVec.sqrMagnitude;
		} else
		{
			return Vector3.zero;
		}
	}
}
