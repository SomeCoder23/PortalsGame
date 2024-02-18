using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionPlatform : MonoBehaviour
{
    [Tooltip("1 for forward and -1 for backwards")]
    public int direction;
    public float speed;

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Colliding with " + collision.gameObject.name);
        MoveObject(collision.gameObject);
    }

    void MoveObject(GameObject thing)
    {
        Debug.Log("Moving..." + thing.name);
        //if (thing.gameObject.GetComponent<StarterAssets.ThirdPersonController>() != null)
        //    thing.gameObject.GetComponent<StarterAssets.ThirdPersonController>().MovePlayer(transform.forward * speed * direction * Time.deltaTime);
        //else 
        thing.transform.Translate(transform.forward * speed * direction * Time.deltaTime);
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    Debug.Log("Not Colliding anymore with " + collision.gameObject.name);
    //    if (collision.gameObject.GetComponent<StarterAssets.ThirdPersonController>() != null)
    //        collision.gameObject.GetComponent<StarterAssets.ThirdPersonController>().StopMoving();

    //}

}
