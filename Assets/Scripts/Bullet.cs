using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject portal;
    float lifeTime = 3f;

    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        var Portal = Instantiate(portal, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}