using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Player player;
    [Range(1.5f, 4f)] public float distance = 2.5f;
    [Range(4f, 8f)] public float cameraHeight = 6.25f;

    void Update()
    {
        PlayerFollow();
    }

    private void PlayerFollow()
    {
        this.transform.position = new Vector3((player.transform.position.x - distance), cameraHeight, (player.transform.position.z - distance));
    }
}
