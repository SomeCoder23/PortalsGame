using UnityEngine;

public class Portal : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(4f, 3f, 3.5f);
    public float teleportTime = 0.2f;

    Portal otherPortal;
    bool isSet = false;
    bool teleporting = false;

    private void Update()
    {
      //  transform.parent.Rotate(rotationSpeed * Time.deltaTime);
    }

    public void SetPortal(Portal portal)
    {
        if (isSet) return;
        otherPortal = portal;
    }

    void Teleport(GameObject other)
    {
        if (!teleporting && otherPortal != null)
        {
            otherPortal.Recieve();
            other.transform.position = otherPortal.gameObject.transform.position;
            //Debug.Log("Teleporting " + other.name + " to ......" + new Vector3(x, y, z));
           Debug.Log("Teleporting to " + otherPortal.gameObject.transform.position);
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
        if(other.tag == "Player")
            Teleport(other.gameObject);

    }

   


}
