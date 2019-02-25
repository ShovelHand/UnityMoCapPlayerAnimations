using UnityEngine;
using System.Collections;

public class DeviceOperator : MonoBehaviour {
	public float radius = 1.5f;
	private Animator _animator;
	private GameObject carriedCube = null;
	[SerializeField]
	GameObject leftHand;
	[SerializeField]
	GameObject rightHand;

	public void Start()
	{
		_animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update() {
		if (carriedCube != null)
		{
			Vector3 BoxPos = (leftHand.transform.position + rightHand.transform.position) /2.0f;
			carriedCube.transform.position = BoxPos;
		}

		if (Input.GetButtonDown("Fire1")) {
			if (_animator.GetBool("CarryingBox"))
			{
				StartCoroutine(PutDownBox());
			}
			else
			{
				Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

				foreach (Collider hitCollider in hitColliders) {
					Vector3 direction = hitCollider.transform.position - transform.position;
					if (Vector3.Dot(transform.forward, direction) > 0.5f) {
						hitCollider.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);
					}
				}

			}
		}
	}

	private IEnumerator PutDownBox()
	{
		_animator.SetBool("CarryingBox", false);
		yield return new WaitForSeconds(1.0f);
		carriedCube.transform.parent = null;
		carriedCube = null;
	}

	public GameObject CarriedObject
	{
		get { return carriedCube; }
		set
		{
			if (carriedCube != value)
				carriedCube = value;
		}
	}
}
