using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Text puntajeText;
    [SerializeField]
    float scoreTimer;

    int puntaje = 0;

    public UnityEvent onGameOver;

    private void OnEnable()
    {
        PlayerController.onDead += GameOver;
        ScoreOnDestroy.onEvent += AddScore;
    }

    private void OnDisable()
    {
        PlayerController.onDead -= GameOver;
        ScoreOnDestroy.onEvent -= AddScore;
    }

    private void Start()
    {
        SoundManager.Instance.PlayBGM("gameplay", true);
        StartCoroutine(ScoreOn());
        Time.timeScale = 1.0f;
    }

    private IEnumerator ScoreOn()
    {
        UpdateScore();
        while (true)
        {
            yield return new WaitForSeconds(scoreTimer);
            puntaje++;
            if(puntaje % 100 == 0)
            {
                SoundManager.Instance.PlaySE("puntaje");
            }
            UpdateScore();
        }
    }

    private void AddScore(int score)
    {
        if (score > 0)
        {
            puntaje += score; 
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        if (!puntajeText) { return; }
        puntajeText.text = puntaje + "";
    }

    private void GameOver()
    {
        StopAllCoroutines();
        Debug.Log("Game Over");
        onGameOver?.Invoke();
        Time.timeScale = 0;
        SoundManager.Instance.PlayBGM("game over", false);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
