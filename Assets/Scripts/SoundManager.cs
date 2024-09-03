using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField]
    List<string> sounds = new List<string>();
    [SerializeField]
    List<AudioClip> audioClipList = new List<AudioClip>();

    Dictionary<string, AudioClip> DiccionarioAudio = new Dictionary<string, AudioClip>();

    AudioSource audioSource;

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

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        for (int i = 0; i < sounds.Count; i++) {
            DiccionarioAudio.Add(sounds[i], audioClipList[i]);
        }

        sounds.Clear();
        audioClipList.Clear();
    }

    public void Play(string audioClip)
    {
        AudioClip toPlay;
        if (!DiccionarioAudio.TryGetValue(audioClip, out toPlay))
        {
            return;
        }
        audioSource.Stop();
        audioSource.clip = toPlay;
        audioSource.Play();
    }

    public void Stop()
    {
        audioSource.Stop();
    }
}
