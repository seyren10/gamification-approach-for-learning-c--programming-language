using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraHandler : MonoBehaviour
{
    //cached ref
    [SerializeField] private CinemachineVirtualCamera cmCamera;

    //config


    [Header("Camera Zoom")]
    [SerializeField] private float zoomAmount = 2f;
    [SerializeField] private float zoomSpeed = 10f;
    [SerializeField] private float minZoom = 10f;
    [SerializeField] private float maxZoom = 50f;

    //state 
    private float camOrthoSize;
    private float targetCamOrthoSize;
    private bool drag;

    private Vector3 mouseOrigin;
    private Vector3 mouseDifference;

    private void Start()
    {
        camOrthoSize = cmCamera.m_Lens.OrthographicSize;
        targetCamOrthoSize = camOrthoSize;
    }
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
          

            mouseDifference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            if (!drag)
            {
                drag = true;
                mouseOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
            drag = false;

        HandleMovement();

        HandleZoom();

    }

    private void HandleZoom()
    {
        var a = cmCamera.m_Lens.OrthographicSize;

        targetCamOrthoSize += -Input.mouseScrollDelta.y * zoomAmount;
        targetCamOrthoSize = Mathf.Clamp(targetCamOrthoSize, minZoom, maxZoom);

        camOrthoSize = Mathf.Lerp(camOrthoSize, targetCamOrthoSize, zoomSpeed * Time.deltaTime);
        cmCamera.m_Lens.OrthographicSize = camOrthoSize;
    }

    private void HandleMovement()
    {
        if (drag)
        {
          
            transform.position = mouseOrigin - mouseDifference;
        }



    }
}
