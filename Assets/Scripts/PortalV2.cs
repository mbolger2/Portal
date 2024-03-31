using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalV2 : MonoBehaviour
{
    [Header("Teleporting Information")]
    [Tooltip("The portal that the player wants to teleport to")]
    [SerializeField] GameObject otherPortalTPPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Objective"))
        {
            other.transform.position = otherPortalTPPoint.transform.position;
            other.transform.forward = otherPortalTPPoint.transform.forward;
        }
    }

}
