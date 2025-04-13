using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontToCamera : MonoBehaviour
{
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.rotation = Quaternion.LookRotation(-cam.transform.position);// * Quaternion.Euler(0, 90, 0)
    }


}
