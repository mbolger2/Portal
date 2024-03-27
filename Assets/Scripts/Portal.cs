using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform otherPortal;
    public Transform playerOut;
    public Transform orientation;
    public GameObject playerCamera;
    public GameObject cameraPos;

    void OnTriggerEnter(Collider other)
    {
        float x = playerOut.transform.position.x;
        float y = playerOut.transform.position.y;
        float z = playerOut.transform.position.z;

        if (other.CompareTag("Player"))
        {
            //Debug.Log("collided");
            other.gameObject.SetActive(false);
            playerCamera.SetActive(false);
            //Cursor.lockState = CursorLockMode.None;

            other.transform.position = new Vector3(x, y, z);
            playerCamera.transform.position = cameraPos.transform.position;
            orientation.rotation = playerOut.transform.rotation;
            //playerCamera.transform.rotation = playerOut.transform.rotation;

            other.gameObject.SetActive(true);
            playerCamera.SetActive(true);
            //Cursor.lockState = CursorLockMode.Locked;
        }

        if (other.CompareTag("Objective"))
        {
            other.enabled = false;
            other.transform.position = new Vector3(x, y, z);
            other.transform.rotation = new Quaternion(
                other.transform.rotation.x,
                otherPortal.rotation.y + 180f,
                other.transform.rotation.z,
                other.transform.rotation.w);
            other.enabled = true;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.transform.parent = null;
        }
    }
}
