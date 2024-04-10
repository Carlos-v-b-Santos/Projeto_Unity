using System;

public class TimeEvents
{

    //sem uso no momento
    public event Action OnEndMorningWork;
    public void EndMorningWork()
    {
        OnEndMorningWork?.Invoke();
    }

    //sem uso no momento
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
