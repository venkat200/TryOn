using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ObjectRotate : MonoBehaviour
{
    float rotationSpeed = 3;

    public int AllowRotation = 1;

    public GameObject cameraModule; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cameraModule.activeSelf)
            AllowRotation = 1;
        else
            AllowRotation = 0;
    }

    void OnMouseDrag()
    {
        float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad * AllowRotation;
        float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad * AllowRotation;

        if (rotationX > -0.3f && rotationX < 0.3f)
        {
            transform.RotateAround(Vector3.up, -rotationX);
            // transform.RotateAround(Vector3.right, rotationY);
        }
    }

}





