using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource, SFX;

    public AudioClip musicClip;
    // Start is called before the first frame update

    public static AudioManager instance;
    private void Awake()
    {
        if (instance != null)
        { Debug.LogWarning("careful more than one AudioManager is present"); return; }
        instance = this;
    }
    void Start()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
