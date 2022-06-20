using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeEditorWindow : MonoBehaviour
{
    private TMP_InputField inputField;
    private CameraHandler cameraHandler;
    // Start is called before the first frame update
    void Start()
    {
        cameraHandler = FindObjectOfType<CameraHandler>();
        inputField = GetComponent<TMP_InputField>();

        inputField.onSelect.AddListener(DisableCameraHandler);
        inputField.onDeselect.AddListener(EnableCameraHandler);
    }

    private void DisableCameraHandler(string val)
    {
        cameraHandler.gameObject.SetActive(false);
    }
    private void EnableCameraHandler(string val)
    {
        cameraHandler.gameObject.SetActive(true);
    }
}
