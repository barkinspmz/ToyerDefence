using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour, IInteractable
{
    public void Interacted(Transform parentPos)
    {
        this.gameObject.transform.parent = parentPos.transform;
        transform.position = parentPos.transform.position;
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;

    }
}
