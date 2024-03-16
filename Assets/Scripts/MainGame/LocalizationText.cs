using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class LocalizationText : MonoBehaviour
{
    public string key;// The Key Of Text Content

    private void Start()
    {
        Localization();
    }

    public void Localization()
    {
        // Get TMP Text
        TMP_Text tmpText = GetComponent<TMP_Text>();

        // Update TMP Text
        MainGame.TextMeshProManager.UpdateTMPText(tmpText, key);
    }
}
