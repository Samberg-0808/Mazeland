using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image image;
    public float progressPercentage;

    void Start()
    {
        image.fillAmount = 0f;
    }

    public void setProgressBar(int score, int target)
    {
        progressPercentage = score / (float)target;
        image.fillAmount = progressPercentage;
    }
}
