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
    public float timeBetweenShots;

    // Bools
    bool readyToShoot;

    // References
    public Camera fppCam;
    public Transform attackPoint;

    // variables
    float time;

    public PlayerInput inputActions;

    private void Awake()
    {
        inputActions = new PlayerInput();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > timeBetweenShots)
        {
            readyToShoot = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && readyToShoot)
        {
            Shoot(blueBullet);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && readyToShoot)
        {
            Shoot(orangeBullet);
        }
    }

    void Shoot(GameObject bullet)
    {
        readyToShoot = false;
        time = 0;

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
