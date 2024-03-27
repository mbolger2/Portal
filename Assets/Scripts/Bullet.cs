using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float time;
    public GameObject portal;
   // Shooting shooting;
    Vector3 collisionPosition;
    //PortalManager portalManager;

    Rigidbody rb;
    float xVel;
    float yVel;
    float zVel;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 3f)
        {
            Destroy(gameObject);
        }
    }

    

    void OnCollisionEnter(Collision other)
    {
        collisionPosition = transform.position;

        GameObject Portal = Instantiate(portal, collisionPosition, Quaternion.identity);
       
        Destroy(gameObject);
    }
}
