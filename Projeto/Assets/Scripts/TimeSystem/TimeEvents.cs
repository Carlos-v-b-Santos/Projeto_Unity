using System;

public class TimeEvents
{
    public event Action OnStartMorningWork;
    public void StartMorningWork()
    {
        OnStartMorningWork?.Invoke();
    }

    public event Action OnEndMorningWork;
    public void EndMorningWork()
    {
        OnEndMorningWork?.Invoke();
    }

    public event Action OnStartAfternoonWork;
    public void StartAfternoonWork()
    {
        OnStartAfternoonWork?.Invoke(); 
    }

    public event Action OnEndAfternoonWork;
    public void EndAfternoonWork()
    {
        OnEndAfternoonWork?.Invoke();
    }


    public event Action OnStartWorkingDay;
    public void StartWorkingDay()
    {
        OnStartWorkingDay?.Invoke();
    }


    public event Action OnEndWorkingDay;
    public void EndWorkingDay()
    {
        OnEndWorkingDay?.Invoke();
    }

    public event Action OnEndWorkWeek;
    public void EndWorkWeek()
    {
        OnEndWorkWeek?.Invoke();
    }

    public event Action OnEndMonth;
    public void EndMonth()
    {
        OnEndMonth?.Invoke();
    }
}
