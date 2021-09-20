using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public int Position; //todo make this obsolete
    public Text text;
    private Image image;

    public List<ImageController> children;
    private List<ImageController> _parents = new List<ImageController>();

    // Creates a line renderer that follows a Sin() function
    // and animates it.

    // Start is called before the first frame update

    private void Awake()
    {
        image = GetComponentInChildren<Image>();
        lineRenderer = GetComponent<LineRenderer>();
        
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);
        lineRenderer.SetPosition(2, transform.position);
        lineRenderer.SetPosition(3, transform.position);
        lineRenderer.SetPosition(4, transform.position);
    }

    void Start()
    {
        Vector3 averagePosition = Vector3.zero;
        children.ForEach(child => averagePosition += child.GetPosition());
        averagePosition /= children.Count;
        
        if (children.Count >= 1)
        {
            lineRenderer.SetPosition(3, new Vector3(averagePosition.x, transform.position.y));
            lineRenderer.SetPosition(4, new Vector3(averagePosition.x, transform.position.y  - 1));
            
            foreach (ImageController child in children)
            {
                child.SetRelativeParent(this);
            }
        }
    }

    public void SetText(string name)
    {
        text.text = name;
        image.color = new Color(255, 255, 255);
    }

    public void SetRelativeParent(ImageController parent)
    {
        _parents.Add(parent);
        
        Vector3 averagePosition = Vector3.zero;
        _parents[0].children.ForEach(siblings => averagePosition += siblings.GetPosition());
        averagePosition /= _parents[0].children.Count;
        
        print(lineRenderer);
        lineRenderer.SetPosition(0, new Vector3(transform.position.x, _parents[0].GetPosition().y  - 1));
        lineRenderer.SetPosition(1, new Vector3(averagePosition.x, _parents[0].GetPosition().y - 1));
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}