using UnityEngine;
using System.Collections;

// maintains position offset while orbiting around target

public class OrbitCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private GameObject lookTarget;
    [SerializeField]
    private Transform head;

    public float rotSpeed = 1.5f;

    private float _rotY;
    private float _rotX;
    private Vector3 _offset;

    // Use this for initialization
    void Start()
    {
        _rotY = transform.eulerAngles.y;
        _rotX = transform.eulerAngles.x;
        _offset = target.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;
        _rotX += Input.GetAxis("Mouse Y") * rotSpeed * 3;
        _rotX = Mathf.Clamp(_rotX, -15, 30);
        Quaternion rotation = Quaternion.Euler(_rotX, _rotY, 0);
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(lookTarget.transform);

        //rotate model's head same direction as camera is looking without going too far and looking grotesque.
        float headRotY = Mathf.Clamp(_rotY, -60, 60);
        head.transform.localRotation = Quaternion.Euler(_rotX, headRotY, 0);
        Transform bodyTransform = head.parent.GetComponent<Transform>();

        if (Vector3.Angle(bodyTransform.forward, transform.forward) < 110.0f)
        {
            head.forward = transform.forward;
        }
       
    }
}
