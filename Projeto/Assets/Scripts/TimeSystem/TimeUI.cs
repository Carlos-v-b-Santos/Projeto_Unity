using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI dataText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI bdayText;

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

        switch (TimeSystem.Instance.BDay)
        {
            case 1:
                bdayText.text = string.Format("SEG");
                break;
            case 2:
                bdayText.text = string.Format("TER");
                break;
            case 3:
                bdayText.text = string.Format("QUA");
                break;
            case 4:
                bdayText.text = string.Format("QUI");
                break;
            case 5:
                bdayText.text = string.Format("SEX");
                break;
            default:
                Debug.Log("erro ao gerar a data");
                break;
        }
    }
}
