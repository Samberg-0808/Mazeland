using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBlink : MonoBehaviour
{
    public TextMeshProUGUI blink_text;
    //Text blink_text;
    public float BlinkFadeIn = 0.3f;
    public float BlinkStay = 0.7f;
    public float BlinkFadeOut = 0.3f;
    private float _timeChecker = 0;
    private Color _color;
        // Start is called before the first frame update
    void Start()
    {
        //blink_text = GetComponent<Text>();
        blink_text = GetComponent<TextMeshProUGUI>();
        _color = blink_text.color;
    }

    // Update is called once per frame
    void Update()
    {
        _timeChecker += Time.deltaTime;
        if(_timeChecker < BlinkFadeIn)
        {
            blink_text.color = new Color(_color.r, _color.g, _color.b, _timeChecker / BlinkFadeIn);
        }else if (_timeChecker < BlinkFadeIn + BlinkStay)
        {
            blink_text.color = new Color(_color.r, _color.g, _color.b, 1);
        }else if (_timeChecker < BlinkFadeIn + BlinkStay + BlinkFadeOut)
        {
            blink_text.color = new Color(_color.r, _color.g, _color.b, 1 - (_timeChecker - (BlinkFadeIn + BlinkStay)) / BlinkFadeOut);
        }
        else{
            _timeChecker = 0;
        }
    }
}
