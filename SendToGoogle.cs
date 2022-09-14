// https://docs.google.com/forms/u/1/d/e/1FAIpQLScAKUaeTVtmaZVdJtC2UGpBmcAurawS4vsSKxxMW0_3XSgHCQ/formResponse
[SerializeField] private string URL;
// data needs to collect
private long _sessionID;
private int _testInt;
private bool _testBool;
private float _testFloat;
public void Send()
{
    // Assign variables
    _testInt = Random.Range(0, 101);
    _testBool = true;
    _testFloat = Random.Range(0.0f, 10.0f);

    StartCoroutine(Post(_sessionID.ToString(), _testInt.ToString(), _testBool.ToString(), _testFloat.ToString()));
}

private IEnumerator Post(string sessionID, string testInt, string testBool, string testFloat)
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
