using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;          // The object to follow.
    public float smoothSpeed = 5.0f; // The higher the value, the smoother the camera movement.
    public Vector3 offset = new Vector3(0, 0, -10); // Camera's offset from the target.

    void FixedUpdate()
    {
        if (target != null)
        {
            // Calculate the desired camera position based on the target's position and offset.
            Vector3 desiredPosition = target.position + offset;

            // Use SmoothDamp to smoothly move the camera to the desired position.
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
