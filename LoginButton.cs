using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginButton : MonoBehaviour
{
    public TMP_InputField UsernameInput;
    public TMP_InputField PasswordInput;
    public Button LoginB;
    // Start is called before the first frame update
    void Start()
    {
        LoginB.onClick.AddListener(() => {
            StartCoroutine(Main.instance.Web.Login(UsernameInput.text, PasswordInput.text));
        });

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
