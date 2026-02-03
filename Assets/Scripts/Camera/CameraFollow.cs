using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null )
        {
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("Player Not Found");
        }
    }
    private void LateUpdate()
    {
        if(target ==  null) { return; }

        Vector3 cameraPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, cameraPosition, smoothSpeed);
        transform.position = smoothPosition;

        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
