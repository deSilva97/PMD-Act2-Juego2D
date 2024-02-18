using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    [Space]
    [SerializeField] AudioMixerGroup mixerGroup;
    [Space]
    [SerializeField] AudioSource jump;
    [SerializeField] AudioSource attack;

    AudioSource[] sources;

    private void Awake()
    {
        sources = GetComponentsInChildren<AudioSource>();
    }

    private void Start()
    {
        foreach (var source in sources)
            source.outputAudioMixerGroup = mixerGroup;

        setListeners();
    }

    private void setListeners()
    {
        controller.onPlayerJump += () => jump.Play();
        controller.onPlayerAttack += () => attack.Play();
    }
}
