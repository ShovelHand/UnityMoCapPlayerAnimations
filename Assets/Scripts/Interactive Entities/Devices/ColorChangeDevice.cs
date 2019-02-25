using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeDevice : ButtonDevice {
	

	public override void Operate()
    {
		base.Operate();
		StartCoroutine(Delay());
    }

	private IEnumerator Delay()
	{
		yield return new WaitForSeconds(1.0f);
		Color random = new Color(Random.Range(0.0f, 1.0f),
			Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
		GetComponent<Renderer>().material.color = random;
	}
}
