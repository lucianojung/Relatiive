using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    public Transform[] Relatives;

    private void Start()
    {
        for (int i = 0; i < Relatives.Length; i++)
        {
            _lineRenderer.SetPosition(i, Relatives[i].position);
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = Relatives.Length;
        
    }

    private void Update()
    {
        for (int i = 0; i < Relatives.Length; i++)
        {
            _lineRenderer.SetPosition(i, Relatives[i].position);
        }
    }
}
