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
    }

    void Start()
    {
        Vector3 averagePosition = Vector3.zero;
        children.ForEach(child => averagePosition += child.GetPosition());
        averagePosition /= children.Count;

        if (children.Count >= 1)
        {
            setLineRendererPosition();
            
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

        setLineRendererPosition();
    }

    private void Update()
    {
        setLineRendererPosition();
    }

    private void setLineRendererPosition()
    {
        if (_parents.Count >= 1)
        {
            Vector3 averageSiblingPosition = Vector3.zero;
            _parents[0].children.ForEach(siblings => averageSiblingPosition += siblings.GetPosition());
            averageSiblingPosition /= _parents[0].children.Count;

            lineRenderer.SetPosition(0, new Vector3(averageSiblingPosition.x, _parents[0].GetPosition().y - 1));
            lineRenderer.SetPosition(1, new Vector3(transform.position.x, _parents[0].GetPosition().y - 1));
        }
        else
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position);
        }

        lineRenderer.SetPosition(2, transform.position);

        if (children.Count >= 1)
        {
            Vector3 averageChildPosition = Vector3.zero;
            children.ForEach(child => averageChildPosition += child.GetPosition());
            averageChildPosition /= children.Count;

            lineRenderer.SetPosition(3, new Vector3(averageChildPosition.x, transform.position.y));
            lineRenderer.SetPosition(4, new Vector3(averageChildPosition.x, transform.position.y - 1));

        }
        else
        {
            lineRenderer.SetPosition(3, transform.position);
            lineRenderer.SetPosition(4, transform.position);
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SelectRelative()
    {
        image.color = Color.cyan;
        lineRenderer.startColor = Color.magenta;
    }
}