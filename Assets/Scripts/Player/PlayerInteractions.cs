using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
	public enum DeviceType { button, lever };

	private Animator _animator;
	//// Use this for initialization
	void Start()
	{
		_animator = GetComponent<Animator>();
	}

	public void PushButton()
	{
		StartCoroutine(UseObject(DeviceType.button));
	}

	public void PickupCollectible()
	{
		if(!_animator.GetBool("CarryingBox"))
			StartCoroutine(PickupCollectibleAnimation());
	}

	public IEnumerator PickupCollectibleAnimation()
	{
		Debug.Log("player picked up item.");
		_animator.SetBool("PickupCollectible", true);
		yield return new WaitForSeconds(1.5f);
		_animator.SetBool("PickupCollectible", false);
	}

	public IEnumerator UseObject(DeviceType device)
	{
		switch (device)
		{
			case DeviceType.button:
				_animator.SetBool("UseObject", true);
				yield return new WaitForSeconds(0.5f);
				_animator.SetBool("UseObject", false);
				break;

			default:
				break;
		}
	}

	public void PickupBox(GameObject box)
	{
		_animator.SetBool("CarryingBox", true);
		StartCoroutine(ParentBoxDelay(box));
	}

	public IEnumerator ParentBoxDelay(GameObject box)
	{
		DeviceOperator deviceOperator = GetComponent<DeviceOperator>();
		yield return new WaitForSeconds(1.0f);
		deviceOperator.CarriedObject = box;
		box.transform.parent = transform;
	}
}

