using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryCube : MonoBehaviour {
	public float radius = 4.0f;

	public void Operate()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

		foreach (Collider collider in hitColliders)
		{
			collider.SendMessage("PickupBox", this.gameObject, SendMessageOptions.DontRequireReceiver);
		}
	}
}
