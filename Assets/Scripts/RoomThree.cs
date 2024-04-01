using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomThree : MonoBehaviour
{
    [Header("Portals")]
    [Tooltip("The gameObject of the blue portal")]
    [SerializeField] GameObject portalBlue;
    [Tooltip("The gameObject of the orange portal")]
    [SerializeField] GameObject portalOrange;

    [Header("Spawn Points")]
    [Tooltip("A list containing the spawnpoints of the blue portal")]
    [SerializeField] List<Transform> blueSpawnPoints;
    [Tooltip("A list containing the spawnpoints of the orange portal")]
    [SerializeField] List<Transform> orangeSpawnPoints;

    // Room & portal control variables
    bool roomActive = false;
    bool portalEnabled = false;
    float time;
    bool checkPointOne = true;
    bool checkPointTwo = true;
    bool checkPointThree = true;
    AudioSource audioSource;

    void Start()
    {
        audioSource = portalBlue.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (roomActive)
        {
            time += Time.deltaTime;
            MovingPortal();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            roomActive = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            roomActive = false;
            SceneManager.LoadScene("WinScene");
        }
    }

    void EnableDisablePortal()
    {
        portalBlue.SetActive(portalEnabled);
        portalOrange.SetActive(portalEnabled);
        portalEnabled = !portalEnabled;
    }

    void MovingPortal()
    {
        if (time >= 0)
        {
            if (checkPointOne)
            {
                // Disable portals
                EnableDisablePortal();

                // Set position and rotation
                PortalPos(0);

                // Enable portals
                EnableDisablePortal();

                // Play audio
                portalBlue.GetComponent<AudioSource>().PlayOneShot(PortalTeleport.portalClips[1]);

                // Disable the movement portion
                checkPointOne = false;
            }

            else if (time >= 6f && !checkPointOne)
            {
                if (checkPointTwo)
                {
                    // Disable portals
                    EnableDisablePortal();

                    // Set position and rotation
                    PortalPos(2);

                    // Enable portals
                    EnableDisablePortal();

                    // Play audio
                    portalBlue.GetComponent<AudioSource>().PlayOneShot(PortalTeleport.portalClips[1]);

                    // Disable the movement portion
                    checkPointTwo = false;
                }

                else if (time >= 12f && !checkPointTwo)
                {
                    if (checkPointThree)
                    {
                        // Disable portals
                        EnableDisablePortal();

                        // Set position and rotation
                        PortalPos(1);

                        // Enable portals
                        EnableDisablePortal();

                        // Play audio
                        portalBlue.GetComponent<AudioSource>().PlayOneShot(PortalTeleport.portalClips[1]);

                        // Disable the movement portion
                        checkPointThree = false;
                    }

                    else if (time >= 18f && !checkPointThree)
                    {
                        checkPointOne = true;
                        checkPointTwo = true;
                        checkPointThree = true;
                        time = 0;
                    }
                }
                
            }
        }
    }

    void PortalPos(int i)
    {
        // Set position and rotation
        portalOrange.transform.position = orangeSpawnPoints[0].transform.position;
        portalOrange.transform.rotation = orangeSpawnPoints[0].transform.rotation;

        portalBlue.transform.position = blueSpawnPoints[i].transform.position;
        portalBlue.transform.rotation = blueSpawnPoints[i].transform.rotation;
    }
}
