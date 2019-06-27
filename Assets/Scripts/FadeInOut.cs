using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FadeInOut : MonoBehaviour
{

    public bool full;
    void OnEnable()
    {
        if (gameObject.name == "GetReadyText")
        {
            gameObject.GetComponent<CanvasGroup>().DOFade(0, 2.5f);

        }
        else if (gameObject.name == "GoText")
        {
            gameObject.GetComponent<CanvasGroup>().DOFade(0, 2.5f);
        }

        else
        {
            gameObject.GetComponent<CanvasGroup>().DOFade(1, .6f);
        }
    }

    void Update()
    {
        if (gameObject.name == "Tap")
        {
            if (!full)
            {
                gameObject.GetComponent<CanvasGroup>().DOFade(0, .3f);
                if (gameObject.GetComponent<CanvasGroup>().alpha < .1f)
                {
                    full = true;
                }
            }
            else
            {
                gameObject.GetComponent<CanvasGroup>().DOFade(1, .3f);
                if (gameObject.GetComponent<CanvasGroup>().alpha > .9f)
                {
                    full = false;
                }
            }
        }

    }
}
