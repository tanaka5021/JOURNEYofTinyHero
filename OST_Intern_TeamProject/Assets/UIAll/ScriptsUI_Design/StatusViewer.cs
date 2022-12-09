using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusViewer : MonoBehaviour
{
    [SerializeField]
    protected float maxStatus;
    [SerializeField]
    protected float currentStatus;

    private RectTransform rt;
    private float widthStart;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rt = this.GetComponent<RectTransform>();
        rt.ForceUpdateRectTransforms();
        widthStart = rt.sizeDelta.x;
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        float exrate = currentStatus / maxStatus;
        if (exrate > 1.0f)
        {
            exrate = 1.0f;
        }
        else if (exrate < 0.0f)
        {
            exrate = 0.0f;
        }

        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, widthStart * exrate);
    }
}
