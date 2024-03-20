using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform otherPortal;
    public Transform playerOut;

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        float x = playerOut.transform.position.x;
        float y = playerOut.transform.position.y;
        float z = playerOut.transform.position.z;

        if (other.CompareTag("Player") || other.CompareTag("Objective"))
        {
            Debug.Log("collided");
            other.gameObject.SetActive(false);
            other.transform.position = new Vector3(x, y, z);
            other.transform.rotation = new Quaternion(0f, otherPortal.rotation.y, 0f, 0f);
            other.gameObject.SetActive(true);
        }
    }
}
