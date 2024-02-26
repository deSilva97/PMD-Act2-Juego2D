using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    public enum Form :byte { Loop, Random }

    AudioSource source;

    [SerializeField] AudioClip[] normalClips;
    [SerializeField] AudioClip audioWin;
    [SerializeField] AudioClip audioLose;
    [SerializeField] float timeBetweenClips = 1f;

    int index;
    float timer;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        LevelManager.onGameWin += Win;
        LevelManager.onGameLose += Lose;
    }

    private void OnDisable()
    {
        LevelManager.onGameWin -= Win;
        LevelManager.onGameLose -= Lose;
    }

    private void Start()
    {
        source.loop = false;

        index = 0;
        Play(index);
        StartCoroutine(LoopMusic());
    }

    IEnumerator LoopMusic()
    {
        while (source.isPlaying)
            yield return new WaitForEndOfFrame();

        source.Stop();

        yield return new WaitForSeconds(timeBetweenClips);

        Play(NextArrayIndex());

    }
    

    public void Play(int next, float time = 0)
    {
        timer = time;

        index = next;
        source.clip = normalClips[index];

        source.Play();
    }

    public int NextArrayIndex()
    {
        int next = index + 1;

        if (next == normalClips.Length)
            next = 0;

        return next;
    }

    private void Win() => StopAndPlay(audioWin);
    private void Lose() => StopAndPlay(audioLose);

    public void StopAndPlay(AudioClip clip)
    {
        StopAllCoroutines();

        if (clip != null)
        {
            source.clip = clip;
            source.Play();
        }
        else source.Stop();

    }
}
