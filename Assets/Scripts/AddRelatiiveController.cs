using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AddRelatiiveController : MonoBehaviour
{
    public GameObject label;

    public void showComingSoonLabel()
    {
        label.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
