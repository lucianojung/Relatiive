using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleController : MonoBehaviour
{
    private Vector2 _distance;
    private float zoomSensitivity = 10_000.0f;
    private CanvasScaler _canvasScaler;
    
    // Start is called before the first frame update
    void Start()
    {
        _canvasScaler = GetComponent<CanvasScaler>();
        _distance = _canvasScaler.referenceResolution;
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

            float difference = currentMagnitude - prevMagnitude;
            
            var delta = difference *  Time.deltaTime;
            
            float distance = delta * zoomSensitivity * Time.deltaTime;
            Debug.Log(distance);
            SetClampedDistance(distance);
        }
        // handle zoom
        if (Input.mouseScrollDelta.y != 0)
        {
            float distance = Input.mouseScrollDelta.y * zoomSensitivity * Time.deltaTime;
            SetClampedDistance(distance);
        }
    }
    
    private void SetClampedDistance(float distance)
    {
        float distanceX = Mathf.Clamp(_distance.x - distance, 0, 10000);
        float distanceY = Mathf.Clamp(_distance.y - distance, 0, 10000);
        _distance = new Vector2(distanceX, distanceY);
    }

    private void LateUpdate()
    {
        _canvasScaler.referenceResolution = _distance;
    }
}
