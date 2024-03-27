using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform otherPortal;
    public GameObject playerOut;
    //public GameObject player;
    //public GameObject orientation;
    public GameObject playerCamera;
    public GameObject cameraPos;

    public PlayerMovementRb pMRB;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("collided");
            other.gameObject.SetActive(false);
            playerCamera.SetActive(false);
            //Cursor.lockState = CursorLockMode.None;

            PlayerMovementRb playerRB = other.gameObject.GetComponent<PlayerMovementRb>();



            other.transform.position = playerOut.transform.position;
            playerCamera.transform.position = cameraPos.transform.position;

            playerRB.transform.rotation = transform.rotation;
            //playerCamera.transform.rotation = playerOut.transform.rotation;

            other.gameObject.SetActive(true);
            playerCamera.SetActive(true);
            //Cursor.lockState = CursorLockMode.Locked;
        }

        if (other.CompareTag("Objective"))
        {
            other.enabled = false;
            other.transform.position = playerOut.transform.position;
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
