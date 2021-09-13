using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AreaControl : MonoBehaviour, IScrollHandler
{
    private Touch touch0;
    private Touch touch1;
    
    private Vector3 initialScale;

    [SerializeField]
    public float zoomSpeed = 0.001f;
    [SerializeField]
    private float maxZoom = 5f;
    
    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;

    private void Awake()
    {
        initialScale = transform.localScale;
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
            
            print("scrolling");
            var delta = Vector3.one * (difference * zoomSpeed);
            var desiredScale = transform.localScale + delta;

            desiredScale = ClampDesiredScale(desiredScale);

            transform.localScale = desiredScale;
        }
    }

    public void OnScroll(PointerEventData eventData)
    {
        print("scrolling");
        var delta = Vector3.one * (eventData.scrollDelta.y * zoomSpeed);
        var desiredScale = transform.localScale + delta;

        desiredScale = ClampDesiredScale(desiredScale);

        transform.localScale = desiredScale;
    }

    private Vector3 ClampDesiredScale(Vector3 desiredScale)
    {
        desiredScale = Vector3.Max(initialScale / 2, desiredScale);
        desiredScale = Vector3.Min(initialScale * maxZoom, desiredScale);
        return desiredScale;
    }
}