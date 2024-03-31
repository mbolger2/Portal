using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldBullet : MonoBehaviour
{
    //[SerializeField] GameObject portal;
    [SerializeField] Material blueMat;
    [SerializeField] Material orangeMat;
    string portalTag;
    float lifeTime = 3f;

    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (this.gameObject.CompareTag("Blue"))
        {
            Shooting.portalStatic.GetComponentInChildren<MeshRenderer>().material = blueMat;
            portalTag = "Blue";
        }

        if (this.gameObject.CompareTag("Orange"))
        {
            Shooting.portalStatic.GetComponentInChildren<MeshRenderer>().material = orangeMat;
            portalTag = "Orange";
        }

        Shooting.portalCount += 1;
        GameObject portalClone = Instantiate(Shooting.portalStatic, collision.collider.transform);
        portalClone.tag = portalTag;

        if (portalClone.CompareTag("Blue"))
        {
            portalClone.GetComponentInChildren<MeshRenderer>().material = blueMat;
        }

        else if (portalClone.CompareTag("Orange"))
        {
            portalClone.GetComponentInChildren<MeshRenderer>().material = orangeMat;
        }
        //var Portal = Instantiate(portal, transform.position, Quaternion.identity);
        

    }

    
}