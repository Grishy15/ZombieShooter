using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    TextMeshProUGUI textKill;

    private int killCount;
    void Awake()
    {
        textKill = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void UpdateCountKillText()
    {
        textKill.text = "Kill Streak: " + killCount.ToString();
    }

    public void SetCountKill(int killAmount)
    {
        killCount += killAmount;
        UpdateCountKillText();
    }
}
