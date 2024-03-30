using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    float tpCooldown = 1f;

    void Update()
    {
        if (Shooting.portalCount > 2 && tag == "Blue")
        {
            Destroy(gameObject);
            Shooting.portalCount -= 1;
        }

        else if (Shooting.portalCount > 2 && tag == "Orange")
        {
            Destroy(gameObject);
            Shooting.portalCount -= 1;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Objective")
        {
            GameObject otherPortal = null;

            for (int i = 0; i < Shooting.portalStatic.transform.childCount; i++)
            {
                if (tag == "Blue" && Shooting.portalStatic.transform.GetChild(i).tag == "Orange")
                {
                    otherPortal = Shooting.portalStatic.transform.GetChild(i).gameObject;
                }

                else if (tag == "Orange" && Shooting.portalStatic.transform.GetChild(i).tag == "Blue")
                {
                    otherPortal = Shooting.portalStatic.transform.GetChild(i).gameObject;

                }
            }

            if (otherPortal)
            {
                other.gameObject.transform.parent.transform.position = otherPortal.transform.position;
            }
        }
    }
}
