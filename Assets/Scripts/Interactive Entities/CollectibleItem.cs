using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour {
    [SerializeField]
    private string itemName;
    public float radius = 4.0f;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Item Collected: " + itemName);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider collider in hitColliders)
        {
            collider.SendMessage("PickupCollectible", SendMessageOptions.DontRequireReceiver);
        }

        StartCoroutine(WaitBeforeDestroy());
    }

    private IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
