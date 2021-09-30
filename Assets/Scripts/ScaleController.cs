using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleController : MonoBehaviour
{
    private const float MouseWheelZoomSensitivity = 10f;
    private const float TouchZoomSensitivity = 0.001f;
    private const float MINScale = 0.5f;
    private const float MAXScale = 5.0f;
    private float _scaleFactor;
    private CanvasScaler _canvasScaler;

    // Start is called before the first frame update
    void Start()
    {
        // get CanvasScaler to handle zoom
        _canvasScaler = GetComponent<CanvasScaler>();
        // set default scaleFactor at start
        _scaleFactor = _canvasScaler.scaleFactor;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 2){
            // handle finger zoom
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            var zoomModifier = (touchZero.deltaPosition - touchOne.deltaPosition).magnitude * TouchZoomSensitivity;
            // print(zoomModifier);
            
            if (prevMagnitude > currentMagnitude)
                _scaleFactor -= zoomModifier;
            if (prevMagnitude < currentMagnitude)
                _scaleFactor += zoomModifier;
        }
        // handle mouse wheel zoom
        if (Input.mouseScrollDelta.y != 0)
        {
            float distance = Input.mouseScrollDelta.y * MouseWheelZoomSensitivity * Time.deltaTime;
            _scaleFactor += distance;
        }
    }

    private void LateUpdate()
    {
        // set zoom factor
        _scaleFactor = Mathf.Clamp(_scaleFactor, MINScale, MAXScale);
        _canvasScaler.scaleFactor = _scaleFactor;
    }
}
