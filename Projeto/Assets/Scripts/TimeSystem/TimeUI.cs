using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI dataText;
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextUpdateCalendar();
    }

    void TextUpdateCalendar()
    {
        int day = TimeSystem.Instance.Day;
        int month = TimeSystem.Instance.Month;
        int hour = TimeSystem.Instance.hour;
        int minute = TimeSystem.Instance.minute;

        dataText.text = string.Format("dia:" + day + "/mes:" + month);
        timeText.text = string.Format(hour + ":" + minute);
    }
}
