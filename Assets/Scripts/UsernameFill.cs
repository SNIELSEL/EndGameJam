using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UsernameFill : MonoBehaviour
{
    public TMP_InputField inputField;

    public void SetName()
    {
        GameObject.FindWithTag("ConnectionManager").GetComponent<PlayFabManager>().nameField = inputField;
        inputField.text = PlayerPrefs.GetString("UserName");
    }

}
