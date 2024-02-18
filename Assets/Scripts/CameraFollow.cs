using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset = new Vector3(1f, 0f, 2f);

    GameObject player;
    Vector3 startPos;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player.name);
        startPos = player.transform.position;
    }

    private void Update()
    {
        transform.position = player.transform.position + offset;

        if (Input.GetKey(KeyCode.Return))
        {
            player.transform.position = startPos;
            Debug.Log("Restarting.....");
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    float x = Random.Range(-10, 10);
        //    float y = Random.Range(-10, 10);
        //    float z = Random.Range(-10, 10);
        //    player.transform.position = new Vector3(x, y, z);
        //    Debug.Log("Changing player pos...." + new Vector3(x, y, z));
        //    //Portal[] p = FindObjectsOfType<Portal>();
        //    //int index = Random.Range(0, p.Length);
        //    //player.transform.position = p[index].gameObject.transform.position;

        //    //Debug.Log("New pos: " + player.transform.position);
        //}
    }

}
