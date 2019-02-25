using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDevice : MonoBehaviour {
	public float radius = 4.0f;
	
	public virtual void Operate()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

		foreach (Collider collider in hitColliders)
		{
			collider.SendMessage("PushButton", SendMessageOptions.DontRequireReceiver);
		}

	}
}
