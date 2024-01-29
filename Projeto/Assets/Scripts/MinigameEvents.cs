using System;

public class MinigameEvents
{
    public event Action OnEnterMinigame;
    public void EnterMinigame()
    {
        OnEnterMinigame?.Invoke();
    }

    public event Action OnExitMinigame;
    public void ExitMinigame() {  
        OnExitMinigame?.Invoke();
    }
}
