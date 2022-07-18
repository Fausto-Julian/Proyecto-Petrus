using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private bool isCursorLook;
    [SerializeField] private Transform targetFollow;

    private void Awake()
    {
        if (isCursorLook)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void LateUpdate()
    {
        try
        {
            transform.position = targetFollow.position;
            transform.rotation = targetFollow.rotation;

        }
        catch
        {
            targetFollow = GameObject.FindGameObjectWithTag("SpawnPointPlayer").transform;
        }
    }
}
