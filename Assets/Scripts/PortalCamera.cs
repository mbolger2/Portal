using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    // Update is called once per frame
    void Update()
    {
        //float angle = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        //Quaternion angletoQuaternion = Quaternion.AngleAxis(angle, Vector3.up);

        //Vector3 dir = angletoQuaternion * -playerCamera.forward;

        //Vector3 offset = playerCamera.position - otherPortal.position;

        //transform.position = portal.position + offset;

        //Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        //transform.position = portal.position + playerOffsetFromPortal;

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        
    }
}
