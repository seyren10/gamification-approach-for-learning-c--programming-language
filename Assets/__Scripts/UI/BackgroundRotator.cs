using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundRotator : MonoBehaviour
{
    [SerializeField] private RawImage img;
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;

    private void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(xSpeed, ySpeed) * Time.deltaTime, img.uvRect.size);
    }
}
