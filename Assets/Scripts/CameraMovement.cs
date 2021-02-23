using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Transform followTransform;
    [SerializeField] private BoxCollider2D mapBounds;

    [SerializeField] float smoothSpeed = 0.125f;
    private Vector3 smoothVelocity;

    [SerializeField] private Vector3 offset;

    private float xMin, xMax, yMin, yMax;
    private float camX, camY;
    private float camOrthSize;
    private float camRatio;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;

        cam = GetComponent<Camera>();
        camOrthSize = cam.orthographicSize;
        camRatio = (xMax + camOrthSize) / 2.0f;
        
    }

    void LateUpdate()
    {
        camX = Mathf.Clamp(followTransform.position.x, xMin + camOrthSize, xMax - camRatio);
        camY = Mathf.Clamp(followTransform.position.y, yMin + camOrthSize, yMax - camOrthSize);

        Vector3 targetPosition = new Vector3(camX, camY, transform.position.z);


        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref smoothVelocity, smoothSpeed);

        transform.position = smoothPosition;

    }
}
