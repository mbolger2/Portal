using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    [Header("Teleporting Information")]
    [Tooltip("The portal that the player wants to teleport to")]
    [SerializeField] GameObject otherPortalTPPoint;

    [Header("Audio Information")]
    [Tooltip("The audio information can be accessed by other scripts")]
    public List<AudioClip> portalClip;
    static public List<AudioClip> portalClips;

    AudioSource audioSource;

    void Start()
    {
        portalClips = portalClip;
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Objective"))
        {
            audioSource.Play();
            other.transform.position = otherPortalTPPoint.transform.position;
            other.transform.forward = otherPortalTPPoint.transform.forward;
        }
    }
}
