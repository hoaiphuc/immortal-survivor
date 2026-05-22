using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothTime = 0.15f;
    [SerializeField] Collider2D bounds;

    Vector3 velocity;
    Camera cam;

    void Awake() => cam = GetComponent<Camera>();

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desired = new Vector3(target.position.x, target.position.y, transform.position.z);
        Vector3 smoothed = Vector3.SmoothDamp(transform.position, desired, ref velocity, smoothTime);

        if (bounds != null)
        {
            Bounds b = bounds.bounds;
            float halfH = cam.orthographicSize;
            float halfW = halfH * cam.aspect;

            float minX = b.min.x + halfW;
            float maxX = b.max.x - halfW;
            float minY = b.min.y + halfH;
            float maxY = b.max.y - halfH;

            smoothed.x = minX > maxX ? b.center.x : Mathf.Clamp(smoothed.x, minX, maxX);
            smoothed.y = minY > maxY ? b.center.y : Mathf.Clamp(smoothed.y, minY, maxY);
        }

        transform.position = smoothed;
    }

    public void SetBounds(Collider2D newBounds) => bounds = newBounds;
}
