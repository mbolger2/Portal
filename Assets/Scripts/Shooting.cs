using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    // The bullet prefab
    public GameObject blueBullet;
    public GameObject orangeBullet;

    // The speed of the bullet
    public float bulletSpeed;

    // Gun stats
    public float blueTimeBetweenShots;
    public float orangeTimeBetweenShots;

    // Bools
    public bool blueReadyToShoot;
    public bool orangeReadyToShoot;

    // References
    public Camera fppCam;
    public Transform attackPoint;

    // variables
    public float blueTime;
    public float orangeTime;
    //public int bluePortalCount = 0;
    //public int orangePortalCount = 0;

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
        // Find the exact hit position using raycast
        Ray ray = fppCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        // Does the ray hit something
        Vector3 targetPoint;
        if (Physics.Raycast(ray,out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        // Get the direction from attackpoint to targetpoint
        Vector3 direction = targetPoint - attackPoint.position;

        // Instantiate and orient projectile
        GameObject Bullet_Clone = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        Bullet_Clone.GetComponent<Rigidbody>().AddForce(direction.normalized * bulletSpeed, ForceMode.Impulse);
    }
}
