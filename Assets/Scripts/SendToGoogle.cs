using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class SendToGoogle : MonoBehaviour
{
    // https://docs.google.com/forms/u/1/d/e/1FAIpQLScAKUaeTVtmaZVdJtC2UGpBmcAurawS4vsSKxxMW0_3XSgHCQ/formResponse
    [SerializeField] private string URL;
    
    // data needs to collect
    private long sessionID;
    private long time_level1;
    private long time_level2;
    private long time_level3;
    private long health;
    private int death_level;
    private int total_enemy_level1;
    private int killed_enemy_level1;
    private int total_enemy_level2;
    private int killed_enemy_level2;
    private int total_enemy_level3;
    private int killed_enemy_level3;
    private bool finishSend = false;
    private bool finishEnemySend = false;


    public void Send(long sessionID, long time_level1, long time_level2, long time_level3, int death_level, int health)
    {
        // Assign variables
        this.sessionID = sessionID;
        this.time_level1 = time_level1;
        this.time_level2 = time_level2;
        this.time_level3 = time_level3;
        this.death_level = death_level;
        this.health = health;
        finishSend = true;
        if (finishSend & finishEnemySend)
        {
            StartCoroutine(Post(sessionID.ToString(), time_level1.ToString(), time_level2.ToString(), time_level3.ToString(), health.ToString(), death_level.ToString(), total_enemy_level1.ToString(), killed_enemy_level1.ToString(), total_enemy_level2.ToString(), killed_enemy_level2.ToString(), total_enemy_level3.ToString(), killed_enemy_level3.ToString()));
            finishSend = false;
            finishEnemySend = false;
        }
    }

    public void enemySend(int total_enemy_level1, int killed_enemy_level1, int total_enemy_level2, int killed_enemy_level2, int total_enemy_level3, int killed_enemy_level3)
    {
        // Assign variables
        
        this.total_enemy_level1 = 5;
        this.killed_enemy_level1 = 10;
        this.total_enemy_level2 = total_enemy_level2;
        this.killed_enemy_level2 = killed_enemy_level2;
        this.total_enemy_level3 = total_enemy_level3;
        this.killed_enemy_level3 = killed_enemy_level3;
        finishEnemySend = true;
        if (finishSend & finishEnemySend)
        {
            StartCoroutine(Post(sessionID.ToString(), time_level1.ToString(), time_level2.ToString(), time_level3.ToString(), health.ToString(), death_level.ToString(), total_enemy_level1.ToString(), killed_enemy_level1.ToString(), total_enemy_level2.ToString(), killed_enemy_level2.ToString(), total_enemy_level3.ToString(), killed_enemy_level3.ToString()));
            
            finishSend = false;
            finishEnemySend = false;
        }
    }


    public IEnumerator Post(string sessionID, string time_level1, string time_level2, string time_level3, string health, string death_level, string total_enemy_level1, string killed_enemy_level1, string total_enemy_level2, string killed_enemy_level2, string total_enemy_level3, string killed_enemy_level3)
    {
        // Create the form and enter responses
        WWWForm form = new WWWForm();
        form.AddField("entry.2147114500", sessionID);
        form.AddField("entry.1520665706", time_level1);
        form.AddField("entry.395357265", time_level2);
        form.AddField("entry.1702477465", time_level3);
        form.AddField("entry.1270885527", health);
        form.AddField("entry.1433072369", death_level);
        form.AddField("entry.1493968021", total_enemy_level1);
        form.AddField("entry.1140383565", killed_enemy_level1);
        form.AddField("entry.1678029494", total_enemy_level2);
        form.AddField("entry.1786326949", killed_enemy_level2);
        form.AddField("entry.571703737", total_enemy_level3);
        form.AddField("entry.631109625", killed_enemy_level3);
        Debug.Log(total_enemy_level1);
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}