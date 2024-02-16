using UnityEngine;

public class GravityController : MonoBehaviour
{
    // Toggle variable to switch gravity
    private bool flipGravity = false;

    void Update()
    {
        // Check for user input or any condition to flip gravity
        if (Input.GetKeyDown(KeyCode.Space))
        {
            flipGravity = !flipGravity;

            // Flip gravity direction
            if (flipGravity)
            {
                Physics.gravity = new Vector3(0, -9.8f, 0); // Standard gravity in Unity
            }
            else
            {
                Debug.Log("AHHHHH Gravity flippedddd");
                Physics.gravity = new Vector3(0, 9.8f, 0); // Flipped gravity
            }
        }
    }
}
