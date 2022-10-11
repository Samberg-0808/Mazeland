using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSkipTutorial : MonoBehaviour
{
    public GameObject SkipPanel;
    
    public void OpenPanel()
    {
        if(SkipPanel != null)
        {
            SkipPanel.SetActive(true);
        }
    }
}
