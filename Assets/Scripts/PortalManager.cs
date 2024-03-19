using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public List<GameObject> bluePortals = new List<GameObject>();
    public List<GameObject> orangePortals = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (bluePortals.Count <= 1)
        {
            HandlePortals(bluePortals);
        }

        if (orangePortals.Count <= 1)
        { 
            HandlePortals(orangePortals);
        }
    }

    void HandlePortals(List<GameObject> portals)
    {
        portals.RemoveAt(0);
    }
}
