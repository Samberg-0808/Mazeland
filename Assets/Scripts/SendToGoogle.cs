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
    private long passed_level;
    private long time;
    private long health;
    private int death_level;
    private int total_enemy;
    private int killed_enemy;
    private int total_point;
    private int gained_point;
    private int total_item;
    private int gained_item;
    private bool finishSend = false;
    private bool finishEnemySend = false;


    public void Send(long sessionID, long passed_level, long time, int death_level, int health)
    {
        // Assign variables
        this.sessionID = sessionID;
        this.passed_level = passed_level;
        this.time = time;
        this.death_level = death_level;
        this.health = health;
        finishSend = true;
        if (finishSend & finishEnemySend)
        {
            StartCoroutine(Post(sessionID.ToString(), passed_level.ToString(), time.ToString(), health.ToString(), death_level.ToString(), total_enemy.ToString(), killed_enemy.ToString(), total_point.ToString(), gained_point.ToString(), total_item.ToString(), gained_item.ToString()));
            finishSend = false;
            finishEnemySend = false;
        }
    }

    public void enemySend(int total_enemy, int killed_enemy, int total_point, int gained_point, int total_item, int gained_item)
    {
        // Assign variables

        this.total_enemy = total_enemy;
        this.killed_enemy = killed_enemy;
        this.total_point = total_point;
        this.gained_point = gained_point;
        this.total_item = total_item;
        this.gained_item = gained_item;
        finishEnemySend = true;
        if (finishSend & finishEnemySend)
        {
            StartCoroutine(Post(sessionID.ToString(), passed_level.ToString(), time.ToString(), health.ToString(), death_level.ToString(), total_enemy.ToString(), killed_enemy.ToString(), total_point.ToString(), gained_point.ToString(), total_item.ToString(), gained_item.ToString()));

            finishSend = false;
            finishEnemySend = false;
        }
    }


    public IEnumerator Post(string sessionID, string passed_level, string time, string health, string death_level, string total_enemy, string killed_enemy, string total_point, string gained_point, string total_item, string gained_item)
    {
        // Create the form and enter responses
        WWWForm form = new WWWForm();
        form.AddField("entry.2147114500", sessionID);
        form.AddField("entry.1520665706", passed_level);
        form.AddField("entry.395357265", time);
        form.AddField("entry.1270885527", health);
        form.AddField("entry.1433072369", death_level);
        form.AddField("entry.1493968021", total_enemy);
        form.AddField("entry.1140383565", killed_enemy);
        form.AddField("entry.1678029494", total_point);
        form.AddField("entry.1786326949", gained_point);
        form.AddField("entry.571703737", total_item);
        form.AddField("entry.631109625", gained_item);
        Debug.Log(total_enemy);
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