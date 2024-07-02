using UnityEngine;

public class LevelPortal : MonoBehaviour
{
    public string levelScene;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLIDED WITH " + other.name + " TAG: " + other.tag);
        if (other.tag == "Player")
        {
            Scene_Manager.instance.ChangeSceneDirectly(levelScene);
        }

    }
}
