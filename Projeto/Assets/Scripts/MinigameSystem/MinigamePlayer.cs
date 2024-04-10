using UnityEngine;

public class MinigamePlayer : MonoBehaviour
{
    public int ColorId;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().color = GameplayManager.Instance.Colors[ColorId];
    }
}
