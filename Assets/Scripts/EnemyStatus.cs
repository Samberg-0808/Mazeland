using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public int enemy_level = 1;

    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void updateColor(int ScoreNum) {
        if (ScoreNum > 0) {
            if (ScoreNum % enemy_level == 0) {
                sr.color = new Color32(93, 255, 185, 255);//green
            } else {
                sr.color = new Color32(239, 83, 98, 255);//red
            }
        }
    }
}
