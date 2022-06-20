using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraHandler : MonoBehaviour
{
    //cached ref
    [SerializeField] private CinemachineVirtualCamera cmCamera;

    //config
    [SerializeField] private float moveSpeed = 10f;


    //state 
    [Header("Camera Zoom")]
    [SerializeField] private float zoomAmount = 2f;
    [SerializeField] private float zoomSpeed = 10f;
    [SerializeField] private float minZoom = 10f;
    [SerializeField] private float maxZoom = 50f;


    private float camOrthoSize;
    private float targetCamOrthoSize;

    private Vector2 moveDir;

    private void Start()
    {
        camOrthoSize = cmCamera.m_Lens.OrthographicSize;
        targetCamOrthoSize = camOrthoSize;
    }
    private void Update()
    {
        HandleMovement();

        var a = cmCamera.m_Lens.OrthographicSize;

        targetCamOrthoSize += -Input.mouseScrollDelta.y * zoomAmount;
        targetCamOrthoSize = Mathf.Clamp(targetCamOrthoSize, minZoom, maxZoom);

        camOrthoSize = Mathf.Lerp(camOrthoSize, targetCamOrthoSize, zoomSpeed * Time.deltaTime);
        cmCamera.m_Lens.OrthographicSize = camOrthoSize;

    }

    private void HandleMovement()
    {
        moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveDir.Normalize();

        transform.position += (Vector3)moveDir * moveSpeed * Time.deltaTime;
    }
}
