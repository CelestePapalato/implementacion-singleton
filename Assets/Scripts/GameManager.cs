using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Text puntajeText;

    int puntaje = 0;

    private void OnEnable()
    {
        PlayerController.onDead += GameOver;   
    }

    private void OnDisable()
    {
        PlayerController.onDead -= GameOver;
    }

    private void Start()
    {
        SoundManager.Instance.PlayBGM("gameplay", true);
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0;
        SoundManager.Instance.PlayBGM("game over", false);
        SoundManager.Instance.PlaySE("game over");
    }
}
