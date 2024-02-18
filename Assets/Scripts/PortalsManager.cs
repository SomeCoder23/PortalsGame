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
        bool set = false;

        for (int i = 0; i < portals.Length - 1; i++)
        {
            if (portals[i].isPortalSet()) continue;
            
            while (!set)
            {
                int ranIndex = Random.Range(i + 1, portals.Length);
                if (portals[ranIndex].SetPortal(portals[i]))
                {
                    set = true;
                    portals[i].SetPortal(portals[ranIndex]);
                    //break;
                }
            }

            set = false;
        }

    }

   
}
