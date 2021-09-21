using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    public Sex sex;
    public Text text;
    private Image _image;
    private bool markedDown;

    public bool MarkedDown => markedDown;

    public List<ImageController> children;
    private List<ImageController> _parents = new List<ImageController>();
    private List<ImageController> _partners = new List<ImageController>();

    public List<ImageController> Parents => _parents;

    public List<ImageController> Partners
    {
        get => _partners;
        set => _partners = value;
    }

    private void Awake()
    {
        _image = GetComponentInChildren<Image>();
        _lineRenderer = GetComponent<LineRenderer>();
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

    private void Update()
    {
        setLineRendererPosition();
    }

    public void SetRelativeParent(ImageController parent)
    {
        _parents.Add(parent);
        if (_parents.Count > 1)
        {
            _parents.ForEach(parent => parent.Partners = _parents.Where(partner => partner != parent).ToList());
        }

        setLineRendererPosition();
    }

    public void SelectRelative(string name)
    {
        text.text = name;
        _image.color = Color.cyan;
        markedDown = false;

        // lineRenderer.startColor = Color.magenta;
        // lineRenderer.endColor = Color.magenta;
        // children.ForEach(child => child.GetComponent<LineRenderer>().startColor = Color.magenta);
        // _parents.ForEach(parent => parent.GetComponent<LineRenderer>().endColor = Color.magenta);
    }

    public void UnselectRelative(string name)
    {
        text.text = name;
        _image.color = new Color(255, 255, 255);
        markedDown = false;
        
        // lineRenderer.startColor = Color.black;
        // lineRenderer.endColor = Color.black;
    }

    public void ResetRelative(string name)
    {
        text.text = "name";
        _image.color = Color.black;
        markedDown = true;
        
        // lineRenderer.startColor = Color.black;
        // lineRenderer.endColor = Color.black;
    }

    private void setLineRendererPosition()
    {
        if (_parents.Count >= 1)
        {
            Vector3 averageSiblingPosition = Vector3.zero;
            _parents[0].children.ForEach(siblings => averageSiblingPosition += siblings.GetPosition());
            averageSiblingPosition /= _parents[0].children.Count;

            float yCenterPosition = getCenterYPositionBetweenSiblingsAndParents(_parents[0]);
            _lineRenderer.SetPosition(0, new Vector3(averageSiblingPosition.x, yCenterPosition));
            _lineRenderer.SetPosition(1, new Vector3(transform.position.x, yCenterPosition));
        }
        else
        {
            _lineRenderer.SetPosition(0, getPositionAsVector2(transform.position));
            _lineRenderer.SetPosition(1, getPositionAsVector2(transform.position));
        }

        _lineRenderer.SetPosition(2, getPositionAsVector2(transform.position));

        if (children.Count >= 1)
        {
            Vector3 averageChildPosition = Vector3.zero;
            children.ForEach(child => averageChildPosition += child.GetPosition());
            averageChildPosition /= children.Count;

            float yCenterPosition = getCenterYPositionBetweenSiblingsAndParents(children[0]);
            _lineRenderer.SetPosition(3, new Vector3(averageChildPosition.x, transform.position.y));
            _lineRenderer.SetPosition(4, new Vector3(averageChildPosition.x, yCenterPosition));
        }
        else
        {
            _lineRenderer.SetPosition(3, getPositionAsVector2(transform.position));
            _lineRenderer.SetPosition(4, getPositionAsVector2(transform.position));
        }
    }

    private float getCenterYPositionBetweenSiblingsAndParents(ImageController imageController)
    {
        return (imageController.GetPosition().y + this.transform.position.y) / 2;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private Vector3 getPositionAsVector2(Vector3 vector)
    {
        return new Vector3(vector.x, vector.y, 0);
    }
}

public enum Sex
{
    MALE, FEMALE
}