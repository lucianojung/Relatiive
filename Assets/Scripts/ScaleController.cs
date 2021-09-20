using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleController : MonoBehaviour
{
    private float _distance;
    private float zoomSensitivity = 100.0f;
    private float touchZoomSensitivity = 0.001f;
    private CanvasScaler _canvasScaler;
    
    // Start is called before the first frame update
    void Start()
    {
        _canvasScaler = GetComponent<CanvasScaler>();
        _distance = _canvasScaler.scaleFactor;
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
                _distance -= zoomModifier;
            if (prevMagnitude < currentMagnitude)
                _distance += zoomModifier;
        }
        // handle zoom
        if (Input.mouseScrollDelta.y != 0)
        {
            float distance = Input.mouseScrollDelta.y * zoomSensitivity * Time.deltaTime;
            _distance = distance;
        }
    }

    private void LateUpdate()
    {
        _canvasScaler.scaleFactor = _distance;
    }
}
