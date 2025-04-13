using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixDistanceToCamera : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    public Vector3 offset;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        if (target == null)
        {
            target = cam.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 decal = target.transform.position - cam.transform.position + offset;
        transform.position = cam.transform.position + decal + (cam.transform.forward * distance);
    }
}
