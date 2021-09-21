using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleController : MonoBehaviour
{
    private float _scaleFactor;
    private float mouseWheelZoomSensitivity = 7f;
    private float touchZoomSensitivity = 0.001f;
    private CanvasScaler _canvasScaler;
    
    // Start is called before the first frame update
    void Start()
    {
        _canvasScaler = GetComponent<CanvasScaler>();
        _scaleFactor = _canvasScaler.scaleFactor;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.touchCount == 2){
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            var zoomModifier = (touchZero.deltaPosition - touchOne.deltaPosition).magnitude * touchZoomSensitivity;
            
            print(zoomModifier);
            
            if (prevMagnitude > currentMagnitude)
                _scaleFactor -= zoomModifier;
            if (prevMagnitude < currentMagnitude)
                _scaleFactor += zoomModifier;
        }
        // handle zoom
        if (Input.mouseScrollDelta.y != 0)
        {
            float distance = Input.mouseScrollDelta.y * mouseWheelZoomSensitivity * Time.deltaTime;
            _scaleFactor += distance;
        }
    }

    private void LateUpdate()
    {
        _scaleFactor = Mathf.Clamp(_scaleFactor, 0.5f, 1.5f);
        _canvasScaler.scaleFactor = _scaleFactor;
    }
}
