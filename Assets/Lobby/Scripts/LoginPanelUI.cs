using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;

public class LoginPanelUI : MonoBehaviour
{
    public TMP_InputField usernameInputField;
    public TMP_InputField passwordInputField;
    public bool remembermeSet;
    public Toggle toggleRememberMe;
    private void Start()
    {
       if(PlayerPrefsExtension.GetBool("Toggle"))
        {
            Debug.Log("Inside toggle");
            string password = PlayerPrefs.GetString("Password");
            passwordInputField.text = password;
            string username = PlayerPrefs.GetString("Username");
            usernameInputField.text = username;
        }
       
        
    }

    public void OnClickToggle(bool value)
    {
        if(toggleRememberMe.isOn)
        {
            PlayerPrefsExtension.SetBool("Toggle", true);
            if (!PlayerPrefs.HasKey("Password"))
            {
                PlayerPrefs.SetString("Password", passwordInputField.text);
            }
            else
            {
                string password = PlayerPrefs.GetString("Password");
                passwordInputField.text = password;
            }

            if (!PlayerPrefs.HasKey("Username"))
            {
                PlayerPrefs.SetString("Username", usernameInputField.text);
            }
            else
            {
                string username = PlayerPrefs.GetString("Username");
                usernameInputField.text = username;
            }
        }
    }

}
