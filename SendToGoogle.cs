using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class sendToGoogle : MonoBehaviour
{
    // https://docs.google.com/forms/u/1/d/e/1FAIpQLScAKUaeTVtmaZVdJtC2UGpBmcAurawS4vsSKxxMW0_3XSgHCQ/formResponse
    [SerializeField] private string URL;
    // data needs to collect
    private long sessionID;
    private long time_level1;
    private long time_level2;
    private long time_level3;
    private int death_level;
    private int total_enemy_level1;
    private int killed_enemy_level1;
    private int total_enemy_level2;
    private int killed_enemy_level2;
    private int total_enemy_level3;
    private int killed_enemy_level3;


    public void Send(long sessionID, long time_level1, long time_level2, int time_level3, int death_level, int total_enemy_level1, int killed_enemy_level1, int total_enemy_level2, int killed_enemy_level2, int total_enemy_level3, int killed_enemy_level3)
    {
        // Assign variables
        this.sessionID = sessionID;
        this.time_level1 = time_level1;
        this.time_level2 = time_level2;
        this.time_level3 = time_level3;
        this.death_level = death_level;
        this.total_enemy_level1 = total_enemy_level1;
        this.killed_enemy_level1 = killed_enemy_level1;
        this.total_enemy_level2 = total_enemy_level2;
        this.killed_enemy_level2 = killed_enemy_level2;
        this.total_enemy_level3 = total_enemy_level3;
        this.killed_enemy_level3 = killed_enemy_level3;

        StartCoroutine(Post(sessionID.ToString(), time_level1.ToString(), time_level2.ToString(), time_level3.ToString(), death_level.ToString(), total_enemy_level1.ToString(), killed_enemy_level1.ToString(), total_enemy_level2.ToString(), killed_enemy_level2.ToString(), total_enemy_level3.ToString(), killed_enemy_level3.ToString()));
    }

    public IEnumerator Post(string sessionID, string time_level1, string time_level2, string time_level3, string death_level, string total_enemy_level1, string killed_enemy_level1, string total_enemy_level2, string killed_enemy_level2, string total_enemy_level3, string killed_enemy_level3)
    {
        // Create the form and enter responses
        WWWForm form = new WWWForm();
        form.AddField("entry.2147114500", sessionID);
        form.AddField("entry.1520665706", time_level1);
        form.AddField("entry.395357265", time_level2);
        form.AddField("entry.1702477465", time_level3);
        form.AddField("entry.1433072369", death_level);
        form.AddField("entry.1493968021", death_letotal_enemy_level1vel);
        form.AddField("entry.1140383565", killed_enemy_level1);
        form.AddField("entry.1678029494", total_enemy_level2);
        form.AddField("entry.1786326949", killed_enemy_level2);
        form.AddField("entry.571703737", total_enemy_level3);
        form.AddField("entry.631109625", killed_enemy_level3);
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