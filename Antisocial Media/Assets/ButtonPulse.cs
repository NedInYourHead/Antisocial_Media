using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPulse : MonoBehaviour
{
    float scale = 0.003f;
    float minScale = 0.003f;
    float maxScale = 0.004f;
    float scaleSpeed = 0.001f;

    void FixedUpdate()
    {
        scale += scaleSpeed * Time.deltaTime;
        if (scale > maxScale) 
        {
            scaleSpeed *= -1;
        }
        else if (scale < minScale) 
        {
            scaleSpeed *= -1;
        }
        transform.localScale = new Vector3(scale,scale,scale);
    }
}
