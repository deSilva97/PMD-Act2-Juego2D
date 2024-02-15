using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] AudioMixerGroup mixerGroup;
    [Space]
    [SerializeField] AudioSource jump;
    [SerializeField] AudioSource attack;

    AudioSource[] sources;
    PlayerController controller;

    private void Awake()
    {
        sources = GetComponentsInChildren<AudioSource>();
        controller = GetComponent<PlayerController>();
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
