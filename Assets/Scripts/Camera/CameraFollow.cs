// CameraFollow: Smoothly moves the attached camera to follow a target object,
// adjusting its position based on the provided offset and speed.
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public FloatReference speed;
    public Vector3Variable offset;

    private Vector3 targetPos;

    private void Update()
    {
        if (target == null)
            return;

        targetPos = target.position + offset.value;
        transform.position = Vector3.Slerp(transform.position, targetPos, speed.Value * Time.deltaTime);
    }
}