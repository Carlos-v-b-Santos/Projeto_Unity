using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;

public class TimeSystem : MonoBehaviour
{
    public static TimeSystem Instance;
    [SerializeField] private const string day_pp = "day";
    [SerializeField] private const string bday_pp = "bday";
    [SerializeField] private const string month_pp = "month";
    [SerializeField] private const string year_pp = "year";

    BusinessDay businessDay;

    //escala de tempo
    [SerializeField] private float timeScale = 300.0f;

    public int Day
    {
        get
        {
            return PlayerPrefs.GetInt(day_pp, 1);
        }
        set
        {
            PlayerPrefs.SetInt(day_pp, value);
        }
    }

    public int BDay
    {
        get
        {
            return PlayerPrefs.GetInt(bday_pp, 1);
        }
        set
        {
            PlayerPrefs.SetInt(bday_pp, value);
        }
    }
    public int Month
    {
        get
        {
            return PlayerPrefs.GetInt(month_pp, 1);
        }
        set
        {
            PlayerPrefs.SetInt(month_pp, value);
        }
    }

    public int Year
    {
        get
        {
            return PlayerPrefs.GetInt(year_pp, 2024);
        }
        set
        {
            PlayerPrefs.SetInt(year_pp, value);
        }
    }
    //campos

    [SerializeField] private bool timeOn = true;
    //public int day, month, year;
    public int hour, minute;
    private float second;
    
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);


        //day = 1;
        //month = 1;
        //hour = 8;
        //minute = 0;
        //second  = 0;

        //StartCoroutine(TimeSystemWork());
        //dataText = GameObject.Find("/Canvas/CalendarPanel/Data").GetComponent<TextMeshProUGUI>();
        //if (dataText != null)
        //    Debug.Log("data encontrada");
        //else Debug.Log("data nao encontrada");


        //timeText = GameObject.Find("/Canvas/CalendarPanel/Time").GetComponent<TextMeshProUGUI>();
        //if (timeText != null)
        //    Debug.Log("tempo encontrado");
        //else Debug.Log("tempo nao encontrado");
        //StartTimeSystem();



        StartTimeSystemMorning();
        

    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Mais que um TimeSystem");
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);



    }

    public void StartTimeSystem()
    {
        timeOn = true;
    }

    public void StartTimeSystemMorning()
    {
        //Day = PlayerPrefs.GetInt(day_pp);
        //Month = PlayerPrefs.GetInt(month_pp);
        //Year = PlayerPrefs.GetInt(year_pp);
        hour = 8;
        minute = 0;
        second = 0;
        StartTimeSystem();
    //    StartCoroutine(TimeSystemWork());
    }

    public void StartTimeSystemAfternoon()
    {
        //Day = PlayerPrefs.GetInt(day_pp);
        //Month = PlayerPrefs.GetInt(month_pp);
        //Year = PlayerPrefs.GetInt(year_pp);
        hour = 14;
        minute = 0;
        second = 0;
        StartTimeSystem();
    }

    public void PauseTimeSystem()
    {
        timeOn = false;
    }
    public void PauseTimeSystem(TextAsset inkJSON)
    {
        timeOn = false;
    //    StopCoroutine(TimeSystemWork());
    }

    //IEnumerator TimeSystemWork()
    //{
    //    second += TimesScale * Time.deltaTime;
    //    CalculateTime();
        //CalculateCalendar();//caso o CalculateTime() seja apagado

        
   //     yield return new WaitForSeconds(0);
    //    TextUpdateCalendar();
   // }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!timeOn)
            return;

        second += timeScale * Time.deltaTime;
        CalculateTime();
        //CalculateCalendar();//caso o CalculateTime() seja apagado
        //TextUpdateCalendar();

        if (hour == 12)
        {
            //hour = 0;
            GameEventsManager.Instance.timeEvents.EndMorningWork();
            GameManager.Instance.ExitMinigame();
            StartTimeSystemAfternoon();
        }

        if (hour == 18)
        {
            CalculateCalendar();
            SaveTime();
            GameEventsManager.Instance.timeEvents.EndWorkingDay();
            GameManager.Instance.ExitMinigame();
            StartTimeSystemMorning();
        }

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
        Day++;
        if(Day > 30)
        {
            Day = 1;
            Month++;
            if(Month > 12)
            {
                Month = 1;
                Year++;
            }
        }

        BDay++;
        if (BDay > 5)
        {
            BDay = 1;
            Day += 2;
        }
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.dialogueEvents.OnEnterDialogue += PauseTimeSystem;
        GameEventsManager.Instance.dialogueEvents.OnExitDialogue += StartTimeSystem;
        GameEventsManager.Instance.timeEvents.OnStartMorningWork += StartTimeSystemMorning;
        GameEventsManager.Instance.timeEvents.OnStartAfternoonWork += StartTimeSystemAfternoon;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.dialogueEvents.OnEnterDialogue -= PauseTimeSystem;
        GameEventsManager.Instance.dialogueEvents.OnExitDialogue -= StartTimeSystem;
        GameEventsManager.Instance.timeEvents.OnStartMorningWork -= StartTimeSystemMorning;
        GameEventsManager.Instance.timeEvents.OnStartAfternoonWork -= StartTimeSystemAfternoon;
    }

    private void SaveTime()
    {
        //PlayerPrefs.SetInt(day_pp, Day);
        //PlayerPrefs.SetInt(month_pp, Month);
        //PlayerPrefs.SetInt(year_pp, Year);
    }

    private void OnApplicationQuit()
    {
        SaveTime();
    }
}
