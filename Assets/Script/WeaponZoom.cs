using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera cameraFOV;
    [SerializeField] float zoomOutFOV = 60f;
    [SerializeField] float zoomInFOV = 20f;


    bool zoomInToggle =false;
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomInToggle == false )
            {
                zoomInToggle = true;
                cameraFOV.fieldOfView = zoomInFOV;
            }
            else
            {
                zoomInToggle = false;
                cameraFOV.fieldOfView = zoomOutFOV;

            }
        }
    }
}
