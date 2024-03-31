using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    int tpCoolDown = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PortalGun.portalCount > 2 && tag == "1")
        {
            Destroy(gameObject);
            PortalGun.portalCount -= 1;
        }
        else if (PortalGun.portalCount > 2 && tag == "2")
        {
            Destroy(gameObject);
            PortalGun.portalCount -= 1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && PortalGun.tp)
        {
            GameObject otherPortal = null;

            for (int i = 0; i < PortalGun.portalsStatic.transform.childCount; i++)
            {
                if (tag == "1" && PortalGun.portalsStatic.transform.GetChild(i).tag == "2")
                {
                    otherPortal = PortalGun.portalsStatic.transform.GetChild(i).gameObject;
                }

                else if (tag == "2" && PortalGun.portalsStatic.transform.GetChild(i).tag == "1")
                {
                    otherPortal = PortalGun.portalsStatic.transform.GetChild(i).gameObject;
                }
            }

            if (otherPortal)
            {
                other.gameObject.transform.parent.transform.position = otherPortal.transform.position;
                PortalGun.tp = false;
                StartCoroutine(TPCoolDown());
            }
        }
    }

    IEnumerator TPCoolDown()
    {
        yield return new WaitForSeconds(tpCoolDown);
        PortalGun.tp = true;
    }
}
