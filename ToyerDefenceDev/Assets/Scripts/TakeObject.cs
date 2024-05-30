using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    RaycastHit _hit;
    [SerializeField] Transform _startPositionOfRay;
    private float _range = 100f;

    private bool _canTakeObject;
    private GameObject _currentGrabbedObject;

    void Update()
    {
        //When this script works at the same time in both hand, it will be error, seperate it later.
        //
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            _canTakeObject = true;
        }

        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            _canTakeObject = false;
            if (_currentGrabbedObject !=null)
            {
                _currentGrabbedObject.transform.parent = null;
                _currentGrabbedObject.GetComponent<Rigidbody>().useGravity = true;
                _currentGrabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                _currentGrabbedObject = null;
            }
        }
        //It cast a ray to forward
        Ray ray = new Ray(_startPositionOfRay.position, _startPositionOfRay.forward);

        //Checking there is hitted object or not.
        if (Physics.Raycast(ray, out _hit, _range)&&_canTakeObject) // && When the Grab Button Triggered.
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
