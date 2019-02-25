using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
    [SerializeField]
    private Transform target;
    public Vector3 _offset;

    // Use this for initialization
    void Start () {
        _offset = new Vector3(0, 4.25f, -2.0f);// target.position - transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = target.position + ( _offset);
        target.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }


}
