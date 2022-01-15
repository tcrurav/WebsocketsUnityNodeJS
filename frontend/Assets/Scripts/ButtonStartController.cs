using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 
/// </summary>
public class ButtonStartController : MonoBehaviour
{
    public TMP_InputField inputName;
    public TMP_InputField inputIP;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void SetButtonStartActive()
    {
        if (inputName.text!="" && inputIP.text !="")
        {
            gameObject.SetActive(true);
        } else
        {
            gameObject.SetActive(false);
        }
    }

    public void OnClick()
    {
        CrossSceneInformation.Nickname = inputName.text;
        CrossSceneInformation.IP = inputIP.text;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MiniGame");
    }
}
