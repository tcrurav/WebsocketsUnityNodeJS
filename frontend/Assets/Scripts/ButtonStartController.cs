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

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void SetButtonStartActive()
    {
        Debug.Log(inputName.text + "hola");
        if (inputName.text=="")
        {
            gameObject.SetActive(false);
        } else
        {
            gameObject.SetActive(true);
        }
    }

    public void OnClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MiniGame");
    }
}
