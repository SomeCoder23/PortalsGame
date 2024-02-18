using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int health = 100;
    Vector3 startPos;

    private void Start()
    {
        startPos = gameObject.transform.position;
    }

    public void MoveTo(Vector3 destination)
    {
        gameObject.transform.position = destination;
        Debug.Log("Player Pos: " + gameObject.transform.position +" Moving player to " + destination);
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        gameObject.transform.position = startPos;
        Debug.Log("DEAD! Restarting...");
        health = 100;
    }
}
