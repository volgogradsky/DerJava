using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject BG;
    public GameObject RegPanel;
    public GameObject AuthPanel;

    public GameObject Tick;
    public GameObject Cross;

    string InputName;
    string InputPass;
    string InputPass2;

    private void Start()
    {
        InputName = "";
        InputPass = "";
        InputPass2 = "";
    }

    public void OnClick()
    {
        InputName = GameObject.Find("Canvas/BG/InputField/Text").GetComponent<Text>().text;
        if (PlayerPrefs.HasKey(InputName))
        {
            AuthPanel.SetActive(true);
            GameObject.Find("Canvas/AuthPanel/Text").GetComponent<Text>().text += InputName;
            BG.SetActive(false);
        }
        else
        {
            RegPanel.SetActive(true);
            GameObject.Find("Canvas/RegPanel/Text").GetComponent<Text>().text += InputName;
            BG.SetActive(false);
        }
    }

    public void OnClickAuth()
    {
        InputPass = GameObject.Find("Canvas/AuthPanel/InputField/Text").GetComponent<Text>().text;

        if (PlayerPrefs.GetInt(InputName) == InputPass.GetHashCode())
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            GameObject.Find("Canvas/AuthPanel/InputField/Text").GetComponent<Text>().text = "";
            GameObject.Find("Canvas/AuthPanel/InputField/Placeholder").GetComponent<Text>().text = "Пароль не верный";
            GameObject.Find("Canvas/AuthPanel/InputField/Placeholder").GetComponent<Text>().color = new Color32(192, 57, 43, 255);
        }
    }

    public void OnClickRegister()
    {
        InputPass = GameObject.Find("Canvas/AuthPanel/InputField/Text").GetComponent<Text>().text;
        InputPass2 = GameObject.Find("Canvas/AuthPanel/InputField2/Text").GetComponent<Text>().text;

        if (InputPass == InputPass2)
        {
            PlayerPrefs.SetInt(InputName, InputPass.GetHashCode());
            SceneManager.LoadScene(1);
        }
        else { Cross.SetActive(true); }
        
    }

    private void Update()
    {
        if (RegPanel.activeSelf)
        {
            if ((InputPass == InputPass2) && InputPass != "")
            {
                Cross.SetActive(false);
                Tick.SetActive(true);
            }
        }

    }

}
