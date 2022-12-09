using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusSmoother : MonoBehaviour
{

    private RectTransform rt;
    private RectTransform targetRt;

    public float width;

    // Start is called before the first frame update
    void Start()
    {
        rt = this.GetComponent<RectTransform>();
        targetRt = GameObject.Find("hp").GetComponent<RectTransform>();

        rt.ForceUpdateRectTransforms();
        width = rt.sizeDelta.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetRt.sizeDelta.x < width)
        {
            width -= 0.5f;
        }
        else
        {
            width = targetRt.sizeDelta.x;
        }

        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
    }
}
