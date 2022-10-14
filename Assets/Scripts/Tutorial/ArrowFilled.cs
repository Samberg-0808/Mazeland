using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowFilled: MonoBehaviour
{
    public Image image;
    public float progressPercentage;
    public float target = 100;

    void Start()
    {
        image.fillAmount = 1f;
    }
}