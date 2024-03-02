using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    [SerializeField] private SaveData clockData;
    [SerializeField] private TextMeshProUGUI clockText;

    [SerializeField] private bool stopTime;

    void Start()
    {
        clockData.SetClock(8, 55);
        InvokeRepeating("UpdateTime", 0.0f, 2.0f);
    }

    void Update()
    {
        if (stopTime) CancelInvoke();
    }

    void UpdateTime()
    {
        clockData.IncreaseTime();
        clockText.text = $"{clockData.clockHours}:{(clockData.clockMinutes.ToString().Length == 1 ? "0" + clockData.clockMinutes.ToString() : clockData.clockMinutes)}";

        if (clockData.clockHours == 24) stopTime = true;
    }
}
