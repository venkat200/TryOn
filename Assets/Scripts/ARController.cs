using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARController : MonoBehaviour
{
    public GameObject Object;

    public GameObject LoadingPage_Panel;
    public GameObject HomePage_Panel;

    public GameObject Transition;

    public GameObject Item_1_Refrigerator, Item_2_TV_TableTop, Item_3_Sofa, Item_4_Table, Item_5_TV_WallMount, Item_6_Watch, Item_7_Statue;

    public GameObject PlaneTrackingCamera, ImageTracking_1_Camera, ImageTracking_2_Camera; 
    public GameObject DescriptionCamera;
    public GameObject DescriptionPage_Item_1, DescriptionPage_Item_2, DescriptionPage_Item_3, DescriptionPage_Item_4, DescriptionPage_Item_5, DescriptionPage_Item_6, DescriptionPage_Item_7;

    public int currentProduct = 0;

    public GameObject TryARPage_Item_1, TryARPage_Item_2, TryARPage_Item_3, TryARPage_Item_4, TryARPage_Item_5, TryARPage_Item_6, TryARPage_Item_7;
    public GameObject PlaneTrackingLoading_Panel;

    bool placeInAR = false;
    public bool objectPlacedInAR = false;

    private PlacementController placementController;
    public GameObject placementBase;
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        placementController = placementBase.GetComponent<PlacementController>();

        LoadingPage_Panel.SetActive(true);
        HomePage_Panel.SetActive(false);

        StartCoroutine(StartLoading());

        DescriptionCamera.SetActive(true);
        PlaneTrackingCamera.SetActive(false);
        ImageTracking_1_Camera.SetActive(false);
        ImageTracking_2_Camera.SetActive(false);

        Item_1_Refrigerator.SetActive(false);
        Item_2_TV_TableTop.SetActive(false);
        Item_3_Sofa.SetActive(false);
        Item_4_Table.SetActive(false);
        Item_5_TV_WallMount.SetActive(false);
        Item_6_Watch.SetActive(false);
        Item_7_Statue.SetActive(false);

        DescriptionPage_Item_1.SetActive(false);
        DescriptionPage_Item_2.SetActive(false);
        DescriptionPage_Item_3.SetActive(false);
        DescriptionPage_Item_4.SetActive(false);
        DescriptionPage_Item_5.SetActive(false);
        DescriptionPage_Item_6.SetActive(false);
        DescriptionPage_Item_7.SetActive(false);

        TryARPage_Item_1.SetActive(false);
        TryARPage_Item_2.SetActive(false);
        TryARPage_Item_3.SetActive(false);
        TryARPage_Item_4.SetActive(false);
        TryARPage_Item_5.SetActive(false);
        TryARPage_Item_6.SetActive(false);
        TryARPage_Item_7.SetActive(false);

        PlaneTrackingLoading_Panel.SetActive(false);

        Item_1_Refrigerator.GetComponent<LeanTwistRotateAxis>().enabled = false;
        Item_2_TV_TableTop.GetComponent<LeanTwistRotateAxis>().enabled = false;
        Item_3_Sofa.GetComponent<LeanTwistRotateAxis>().enabled = false;
        Item_4_Table.GetComponent<LeanTwistRotateAxis>().enabled = false;
        Item_5_TV_WallMount.GetComponent<LeanTwistRotateAxis>().enabled = false;
        Item_6_Watch.GetComponent<LeanTwistRotateAxis>().enabled = false;
        Item_7_Statue.GetComponent<LeanTwistRotateAxis>().enabled = false;

        Item_1_Refrigerator.GetComponent<LeanDragTranslate>().enabled = false;
        Item_2_TV_TableTop.GetComponent<LeanDragTranslate>().enabled = false;
        Item_3_Sofa.GetComponent<LeanDragTranslate>().enabled = false;
        Item_4_Table.GetComponent<LeanDragTranslate>().enabled = false;
        Item_5_TV_WallMount.GetComponent<LeanDragTranslate>().enabled = false;
        Item_6_Watch.GetComponent<LeanDragTranslate>().enabled = false;
        Item_7_Statue.GetComponent<LeanDragTranslate>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && placementController.placementIsValid && placeInAR)
        {
            if(currentProduct == 1)
            {
                Item_1_Refrigerator.SetActive(true);
                Item_1_Refrigerator.transform.position = placementController.transform.position;
                Item_1_Refrigerator.transform.rotation = placementController.transform.rotation;
                placeInAR = false;
                objectPlacedInAR = true;
            }
            else if(currentProduct == 2)
            {
                Item_2_TV_TableTop.SetActive(true);
                Item_2_TV_TableTop.transform.position = placementController.transform.position;
                Item_2_TV_TableTop.transform.rotation = placementController.transform.rotation;
                placeInAR = false;
                objectPlacedInAR = true;
            }
            else if (currentProduct == 3)
            {
                Item_3_Sofa.SetActive(true);
                Item_3_Sofa.transform.position = placementController.transform.position;
                Item_3_Sofa.transform.rotation = placementController.transform.rotation;
                placeInAR = false;
                objectPlacedInAR = true;
            }
            else if (currentProduct == 4)
            {
                Item_4_Table.SetActive(true);
                Item_4_Table.transform.position = placementController.transform.position;
                Item_4_Table.transform.rotation = placementController.transform.rotation;
                placeInAR = false;
                objectPlacedInAR = true;
            }
            else if (currentProduct == 5)
            {
                Item_5_TV_WallMount.SetActive(true);
                Item_5_TV_WallMount.transform.position = placementController.transform.position;
                Item_5_TV_WallMount.transform.rotation = placementController.transform.rotation;
                placeInAR = false;
                objectPlacedInAR = true;
            }
            /*
            else if (currentProduct == 6)
            {
                Item_6_Watch.SetActive(true);
                Item_6_Watch.transform.position = placementController.transform.position;
                Item_6_Watch.transform.rotation = placementController.transform.rotation;
                placeInAR = false;
                objectPlacedInAR = true;
            }
            else if (currentProduct == 7)
            {
                Item_7_Statue.SetActive(true);
                Item_7_Statue.transform.position = placementController.transform.position;
                Item_7_Statue.transform.rotation = placementController.transform.rotation;
                placeInAR = false;
                objectPlacedInAR = true;
            }
            */
        }
    }

    public IEnumerator StartLoading()
    {
        LoadingPage_Panel.SetActive(true);
        yield return new WaitForSeconds(5);
        LoadingPage_Panel.SetActive(false);

        HomePage_Panel.SetActive(true);
        Transition.SetActive(true);
        Transition.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(1, 0, t));
            Transition.GetComponent<Image>().color = newColor;
            yield return null;
        }
        Transition.SetActive(false);
    }

    public void ResetPosition()
    {
        Item_1_Refrigerator.transform.localPosition = new Vector3(-0.6585374f, 1.852345f, 2.253419f);
        Item_1_Refrigerator.transform.localEulerAngles = new Vector3(0, 0, 0);
        Item_1_Refrigerator.transform.localScale = new Vector3(1, 1, 1);

        Item_2_TV_TableTop.transform.localPosition = new Vector3(-0.6585374f, 1.852345f, 2.253419f);
        Item_2_TV_TableTop.transform.localEulerAngles = new Vector3(0, 0, 0);
        Item_2_TV_TableTop.transform.localScale = new Vector3(1, 1, 1);

        Item_3_Sofa.transform.localPosition = new Vector3(-0.6585374f, 1.852345f, 2.253419f);
        Item_3_Sofa.transform.localEulerAngles = new Vector3(0, 0, 0);
        Item_3_Sofa.transform.localScale = new Vector3(1, 1, 1);

        Item_4_Table.transform.localPosition = new Vector3(-0.6585374f, 1.852345f, 2.253419f);
        Item_4_Table.transform.localEulerAngles = new Vector3(0, 0, 0);
        Item_4_Table.transform.localScale = new Vector3(1, 1, 1);

        Item_5_TV_WallMount.transform.localPosition = new Vector3(-0.6585374f, 1.852345f, 2.253419f);
        Item_5_TV_WallMount.transform.localEulerAngles = new Vector3(0, 0, 0);
        Item_5_TV_WallMount.transform.localScale = new Vector3(1, 1, 1);

        Item_6_Watch.transform.localPosition = new Vector3(0, 0, 0);
        Item_6_Watch.transform.localEulerAngles = new Vector3(0, 0, 0);
        Item_6_Watch.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

        Item_7_Statue.transform.localPosition = new Vector3(0, 0, 0);
        Item_7_Statue.transform.localEulerAngles = new Vector3(0, 0, 0);
        Item_7_Statue.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }



    public IEnumerator LoadProductDescription(int productID)
    {
        Transition.SetActive(true);
        Transition.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        HomePage_Panel.SetActive(false);

        DescriptionPage_Item_1.SetActive(false);
        DescriptionPage_Item_2.SetActive(false);
        DescriptionPage_Item_3.SetActive(false);
        DescriptionPage_Item_4.SetActive(false);
        DescriptionPage_Item_5.SetActive(false);
        DescriptionPage_Item_6.SetActive(false);
        DescriptionPage_Item_7.SetActive(false);

        if(productID == 1)
        {
            DescriptionPage_Item_1.SetActive(true);
            Item_1_Refrigerator.SetActive(true);

            Item_1_Refrigerator.transform.localPosition = new Vector3(-0.6585374f, 1.852345f, 2.253419f);
            Item_1_Refrigerator.transform.localEulerAngles = new Vector3(0, 0, 0);

            DescriptionCamera.transform.localPosition = new Vector3(0, 0.557f, 3.736f);
            DescriptionCamera.transform.localEulerAngles = new Vector3(0, -180, 0);
        }
        else if (productID == 2)
        {
            DescriptionPage_Item_2.SetActive(true);
            Item_2_TV_TableTop.SetActive(true);

            Item_2_TV_TableTop.transform.localPosition = new Vector3(-0.6585374f, 1.95f, 2.253419f);
            Item_2_TV_TableTop.transform.localEulerAngles = new Vector3(0, 0f, 0);
            Item_2_TV_TableTop.transform.localScale = new Vector3(1.2972f, 1.2972f, 1.2972f);

            DescriptionCamera.transform.localPosition = new Vector3(0, 0.557f, 3.736f);
            DescriptionCamera.transform.localEulerAngles = new Vector3(0, -180, 0);
        }
        else if (productID == 3)
        {
            DescriptionPage_Item_3.SetActive(true);
            Item_3_Sofa.SetActive(true);
            Item_3_Sofa.transform.localScale = new Vector3(0.88172f, 0.88172f, 0.88172f);

            DescriptionCamera.transform.localPosition = new Vector3(0, 0.557f, 3.736f);
            DescriptionCamera.transform.localEulerAngles = new Vector3(0, -180, 0);
        }
        else if (productID == 4)
        {
            DescriptionPage_Item_4.SetActive(true);
            Item_4_Table.SetActive(true);

            Item_4_Table.transform.localPosition = new Vector3(-0.6585374f, 1.852345f, 2.253419f);
            Item_4_Table.transform.localEulerAngles = new Vector3(0, 0f, 0);
            Item_4_Table.transform.localScale = new Vector3(1f, 1f, 1f);

            DescriptionCamera.transform.localPosition = new Vector3(0, 2.5f, 3.736f);
            DescriptionCamera.transform.localEulerAngles = new Vector3(31.29f, -180, 0);
        }
        else if (productID == 5)
        {
            DescriptionPage_Item_5.SetActive(true);
            Item_5_TV_WallMount.SetActive(true);

            Item_5_TV_WallMount.transform.localPosition = new Vector3(-0.6585374f, 1.852345f, 2.253419f);
            Item_5_TV_WallMount.transform.localEulerAngles = new Vector3(90, 0f, 0);
            Item_5_TV_WallMount.transform.localScale = new Vector3(1f, 1f, 1f);

            DescriptionCamera.transform.localPosition = new Vector3(0, -0.29f, 2.41f);
            DescriptionCamera.transform.localEulerAngles = new Vector3(0, -180, 0);
        }
        else if (productID == 6)
        {
            DescriptionPage_Item_6.SetActive(true);
            Item_6_Watch.SetActive(true);

            Item_6_Watch.transform.localPosition = new Vector3(0, 0, 0);
            Item_6_Watch.transform.localEulerAngles = new Vector3(0, -90, -53.456f);
            Item_6_Watch.transform.localScale = new Vector3(0.3202584f, 0.3202584f, 0.3202584f);

            DescriptionCamera.transform.localPosition = new Vector3(0.66f, -1.64f, -1.74f);
            DescriptionCamera.transform.localEulerAngles = new Vector3(30, -180, 0);
        }
        else if (productID == 7)
        {
            DescriptionPage_Item_7.SetActive(true);
            Item_7_Statue.SetActive(true);

            Item_7_Statue.transform.localEulerAngles = new Vector3(0, 37.7f, 0);

            DescriptionCamera.transform.localPosition = new Vector3(0.663f, -1.371f, -1.46f);
            DescriptionCamera.transform.localEulerAngles = new Vector3(30, -180, 0);
        }

        DescriptionCamera.SetActive(true);
        PlaneTrackingCamera.SetActive(false);
        ImageTracking_1_Camera.SetActive(false);
        ImageTracking_2_Camera.SetActive(false);

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(1, 0, t));
            Transition.GetComponent<Image>().color = newColor;
            yield return null;
        }

        Transition.SetActive(false);
    }

    public void OnClickProduct(int productID)
    {
        currentProduct = productID;
        StartCoroutine(LoadProductDescription(productID));
    }



    public IEnumerator LoadHomePage()
    {
        Transition.SetActive(true);
        Transition.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        HomePage_Panel.SetActive(true);

        DescriptionPage_Item_1.SetActive(false);
        DescriptionPage_Item_2.SetActive(false);
        DescriptionPage_Item_3.SetActive(false);
        DescriptionPage_Item_4.SetActive(false);
        DescriptionPage_Item_5.SetActive(false);
        DescriptionPage_Item_6.SetActive(false);
        DescriptionPage_Item_7.SetActive(false);

        DescriptionCamera.SetActive(true);
        PlaneTrackingCamera.SetActive(false);
        ImageTracking_1_Camera.SetActive(false);
        ImageTracking_2_Camera.SetActive(false);

        ResetPosition();

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(1, 0, t));
            Transition.GetComponent<Image>().color = newColor;
            yield return null;
        }

        Transition.SetActive(false);

        Item_1_Refrigerator.SetActive(false);
        Item_2_TV_TableTop.SetActive(false);
        Item_3_Sofa.SetActive(false);
        Item_4_Table.SetActive(false);
        Item_5_TV_WallMount.SetActive(false);
        Item_6_Watch.SetActive(false);
        Item_7_Statue.SetActive(false);
    }

    public void OnClickHome()
    {
        currentProduct = 0;
        StartCoroutine(LoadHomePage());
    }



    public IEnumerator LoadingTryARPage(int productID)
    {
        LoadingPage_Panel.SetActive(true);

        DescriptionPage_Item_1.SetActive(false);
        DescriptionPage_Item_2.SetActive(false);
        DescriptionPage_Item_3.SetActive(false);
        DescriptionPage_Item_4.SetActive(false);
        DescriptionPage_Item_5.SetActive(false);
        DescriptionPage_Item_6.SetActive(false);
        DescriptionPage_Item_7.SetActive(false);

        Item_1_Refrigerator.SetActive(false);
        Item_2_TV_TableTop.SetActive(false);
        Item_3_Sofa.SetActive(false);
        Item_4_Table.SetActive(false);
        Item_5_TV_WallMount.SetActive(false);
        Item_6_Watch.SetActive(false);
        Item_7_Statue.SetActive(false);

        DescriptionCamera.SetActive(false);

        if(productID == 1)
        {
            PlaneTrackingCamera.SetActive(true);
            ImageTracking_1_Camera.SetActive(false);
            ImageTracking_2_Camera.SetActive(false);

            TryARPage_Item_1.SetActive(true);
            TryARPage_Item_2.SetActive(false);
            TryARPage_Item_3.SetActive(false);
            TryARPage_Item_4.SetActive(false);
            TryARPage_Item_5.SetActive(false);
            TryARPage_Item_6.SetActive(false);
            TryARPage_Item_7.SetActive(false);
        }
        else if(productID == 2)
        {
            PlaneTrackingCamera.SetActive(true);
            ImageTracking_1_Camera.SetActive(false);
            ImageTracking_2_Camera.SetActive(false);

            TryARPage_Item_1.SetActive(false);
            TryARPage_Item_2.SetActive(true);
            TryARPage_Item_3.SetActive(false);
            TryARPage_Item_4.SetActive(false);
            TryARPage_Item_5.SetActive(false);
            TryARPage_Item_6.SetActive(false);
            TryARPage_Item_7.SetActive(false);
        }
        else if(productID == 3)
        {
            PlaneTrackingCamera.SetActive(true);
            ImageTracking_1_Camera.SetActive(false);
            ImageTracking_2_Camera.SetActive(false);

            TryARPage_Item_1.SetActive(false);
            TryARPage_Item_2.SetActive(false);
            TryARPage_Item_3.SetActive(true);
            TryARPage_Item_4.SetActive(false);
            TryARPage_Item_5.SetActive(false);
            TryARPage_Item_6.SetActive(false);
            TryARPage_Item_7.SetActive(false);
        }
        else if(productID == 4)
        {
            PlaneTrackingCamera.SetActive(true);
            ImageTracking_1_Camera.SetActive(false);
            ImageTracking_2_Camera.SetActive(false);

            TryARPage_Item_1.SetActive(false);
            TryARPage_Item_2.SetActive(false);
            TryARPage_Item_3.SetActive(false);
            TryARPage_Item_4.SetActive(true);
            TryARPage_Item_5.SetActive(false);
            TryARPage_Item_6.SetActive(false);
            TryARPage_Item_7.SetActive(false);
        }
        else if(productID == 5)
        {
            PlaneTrackingCamera.SetActive(true);
            ImageTracking_1_Camera.SetActive(false);
            ImageTracking_2_Camera.SetActive(false);

            TryARPage_Item_1.SetActive(false);
            TryARPage_Item_2.SetActive(false);
            TryARPage_Item_3.SetActive(false);
            TryARPage_Item_4.SetActive(false);
            TryARPage_Item_5.SetActive(true);
            TryARPage_Item_6.SetActive(false);
            TryARPage_Item_7.SetActive(false);
        }
        else if(productID == 6)
        {
            PlaneTrackingCamera.SetActive(false);
            ImageTracking_1_Camera.SetActive(true);
            ImageTracking_2_Camera.SetActive(false);

            TryARPage_Item_1.SetActive(false);
            TryARPage_Item_2.SetActive(false);
            TryARPage_Item_3.SetActive(false);
            TryARPage_Item_4.SetActive(false);
            TryARPage_Item_5.SetActive(false);
            TryARPage_Item_6.SetActive(true);
            TryARPage_Item_7.SetActive(false);
        }
        else if(productID == 7)
        {
            PlaneTrackingCamera.SetActive(false);
            ImageTracking_1_Camera.SetActive(false);
            ImageTracking_2_Camera.SetActive(true);

            TryARPage_Item_1.SetActive(false);
            TryARPage_Item_2.SetActive(false);
            TryARPage_Item_3.SetActive(false);
            TryARPage_Item_4.SetActive(false);
            TryARPage_Item_5.SetActive(false);
            TryARPage_Item_6.SetActive(false);
            TryARPage_Item_7.SetActive(true);
        }
        
        ResetPosition();

        if (productID != 6 && productID != 7)
        {
            placementController.placementIsValid = false;
            objectPlacedInAR = false;
        }

        yield return new WaitForSeconds(4);

        Transition.SetActive(true);

        if (productID != 6 && productID != 7)
        {
            PlaneTrackingLoading_Panel.SetActive(true);
        }

        LoadingPage_Panel.SetActive(false);
        Transition.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(1, 0, t));
            Transition.GetComponent<Image>().color = newColor;
            yield return null;
        }
        Transition.SetActive(false);

        if(productID != 6 && productID !=7)
        {
            yield return new WaitUntil(() => placementController.placementIsValid == true);
            placeInAR = true;
            PlaneTrackingLoading_Panel.SetActive(false);
        }
    }

    public void OnClickTryAR(int productID)
    {
        currentProduct = productID;

        Item_1_Refrigerator.GetComponent<LeanTwistRotateAxis>().enabled = true;
        Item_2_TV_TableTop.GetComponent<LeanTwistRotateAxis>().enabled = true;
        Item_3_Sofa.GetComponent<LeanTwistRotateAxis>().enabled = true;
        Item_4_Table.GetComponent<LeanTwistRotateAxis>().enabled = true;
        Item_5_TV_WallMount.GetComponent<LeanTwistRotateAxis>().enabled = true;
        Item_6_Watch.GetComponent<LeanTwistRotateAxis>().enabled = true;
        Item_7_Statue.GetComponent<LeanTwistRotateAxis>().enabled = true;

        Item_1_Refrigerator.GetComponent<LeanDragTranslate>().enabled = true;
        Item_2_TV_TableTop.GetComponent<LeanDragTranslate>().enabled = true;
        Item_3_Sofa.GetComponent<LeanDragTranslate>().enabled = true;
        Item_4_Table.GetComponent<LeanDragTranslate>().enabled = true;
        Item_5_TV_WallMount.GetComponent<LeanDragTranslate>().enabled = true;
        Item_6_Watch.GetComponent<LeanDragTranslate>().enabled = true;
        Item_7_Statue.GetComponent<LeanDragTranslate>().enabled = true;

        StartCoroutine(LoadingTryARPage(productID));
    }



    public void OnClickBack()
    {
        TryARPage_Item_1.SetActive(false);
        TryARPage_Item_2.SetActive(false);
        TryARPage_Item_3.SetActive(false);
        TryARPage_Item_4.SetActive(false);
        TryARPage_Item_5.SetActive(false);
        TryARPage_Item_6.SetActive(false);
        TryARPage_Item_7.SetActive(false);

        Item_1_Refrigerator.SetActive(false);
        Item_2_TV_TableTop.SetActive(false);
        Item_3_Sofa.SetActive(false);
        Item_4_Table.SetActive(false);
        Item_5_TV_WallMount.SetActive(false);
        Item_6_Watch.SetActive(false);
        Item_7_Statue.SetActive(false);

        objectPlacedInAR = false;

        PlaneTrackingLoading_Panel.SetActive(false);

        placeInAR = false;

        Item_1_Refrigerator.GetComponent<LeanTwistRotateAxis>().enabled = false;
        Item_2_TV_TableTop.GetComponent<LeanTwistRotateAxis>().enabled = false;
        Item_3_Sofa.GetComponent<LeanTwistRotateAxis>().enabled = false;
        Item_4_Table.GetComponent<LeanTwistRotateAxis>().enabled = false;
        Item_5_TV_WallMount.GetComponent<LeanTwistRotateAxis>().enabled = false;
        Item_6_Watch.GetComponent<LeanTwistRotateAxis>().enabled = false;
        Item_7_Statue.GetComponent<LeanTwistRotateAxis>().enabled = false;

        Item_1_Refrigerator.GetComponent<LeanDragTranslate>().enabled = false;
        Item_2_TV_TableTop.GetComponent<LeanDragTranslate>().enabled = false;
        Item_3_Sofa.GetComponent<LeanDragTranslate>().enabled = false;
        Item_4_Table.GetComponent<LeanDragTranslate>().enabled = false;
        Item_5_TV_WallMount.GetComponent<LeanDragTranslate>().enabled = false;
        Item_6_Watch.GetComponent<LeanDragTranslate>().enabled = false;
        Item_7_Statue.GetComponent<LeanDragTranslate>().enabled = false;

        ResetPosition();

        StartCoroutine(LoadProductDescription(currentProduct));
    }

}
