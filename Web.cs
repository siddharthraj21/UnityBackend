using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
      void Start() {
        // StartCoroutine(GetDate());

        StartCoroutine(RegisterUser("rajeev","password"));
    }
 
    public IEnumerator GetDate() {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/UnityBackend/tutorial.php");
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
    public IEnumerator GetUsers() {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/UnityBackend/user.php");
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
     public IEnumerator Login(string username, string password) {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

 
        using(UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackend/login.php", form)) {
            yield return www.Send();
     
            if(www.isNetworkError) {
                Debug.Log(www.error);
            }
            else {
                Debug.Log(www.downloadHandler.text);  
            }
        }
    }
     public IEnumerator RegisterUser (string username, string password) {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

 
        using(UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackend/registeruser.php", form)) {
            yield return www.Send();
     
            if(www.isNetworkError) {
                Debug.Log(www.error);
            }
            else {
                Debug.Log(www.downloadHandler.text);  
            }
        }
    }
}
