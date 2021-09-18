using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public int Position; //todo make this obsolete
    public Text text;
    private Image image;

    public List<ImageController> children;
    private List<ImageController> _parents = new List<ImageController>();

    // Creates a line renderer that follows a Sin() function
    // and animates it.

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponentInChildren<Image>();

        Vector3 averagePosition = Vector3.one;
        children.ForEach(child => averagePosition += child.GetPosition());
        averagePosition /= children.Count;

        if (children.Count >= 1)
        {
            LineRenderer lineRendererTest = CreateLineRenderer(3);
            lineRendererTest.SetPosition(0, transform.position);
            lineRendererTest.SetPosition(1, new Vector3(averagePosition.x, transform.position.y, -10));
            lineRendererTest.SetPosition(2, new Vector3(averagePosition.x, transform.position.y  - 1));
            
            foreach (ImageController child in children)
            {
                LineRenderer lineRenderer = CreateLineRenderer(3);
                child.SetRelativeParent(this);
                lineRenderer.SetPosition(0, new Vector3(averagePosition.x, transform.position.y  - 1));
                lineRenderer.SetPosition(1, new Vector3(child.GetPosition().x, transform.position.y  - 1));
                lineRenderer.SetPosition(2, child.GetPosition());
            }
        }
    }

    private LineRenderer CreateLineRenderer(int positionCount)
    {
        LineRenderer lineRenderer = new GameObject().AddComponent<LineRenderer>();
        lineRenderer.positionCount = positionCount;
        lineRenderer.transform.position = Vector3.one;
        lineRenderer.transform.parent = transform;
        lineRenderer.gameObject.name = "LineRenderer";
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.1f;
        lineRenderer.SetWidth(0.1f, 0.1f);

        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;
        return lineRenderer;
    }

    public void SetText(string name)
    {
        text.text = name;
        image.color = new Color(255, 255, 255);
    }

    public void SetRelativeParent(ImageController parent)
    {
        _parents.Add(parent);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}