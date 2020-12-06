using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollContent : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Screen.width > Screen.height)
        {
            if(Mathf.Abs(this.GetComponent<RectTransform>().offsetMax.y - this.GetComponent<RectTransform>().offsetMin.y - 723.0f) > 5)
            {
                this.GetComponent<RectTransform>().offsetMin = new Vector2(this.GetComponent<RectTransform>().offsetMin.x, -723.0f);
                this.GetComponent<RectTransform>().offsetMax = new Vector2(this.GetComponent<RectTransform>().offsetMax.x, 0.0f);
            }
        }
        else
        {
            if(Mathf.Abs(this.GetComponent<RectTransform>().offsetMax.y - this.GetComponent<RectTransform>().offsetMin.y - 1136.0f) > 5)
            {
                this.GetComponent<RectTransform>().offsetMin = new Vector2(this.GetComponent<RectTransform>().offsetMin.x, -1136.0f);
                this.GetComponent<RectTransform>().offsetMax = new Vector2(this.GetComponent<RectTransform>().offsetMax.x, 0.0f);
            }
        }
    }
}
