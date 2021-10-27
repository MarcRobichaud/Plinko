using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerPosition;

    private void Update()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        Vector3 pos = playerPosition.position;
        pos.z = transform.position.z;

        transform.position = pos;
    }
}