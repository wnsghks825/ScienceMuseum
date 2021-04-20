using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{

    private void Awake()
    {
        //Screen.sleepTimeout = SleepTimeout.NeverSleep;
        //Screen.SetResolution(2560, 1600, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        var rectTransform = GetComponent<RectTransform>();
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rectTransform.GetComponentInParent<Canvas>().GetComponent<RectTransform>().sizeDelta.x);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rectTransform.GetComponentInParent<Canvas>().GetComponent<RectTransform>().sizeDelta.y);
    }

    // Update is called once per frame
    void Update()
    {

    }


}
