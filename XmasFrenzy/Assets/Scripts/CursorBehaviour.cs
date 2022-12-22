using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    //Public
    public bool isProximityClose, isRotationProximity;

    //Private
    private Rigidbody rigid;
    [SerializeField] private CustomUtilities utilities;

    void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        this.transform.position = new Vector3(utilities.MouseWorldPosition().x, 0, utilities.MouseWorldPosition().z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CursorProximity"))
        {
            isProximityClose = true;
        }

        if (other.gameObject.CompareTag("RotationProximity"))
        {
            isRotationProximity = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CursorProximity"))
        {
            isProximityClose = true;
        }

        if (other.gameObject.CompareTag("RotationProximity"))
        {
            isRotationProximity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CursorProximity"))
        {
            isProximityClose = false;
        }

        if (other.gameObject.CompareTag("RotationProximity"))
        {
            isRotationProximity = true;
        }
    }
}
