using UnityEngine;

public class Portal : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(4f, 3f, 3.5f);
    public float teleportTime = 0.2f;
    public bool rotate = false;

    Portal otherPortal;
    bool isSet = false;
    bool teleporting = false;

    private void Update()
    {
        if(rotate)
            transform.parent.Rotate(rotationSpeed * Time.deltaTime);
    }

    public bool SetPortal(Portal portal)
    {
        if (isSet) return false;
        otherPortal = portal;
        isSet = true;
        return true;
    }

    public bool isPortalSet()
    {
        return isSet;
    }

    void Teleport(GameObject other)
    {
        if (!teleporting && otherPortal != null)
        {
            otherPortal.Recieve();
            Recieve();
            if (other.gameObject.GetComponent<StarterAssets.ThirdPersonController>() != null)
                other.gameObject.GetComponent<StarterAssets.ThirdPersonController>().MoveTo(otherPortal.gameObject.transform.position);
            else other.transform.position = otherPortal.gameObject.transform.position;
        }
    }

    void Recieve()
    {
        teleporting = !teleporting;
        if (teleporting)
            Invoke("Recieve", teleportTime);     
    }

    public void PrintInfo()
    {
        Debug.Log(name + " leads to portal: " + otherPortal.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")            
            Teleport(other.gameObject);

    }

   


}
