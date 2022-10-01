using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SendToGoogle : MonoBehaviour{
    // https://docs.google.com/forms/u/1/d/e/1FAIpQLScAKUaeTVtmaZVdJtC2UGpBmcAurawS4vsSKxxMW0_3XSgHCQ/formResponse
    [SerializeField] private string URL;
    // data needs to collect
    private long sessionID;
    private long time_level1;
    private long time_level2;
    private int death_level;

    public void Send(long sessionID, long time_level1, long time_level2, int death_level)
    {
        // Assign variables
        this.sessionID = sessionID;
        this.time_level1 = time_level1;
        this.time_level2 = time_level2;
        this.death_level = death_level;
        StartCoroutine(Post(sessionID.ToString(), time_level1.ToString(), time_level2.ToString(), death_level.ToString()));
    }

    public IEnumerator Post(string sessionID, string testInt, string testBool, string testFloat)
    {
    // Create the form and enter responses
        WWWForm form = new WWWForm();
        form.AddField("entry.2147114500", sessionID);
        form.AddField("entry.1520665706", testInt);
        form.AddField("entry.395357265", testBool);
        form.AddField("entry.1433072369", testFloat);
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