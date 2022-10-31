using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public int enemy_level = 1;

    public bool mutable = true;

    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void updateStatus() {
        mutable = !mutable;
    }
    public void updateColor(int ScoreNum) {
        if (!mutable) {
            sr.color = new Color32(128, 128, 128, 255);
        } else if (mutable && ScoreNum > 0) {
            if (ScoreNum % enemy_level == 0) {
                sr.color = new Color32(93, 255, 185, 255); // change color to green
                gameObject.layer = 10; // change layer to "Fake-enemy" layer 10
            } else {
                sr.color = new Color32(239, 83, 98, 255); // change color to red
                gameObject.layer = 9; // change layer to "Real-enemy" layer 9
            }
        }
    }

}
