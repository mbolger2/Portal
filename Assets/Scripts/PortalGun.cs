using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    // Go back to old idea of each barrel has own bullet and just move blue prefab around, same with orange
    // collision point = new transform

    [Header("Portal Gun Information")]
    [Tooltip("The time between shots")]
    [SerializeField] float coolDownTime;
    [Tooltip("The portal gun GameObject")]
    static public GameObject portalGun;

    bool isCooldown = false;

    [Header("Bullet Information")]
    [Tooltip("The prefab of the bullet")]
    [SerializeField] GameObject bullet;
    [Tooltip("The spawnpoint of the bullet")]
    [SerializeField] Transform bulletSpawn;


    [Header("Portal Information")]
    [Tooltip("The prefab of the portal")]
    [SerializeField] GameObject portalBlue;
    [SerializeField] GameObject portalOrange;
    [Tooltip("The blue portal prefab that is accessible from other scripts")]
    static public GameObject portalBlueStatic;
    [Tooltip("The orange portal prefab that is accessible from other scripts")]
    static public GameObject portalOrangeStatic;
    //[SerializeField] GameObject portals;
    //static public GameObject portalsStatic;
    //static public bool tp = true;
    //static public int portalCount;
    static public bool one = true;
    
    

    // Start is called before the first frame update
    void Start()
    {
        portalGun = gameObject;
        //portalsStatic = portals;
        portalBlueStatic = portalBlue;
        portalOrangeStatic = portalOrange;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isCooldown)
        {
            GameObject cloneBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            one = true;
            StartCoroutine(cooldownTimer());
        }
        else if (Input.GetMouseButtonDown(1) && !isCooldown)
        {
            GameObject cloneBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            one = false;
            StartCoroutine(cooldownTimer());
        }
    }

    IEnumerator cooldownTimer()
    {
        yield return new WaitForSeconds(coolDownTime);
        isCooldown = false;
    }
}
