using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class Zoom : MonoBehaviour
{
    [SerializeField] GameObject mainCam;
    [SerializeField] Vector3 _zoomCam;
    [SerializeField] Camera zoomCam;
    [SerializeField] GameObject camPos;

    float zoomLevel = 75f;
    public InputActionReference zoom;
    public InputActionReference zoomOut;

    bool isZoom;

    private void Start()
    {
        zoomCam.enabled = false;
    }
    void Update()
    {
        _zoomCam = zoomCam.transform.position;
        

        zoom.action.performed += onZoom;
        zoomOut.action.performed += offZoom;

    }

    void onZoom(InputAction.CallbackContext obj)
    {
        //zoomCam.enabled = true;
        mainCam.transform.position = zoomCam.transform.position + new Vector3(0, 0, zoomLevel);
        mainCam.transform.rotation = zoomCam.transform.rotation;
    }

    void offZoom(InputAction.CallbackContext obj)
    {
        mainCam.transform.position = camPos.transform.position;
        mainCam.transform.rotation = camPos.transform.rotation;
        //zoomCam.enabled = false;
    }
}
