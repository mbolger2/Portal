using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletSpeed = 50f;

    float lifeTime = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * bulletSpeed;
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        PortalGun.portalCount += 1;
        GameObject clonePortal = Instantiate(PortalGun.portalStatic, transform.position, Quaternion.identity);

        if (PortalGun.one)
        {
            clonePortal.tag = "1";
            PortalGun.one = false;
        }
        else
        {
            clonePortal.tag = "2";
            PortalGun.one = true;
        }

        clonePortal.transform.parent = PortalGun.portalsStatic.transform;

        if (!collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
