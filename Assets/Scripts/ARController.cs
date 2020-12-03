using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARController : MonoBehaviour
{
    public GameObject Object;

    private PlacementController placementController;
    // Start is called before the first frame update
    void Start()
    {
        placementController = FindObjectOfType<PlacementController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && placementController.placementIsValid)
        {
            GameObject placedObject = Instantiate(Object, placementController.transform.position, placementController.transform.rotation);
        }
    }
}
