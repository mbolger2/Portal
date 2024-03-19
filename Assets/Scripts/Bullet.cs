using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float time;
    public GameObject portal;
    Shooting shooting;
    Vector3 collisionPosition;
    PortalManager portalManager;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 3f)
        {
            Destroy(gameObject);
        }

        collisionPosition = transform.position;
    }

    void OnCollisionEnter(Collision other)
    {
        GameObject Portal = Instantiate(portal, collisionPosition, Quaternion.Euler(90f, 0f, 0f));

        if (this.gameObject.CompareTag("Blue"))
        {
            portalManager.bluePortals.Add(Portal);
        }

        if (this.gameObject.CompareTag("Orange"))
        {
            portalManager.orangePortals.Add(Portal);
        }

        Destroy(gameObject);
    }
}
