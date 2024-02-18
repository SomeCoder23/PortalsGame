using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public Vector2 flipDirectionTime;
    [Tooltip("If this is true, only the first number will be used from the flip duration range above.")]
    public bool fixedFlipDuration = false;

    [Header("Position")]
    public bool move = true;
    public Vector2 blockSpeed;
    public Vector3 direction;

    [Header("Rotation")]
    public bool rotate = false;
    public bool flip = true;
    public Vector3 rotationSpeed = new Vector3(2f, 1f, 2f);

    [Header("Scale")]
    public bool scale = false;
    public Vector3 scaleSpeed = new Vector3(0.5f, 1f, 2f);

    [Header("Other Properties")]
    public bool selfDestructs = false;
    public float timeTillDestructs = 1f;
    public bool causesDamage = false;
    public int damage = 10;


    float timer;
    float speed;

    void Start()
    {
        timer = fixedFlipDuration? flipDirectionTime.x: GetRandomRange(flipDirectionTime);
        int startUp = Random.Range(0, 2);
        speed = GetRandomRange(blockSpeed);
        speed = startUp == 1 ? speed : speed * -1;
    }

    void Update()
    {
        if(move)
         transform.Translate(direction * speed * Time.deltaTime);

        if(rotate)
            transform.Rotate(rotationSpeed * Time.deltaTime);

        if (scale)
            transform.localScale += scaleSpeed * Time.deltaTime;

        if (timer > 0)
            timer -= Time.deltaTime;
        else
        {
            timer = fixedFlipDuration ? flipDirectionTime.x : GetRandomRange(flipDirectionTime);
            speed *= -1;
            scaleSpeed *= -1;

            if (rotate && flip)
                rotationSpeed *= -1;
        }
    }


    float GetRandomRange(Vector2 range)
    {
        return Random.Range(range.x, range.y);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(selfDestructs)
                Destroy(gameObject, timeTillDestructs);

            if (causesDamage)
                Debug.Log("Ouch! Player health -" + damage);
        }
    }

}
