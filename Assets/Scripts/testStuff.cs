using UnityEngine;

public class testStuff : MonoBehaviour
{
    public float moveSpeed = 5f;

    GameObject player;
    Vector3 startPos;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPos = player.transform.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            player.transform.position = startPos;
            Debug.Log("Restarting.....");
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
