using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    bool canPickUp;
    bool isPickedUp;

    public GameObject objective;
    Rigidbody rb;
    public Transform pickupStaticPosition;

    // Start is called before the first frame update
    void Start()
    {
        canPickUp = false;
        isPickedUp = false;
        //rb = objective.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (canPickUp)
        {
            if (Input.GetKey(KeyCode.E) && !isPickedUp)
            {
                objective.transform.position = pickupStaticPosition.position;
                isPickedUp = true;
                objective.transform.parent = pickupStaticPosition;
                //Debug.Log("Picked Up");
                objective.GetComponent<Rigidbody>().isKinematic = true;
                //objective.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                //objective.GetComponent<Rigidbody>().useGravity = false;
            }
        }

        if (Input.GetKey(KeyCode.Q) && isPickedUp)
        {
            isPickedUp = false;
            objective.GetComponent<Rigidbody>().isKinematic = false;
            //objective.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            objective.transform.parent = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Objective"))
        {
            canPickUp = true;

            objective = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Objective"))
        {
            canPickUp = false;
        }
    }
}
