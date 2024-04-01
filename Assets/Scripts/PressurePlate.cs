using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] GameObject plate;
    [SerializeField] GameObject basePlate;
    [SerializeField] GameObject door;
    [SerializeField] GameObject doorFinalPos;
    [SerializeField] Material unLitButton;
    [SerializeField] Material litButton;
    float doorStartingY;
    float plateStartingY;
    bool plateIsActive;
    Vector3 motion;

    AudioSource audioSource;

    void Start()
    {
        motion = new Vector3(0f, .5f, 0f) * Time.deltaTime;
        plateIsActive = false;
        doorStartingY = door.transform.position.y;
        plateStartingY = plate.transform.position.y;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!plateIsActive)
        {
            plate.GetComponent<MeshRenderer>().material = unLitButton;
            
            MovePlateUp();
        }
        else
        {
            plate.GetComponent<MeshRenderer>().material = litButton;
            
            MovePlateDown();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Objective"))
        {
            audioSource.Play();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Objective") || other.CompareTag("Player"))
        {
            //audioSource.PlayOneShot(audioSource.clip, 1f);
            plateIsActive = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Objective") || other.CompareTag("Player"))
        {
            //audioSource.PlayOneShot(audioSource.clip, 1f);
            plateIsActive = false;
        }
    }

    void MovePlateUp()
    {
        if (plate.transform.position.y < plateStartingY)
        {
            plate.transform.position += motion;
        }
        else
        {
            MoveDoorUp();
        }
    }

    void MoveDoorUp()
    {
        if (door.transform.position.y < doorStartingY)
        {
            door.transform.position += motion;
        }
    }

    void MovePlateDown()
    {
        if (plate.transform.position.y > basePlate.transform.position.y)
        {
            plate.transform.position -= motion;
        }

        else
        {
            MoveDoorDown();
        }
            
    }

    void MoveDoorDown()
    {
        if (door.transform.position.y > doorFinalPos.transform.position.y)
        {
            door.transform.position -= motion;
        }
    }

}
