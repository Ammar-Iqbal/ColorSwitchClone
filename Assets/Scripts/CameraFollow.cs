using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float yOffset = 2f;

    private void LateUpdate()
    {
        if (target == null) return;

        float newY = Mathf.Max(transform.position.y, target.position.y + yOffset);
        Vector3 desiredPosition = new Vector3(transform.position.x, newY, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}