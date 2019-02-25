using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This is for switches, buttons etc that operate remote devices. For example, an elevator call button.
public class RemoteDeviceOperator : ButtonDevice {
    [SerializeField]
    GameObject remoteDevice;
    public enum DeviceType{button, lever };
    public DeviceType deviceType;
	// Use this for initialization
	public override void Operate()
    {
		base.Operate();
		StartCoroutine(Delay());
    }

	private IEnumerator Delay()
	{
		yield return new WaitForSeconds(0.5f);
		remoteDevice.SendMessage("RemoteOperate", SendMessageOptions.DontRequireReceiver);
	}
}
