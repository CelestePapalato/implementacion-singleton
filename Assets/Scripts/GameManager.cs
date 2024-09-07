using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Text puntajeText;
    [SerializeField]
    float scoreTimer;

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
        StartCoroutine(ScoreOn());
    }

    private IEnumerator ScoreOn()
    {
        UpdateScore();
        while (true)
        {
            yield return new WaitForSeconds(scoreTimer);
            puntaje++;
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
        Time.timeScale = 0;
        SoundManager.Instance.PlayBGM("game over", false);
    }
}
