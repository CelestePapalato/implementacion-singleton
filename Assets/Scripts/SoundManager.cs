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
        for (int i = 0; i < sounds.Count; i++) {
            DiccionarioAudio.Add(sounds[i], audioClipList[i]);
        }

        sounds.Clear();
        audioClipList.Clear();
    }

    public void Play(string audioClip)
    {
        Play(audioClip, transform.position);
    }

    public void Play(string audioClip, Vector3 position)
    {
        AudioClip toPlay;
        if (!DiccionarioAudio.TryGetValue(audioClip, out toPlay))
        {
            return;
        }
        //AudioSource.PlayClipAtPoint(toPlay, position);
    }
}
