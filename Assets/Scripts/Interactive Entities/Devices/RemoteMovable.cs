using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteMovable : RemoteDevice {

    // Use this for initialization
    [SerializeField]
    private Vector3 dPos;

    private bool _open;

    public override void RemoteOperate()
    {
        if (_open)
        {
            Vector3 pos = transform.position - dPos;
            transform.position = pos;
        }
        else {
            Vector3 pos = transform.position + dPos;
            transform.position = pos;
        }
        _open = !_open;
    }

    public override void Activate()
    {
        if (!_open)
        {
            Vector3 pos = transform.position + dPos;
            transform.position = pos;
            _open = true;
        }
    }
    public override void Deactivate()
    {
        if (_open)
        {
            Vector3 pos = transform.position - dPos;
            transform.position = pos;
            _open = false;
        }
    }
}
