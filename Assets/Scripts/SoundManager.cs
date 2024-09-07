using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Audio Source")]
    [SerializeField]
    AudioSource SEAudioSource;
    [SerializeField]
    AudioSource BGMAudioSource;

    [SerializeField]
    AudioList SEAudioList;
    [SerializeField]
    AudioList BGMAudioList;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlaySE(string audioClip)
    {
        if(!SEAudioList || !SEAudioSource) { return; }

        AudioClip toPlay;
        if (!SEAudioList.TryGetAudio(audioClip, out toPlay))
        {
            return;
        }
        SEAudioSource.Stop();
        SEAudioSource.clip = toPlay;
        SEAudioSource.Play();
    }

    public void PlayBGM(string audioClip, bool loop)
    {
        if (!BGMAudioList || !BGMAudioSource) { return; }

        AudioClip toPlay;
        if (!BGMAudioList.TryGetAudio(audioClip, out toPlay))
        {
            return;
        }
        BGMAudioSource.Stop();
        BGMAudioSource.clip = toPlay;
        BGMAudioSource.loop = loop;
        BGMAudioSource.Play();
    }

    public void SEStop()
    {
        SEAudioSource.Stop();
    }

    public void BGMStop()
    {
        BGMAudioSource.Stop();
    }
}
