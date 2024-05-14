using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    RaycastHit _hit;
    [SerializeField] Transform _startPositionOfRay;
    private float _range = 100f;

    private GameObject _currentGrabbedObject;

    void Update()
    {
        //It cast a ray to forward
        Ray ray = new Ray(_startPositionOfRay.position, _startPositionOfRay.forward);

        //Checking there is hitted object or not.
        if (Physics.Raycast(ray, out _hit, _range)) // && When the Grab Button Triggered.
        {
            if (_hit.collider.gameObject.TryGetComponent(out IInteractable interactedObj))
            {
                interactedObj.Interacted();
            }
        }
    }
}
