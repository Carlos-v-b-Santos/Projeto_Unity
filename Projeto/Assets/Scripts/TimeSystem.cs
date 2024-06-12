using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeSystem : MonoBehaviour
{
    public static TimeSystem Instance;

    //escala de tempo
    [SerializeField] private float timeScale = 300.0f; 

    //campos
    public TextMeshProUGUI dataText;
    public TextMeshProUGUI timeText;

    [SerializeField] private bool timeOn = true;
    [SerializeField] private int day, month, hour, minute;
    private float second;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        

        day = 1;
        month = 1;
        hour = 0;
        minute = 0;
        second  = 0;

        dataText = GameObject.Find("/Canvas/CalendarPanel/Data").GetComponent<TextMeshProUGUI>();
        if (dataText != null)
            Debug.Log("data encontrada");
        else Debug.Log("data nao encontrada");


        timeText = GameObject.Find("/Canvas/CalendarPanel/Time").GetComponent<TextMeshProUGUI>();
        if (timeText != null)
            Debug.Log("tempo encontrado");
        else Debug.Log("tempo nao encontrado");

        //StartCoroutine(TimeSystemWork());
        StartTimeSystem();
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Mais que um GameManager");
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject);

        
    }

    private void StartTimeSystem()
    {
        timeOn = true;
    //    StartCoroutine(TimeSystemWork());
    }

    private void PauseTimeSystem(TextAsset inkJSON)
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

    private void OnEnable()
    {
        GameEventsManager.Instance.dialogueEvents.OnEnterDialogue += PauseTimeSystem;
        GameEventsManager.Instance.dialogueEvents.OnExitDialogue += StartTimeSystem;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.dialogueEvents.OnEnterDialogue -= PauseTimeSystem;
        GameEventsManager.Instance.dialogueEvents.OnExitDialogue -= StartTimeSystem;
    }
}
