using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public CanvasGroup target;
    public Transform tWASD, activator;

    public float distance;
    public bool isVisible;

    float alpha;

    bool isTargetNear()
    {
        var distanceDelta = tWASD.position - activator.position;
        if (distanceDelta.sqrMagnitude < distance * distance)
        {
            var lookAtDelta = tWASD.position - activator.position;
            if (Vector3.Dot(activator.forward, lookAtDelta.normalized) > 0.95f)
                return true; 
        }
        return false;
    }

    private void Update()
    {
        if (isTargetNear())
        {
            alpha = 1;
            isVisible = true;
        }
        else
        {
            alpha = -1;
            isVisible = false;
        }
        target.alpha = Mathf.Clamp01(target.alpha + alpha * Time.deltaTime);
    }
}
