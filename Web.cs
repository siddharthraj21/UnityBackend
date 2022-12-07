using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Web : MonoBehaviour
{

    public InputField username;
    public InputField password;
    public GameObject panel2;
    public GameObject panel1;

    private string id = "";
    void Start()
    {



         StartCoroutine(sendJSON(15.347, 10923, "Fat"));
       //StartCoroutine(Login("rajeev", "password"));
       //Debug.Log(id);
      // StartCoroutine(GetFace(id));
        //showitems();
        // Debug.Log("done");
        //StartCoroutine(showitems());

    }

    public void login3()
    {

        StartCoroutine(showitems(username.text, password.text));


    }

    public void showinfo()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
        
    }

    public IEnumerator showitems(string username, string password)

    {

        yield return Login(username, password);

        Debug.Log(id);
        //StartCoroutine(GetFace(id));

        WWWForm form = new WWWForm();
        form.AddField("faceid", 1);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackend/GetFace.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }

    }


    public IEnumerator sendJSON(double val, int id, string Att)
    {
        WWWForm form = new WWWForm();
        form.AddField("Att", Att);
        form.AddField("id", id);
        form.AddField("val", val.ToString());


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackend/sendJSON.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("success");
            }
        }



}

    public IEnumerator GetDate()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/UnityBackend/tutorial.php");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
    public IEnumerator GetUsers()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/UnityBackend/user.php");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        /*
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackend/login.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Main.instance.UserInfo.setID(www.downloadHandler.text);
            }
        }
        */

        
        
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackend/GetId.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Main.instance.UserInfo.setID(www.downloadHandler.text);
                id = www.downloadHandler.text;
              


            }
        }

        









    }

    public IEnumerator GetFace(string id)
    {
        WWWForm form = new WWWForm();
        form.AddField("faceid", id);
        
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackend/GetFace.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }



    }


    public IEnumerator RegisterUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackend/registeruser.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
