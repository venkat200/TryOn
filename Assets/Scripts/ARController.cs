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


    private PlacementController placementController;
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        placementController = FindObjectOfType<PlacementController>();

        /*
        LoadingPage_Panel.SetActive(true);
        HomePage_Panel.SetActive(false);

        StartCoroutine(StartLoading());
        */
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && placementController.placementIsValid)
        {
            GameObject placedObject = Instantiate(Object, placementController.transform.position, placementController.transform.rotation);
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
}
