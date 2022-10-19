using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMask : MonoBehaviour
{
    public GameObject MaskPanel; 

    public void DisableMask() {
        MaskPanel.SetActive(false);
        Time.timeScale = 0;
    }
}
