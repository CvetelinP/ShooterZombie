using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamager : MonoBehaviour
{

    [SerializeField] Canvas impactCanvas;
    [SerializeField] float impactTime = 0.3f;


    void Start()
    {
        impactCanvas.enabled = false;
    }

    // Update is called once per frame
    public void ShowDamageImpact()
    {
        StartCoroutine(ShowSplatter());
    }

    IEnumerator ShowSplatter()
    {
        impactCanvas.enabled = true;
        yield return new WaitForSeconds(impactTime);
        impactCanvas.enabled = false;
    }
}
