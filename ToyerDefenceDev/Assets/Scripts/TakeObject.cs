using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    RaycastHit _hit;
    private float _range = 100000f;

    private bool _canTakeObject;
    private GameObject _currentGrabbedObject;

    public bool isLeftHand = false;

    void Update()
    {
        //When this script works at the same time in both hand, it will be error, seperate it later.
        //
        if (isLeftHand)
        {
            if (OVRInput.GetDown(OVRInput.Button.Four))
            {
                _canTakeObject = true;
            }

            if (OVRInput.GetUp(OVRInput.Button.Four))
            {
                _currentGrabbedObject.GetComponentInChildren<AttackerBuilding01>().isAttack = true;
                _canTakeObject = false;
                if (_currentGrabbedObject != null)
                {
                    _currentGrabbedObject.transform.parent = null;
                    _currentGrabbedObject.GetComponent<Rigidbody>().useGravity = true;
                    _currentGrabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                    _currentGrabbedObject = null;
                }
            }
        }
        else
        {
            if(OVRInput.GetDown(OVRInput.Button.Two))
            {
                _canTakeObject = true;
            }

            if (OVRInput.GetUp(OVRInput.Button.Two))
            {
                _currentGrabbedObject.GetComponentInChildren<AttackerBuilding01>().isAttack = true;
                _canTakeObject = false;
                if (_currentGrabbedObject != null)
                {
                    _currentGrabbedObject.transform.parent = null;
                    _currentGrabbedObject.GetComponent<Rigidbody>().useGravity = true;
                    _currentGrabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                    _currentGrabbedObject = null;
                }
            }
        }
       
        //It cast a ray to forward
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        //Checking there is hitted object or not.
        if (Physics.Raycast(ray, out _hit, _range)&&_canTakeObject&&_currentGrabbedObject==null) // && When the Grab Button Triggered.
        {
            if (_hit.collider.gameObject.TryGetComponent(out IInteractable interactedObj))
            {
                if(_currentGrabbedObject==null)
                {
                    _currentGrabbedObject = _hit.collider.gameObject;
                    interactedObj.Interacted(this.gameObject.transform);
                }
            }
        }
    }
}
