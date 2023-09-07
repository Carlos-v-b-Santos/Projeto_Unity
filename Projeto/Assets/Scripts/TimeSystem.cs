using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeSystem : MonoBehaviour
{
    //escala de tempo
    [SerializeField] private float TimesScale = 300.0f; 

    //campos
    public TextMeshProUGUI dataText;
    public TextMeshProUGUI timeText;

    private int day, month, hour, minute;
    private float second;
    
    // Start is called before the first frame update
    void Start()
    {
        day = 1;
        month = 1;
        hour = 0;
        minute = 0;
        second  = 0;

        //StartCoroutine(CalculateSeconds());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(!timeOn)
          //  retun

        second += TimesScale * Time.deltaTime;
        CalculateTime();
        //CalculateCalendar();//caso o CalculateTime() seja apagado

        TextUpdateCalendar();
    }

    void TextUpdateCalendar()
    {
        dataText.text = string.Format("dia:"+day+"/mes:"+month);
        timeText.text = string.Format(hour+":"+minute);
    }

    void CalculateTime()
    //calcula o relogio
    {
        if (second >= 60)
        {
            minute++;
            second = 0;
            if(minute >= 60)
            {
                minute = 0;
                hour++;
                if(hour >= 24)
                {
                    hour = 0;
                    CalculateCalendar();
                }
            }
        }
    }

    //===========arrumar depois===========
    void CalculateCalendar()
    //calcula os dias e meses
    {
        day++;
        if(day >= 30)
        {
            day = 1;
            month++;
            if(month > 12)
            {
                month = 1;
            }
        }
    }
}