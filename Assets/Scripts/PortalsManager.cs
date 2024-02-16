using UnityEngine;

public class PortalsManager : MonoBehaviour
{
    Portal[] portals;

    void Start()
    {
        portals = FindObjectsOfType<Portal>();
        InitializePortals();
    }

    private void InitializePortals()
    {
        for(int i = 0; i < portals.Length/2; i++)
        {
            int index = i + portals.Length / 2;

            if (portals[index] != null)
            {
                portals[i].SetPortal(portals[index]);
                portals[index].SetPortal(portals[i]);
            }
        }

        foreach (Portal p in portals)
            p.PrintInfo();
    }

   
}
