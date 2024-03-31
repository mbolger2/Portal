using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 50f;

    float lifeTime = 3f;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * Time.deltaTime * bulletSpeed;
        
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Transform spawnPoint = collision.transform;
        //PortalGun.portalCount += 1;
       // GameObject clonePortal = Instantiate(PortalGun.portalStatic, transform.position, Quaternion.identity);

        if (PortalGun.one)
        {
            PortalGun.portalBlueStatic.transform.position = spawnPoint.transform.position;
            //clonePortal.tag = "1";
            //PortalGun.one = false;
        }
        else
        {
            PortalGun.portalOrangeStatic.transform.position = spawnPoint.transform.position;
            //clonePortal.tag = "2";
            //PortalGun.one = true;
        }

        //clonePortal.transform.parent = PortalGun.portalsStatic.transform;

        if (!collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
