using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    // The bullet prefab
    [SerializeField] GameObject blueBullet;
    [SerializeField] public GameObject orangeBullet;

    // The speed of the bullet
    [SerializeField] float bulletSpeed;

    [SerializeField] float blueTimeBetweenShots;
    [SerializeField] float orangeTimeBetweenShots;
    [SerializeField] float timeBetweenShots;

    // Bools
    public bool blueReadyToShoot;
    public bool orangeReadyToShoot;
    

    // References
    public Transform attackPoint;

    // variables
    float blueTime;
    float orangeTime;

    // Teleport variables
    static public bool tp = true;
    static public int portalCount = 0;

    public GameObject portal;
    static public GameObject portalStatic;

    // Update is called once per frame
    void Update()
    {
        blueTime += Time.deltaTime;
        orangeTime += Time.deltaTime;

        if (blueTime >= blueTimeBetweenShots)
        {
            blueReadyToShoot = true;
        }

        if (orangeTime >= orangeTimeBetweenShots)
        {
            orangeReadyToShoot = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && blueReadyToShoot)
        {
            Shoot(blueBullet);
            blueReadyToShoot = false;
            blueTime = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse1) && orangeReadyToShoot)
        {
            Shoot(orangeBullet);
            orangeReadyToShoot = false;
            orangeTime = 0;
        }
    }

    void Shoot(GameObject bullet)
    {
        var Bullet = Instantiate(bullet, attackPoint.position, attackPoint.rotation);
        Bullet.GetComponent<Rigidbody>().velocity = attackPoint.forward * bulletSpeed;
    }
}
