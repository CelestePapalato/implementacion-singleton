using System;
using UnityEngine;

public class ScoreOnDestroy : MonoBehaviour
{
    public static event Action<int> onEvent;

    [SerializeField]
    int points;
    [SerializeField]
    string SE;

    private void OnDestroy()
    {
        if(points > 0) { onEvent?.Invoke(points); }
        SoundManager.Instance.PlaySE(SE);
    }
}
