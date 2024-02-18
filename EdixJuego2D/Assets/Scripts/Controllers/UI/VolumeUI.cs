using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeUI : MonoBehaviour
{
    public event Action<float> onVolumeChange;

    [SerializeField] Button muteVolume;
    [SerializeField] Button fullVolume;
    [SerializeField] Slider slider;

    public float GetSliderValue() => slider.value;

    private void Start()
    {
        slider.onValueChanged.AddListener((v) => onVolumeChange?.Invoke(v));

        muteVolume.onClick.AddListener(() => slider.value = 0);
        fullVolume.onClick.AddListener(() => slider.value = 1);
    }

    public void Open(float value)
    {
        slider.value = value;
    }
}
