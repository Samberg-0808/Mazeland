using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomNumberGenerator : MonoBehaviour
{
    public TMP_Text TextBox;
    public int TheNumber;

    void Start()
    {
        TheNumber = Random.Range(-10, 10);
        TextBox.text = "" + TheNumber; 
    } 
}
