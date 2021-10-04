using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    public Sex sex;
    public TextMeshProUGUI text;
    public Image _image;
    private bool markedDown;
    private CanvasScaler _canvasScaler;

    public bool MarkedDown => markedDown;

    // relatives lists
    public List<ImageController> children;
    private List<ImageController> _parents = new List<ImageController>();
    private List<ImageController> _partners = new List<ImageController>();

    #region getter and setter
    public List<ImageController> Parents => _parents;

    public List<ImageController> Partners
    {
        get => _partners;
        set => _partners = value;
    }
    #endregion
    
    private void Awake()
    {
        _lineRenderer = GetComponentInChildren<LineRenderer>();
        _canvasScaler = FindObjectsOfType<CanvasScaler>().First();
    }

    void Start()
    {
        if (children.Count >= 1)
        {
            setLineRendererPosition();

            foreach (ImageController child in children)
            {
                child.SetRelativeParent(this);
            }

            var relativeController = GetComponentInParent<RelativeController>();
            relativeController.OnRelativeTapped(relativeController.CurrentRelative);
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
        _image.color = ImageControllerUtils.getColorFromHex("#DD9866");
        markedDown = false;

        // transform.position = Camera.main.ScreenToWorldPoint(Vector3.zero);

        // lineRenderer.startColor = Color.magenta;
        // lineRenderer.endColor = Color.magenta;
        // children.ForEach(child => child.GetComponent<LineRenderer>().startColor = Color.magenta);
        // _parents.ForEach(parent => parent.GetComponent<LineRenderer>().endColor = Color.magenta);
    }

    public void UnselectRelative(string name)
    {
        text.text = name;
        _image.color = ImageControllerUtils.getColorFromHex("#EEEDED");
        markedDown = false;
        
        // lineRenderer.startColor = Color.black;
        // lineRenderer.endColor = Color.black;
    }

    public void ResetRelative(string name)
    {
        text.text = name;
        _image.color = ImageControllerUtils.getColorFromHex("#161616");
        markedDown = true;
        
        // lineRenderer.startColor = Color.black;
        // lineRenderer.endColor = Color.black;
    }

    private void setLineRendererPosition()
    {
        _lineRenderer.widthMultiplier = 5.0f * _canvasScaler.scaleFactor;

        if (_parents.Count >= 1)
        {
            Vector3 averageSiblingPosition = Vector3.zero;
            _parents[0].children.ForEach(siblings => averageSiblingPosition += siblings.transform.position);
            averageSiblingPosition /= _parents[0].children.Count;

            float yCenterPosition = ImageControllerUtils.getCenterYPositionBetweenSiblingsAndParents(_parents[0], this);
            _lineRenderer.SetPosition(0, new Vector3(averageSiblingPosition.x, yCenterPosition));
            _lineRenderer.SetPosition(1, new Vector3(_lineRenderer.gameObject.transform.position.x, yCenterPosition));
        }
        else
        {
            _lineRenderer.SetPosition(0, ImageControllerUtils.getPositionAsVector2(_lineRenderer.gameObject.transform.position));
            _lineRenderer.SetPosition(1, ImageControllerUtils.getPositionAsVector2(_lineRenderer.gameObject.transform.position));
        }

        _lineRenderer.SetPosition(2, ImageControllerUtils.getPositionAsVector2(_lineRenderer.gameObject.transform.position));

        if (children.Count >= 1)
        {
            Vector3 averageChildPosition = Vector3.zero;
            children.ForEach(child => averageChildPosition += child.transform.position);
            averageChildPosition /= children.Count;

            float yCenterPosition = ImageControllerUtils.getCenterYPositionBetweenSiblingsAndParents(children[0], this);
            _lineRenderer.SetPosition(3, new Vector3(averageChildPosition.x, _lineRenderer.gameObject.transform.position.y));
            _lineRenderer.SetPosition(4, new Vector3(averageChildPosition.x, yCenterPosition));
        }
        else
        {
            _lineRenderer.SetPosition(3, ImageControllerUtils.getPositionAsVector2(_lineRenderer.gameObject.transform.position));
            _lineRenderer.SetPosition(4, ImageControllerUtils.getPositionAsVector2(_lineRenderer.gameObject.transform.position));
        }
    }
}

class ImageControllerUtils
{
    protected internal static Vector3 getPositionAsVector2(Vector3 vector)
    {
        return new Vector3(vector.x, vector.y, 0);
    }

    protected internal static float getCenterYPositionBetweenSiblingsAndParents(ImageController parent, ImageController sibling)
    {
        return (parent.transform.position.y + sibling.transform.position.y) / 2;
    }
    
    protected internal static Color getColorFromHex(string hex)
    {
        Color newColor = Color.white;
        ColorUtility.TryParseHtmlString(hex, out newColor);
        return newColor;
    }
}

public enum Sex
{
    Male, Female
}