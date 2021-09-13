using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public int Position = 0;
    public Text text;

    private RelativeController parent;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<RelativeController>();
        image = GetComponent<Image>();
    }

    public void setText(string name)
    {
        text.text = name;
        image.color = new Color(255, 255, 255);
    }
}