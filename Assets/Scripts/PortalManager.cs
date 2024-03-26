using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Transform bluePos;
    public Transform orangePos;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blue Portal"))
        {
            CharacterController charCon = GetComponent<CharacterController>();

            charCon.enabled = false;
            transform.position = orangePos.transform.position;
            transform.rotation = new Quaternion(transform.rotation.x, orangePos.rotation.y, transform.rotation.z, transform.rotation.w);

            charCon.enabled = true;
        }

        if (other.CompareTag("Orange Portal"))
        {
            CharacterController charCon = GetComponent<CharacterController>();

            charCon.enabled = false;
            transform.position = bluePos.transform.position;
            transform.rotation = new Quaternion(transform.rotation.x, bluePos.rotation.y, transform.rotation.z, transform.rotation.w);

            charCon.enabled = true;
        }
    }
}
