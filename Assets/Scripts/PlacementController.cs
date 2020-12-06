using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementController : MonoBehaviour
{
    private ARRaycastManager raycastManager;

    public GameObject placementBase;

    public bool placementIsValid = false;

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        placementBase = transform.GetChild(0).gameObject;

        placementBase.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        // Shoot Rays using raycast from the center of the screen 
        raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
        
        // If the rays hit the detected plane, transform its position and rotation
        if(hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if(!placementBase.activeInHierarchy)
            {
                placementBase.SetActive(true); 
            }

            placementIsValid = true;
        }

        // Rotate the placement direction to the direction of the phone
        // var cameraForward = Camera.current.transform.forward;
        // var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
        // transform.rotation = Quaternion.LookRotation(cameraBearing);
    }

}
