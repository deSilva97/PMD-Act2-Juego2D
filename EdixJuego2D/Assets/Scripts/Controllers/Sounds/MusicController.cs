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
    [SerializeField] Form form = Form.Loop;

    int index;
    float timer;

    bool canPlay;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        EndGameManager.onGameWin += Win;
        EndGameManager.onGameLose += Lose;
    }

    private void OnDisable()
    {
        EndGameManager.onGameWin -= Win;
        EndGameManager.onGameLose -= Lose;
    }

    private void Start()
    {
        canPlay = true;
       

        source.loop = false;

        if (source.clip != null)
            source.clip = normalClips[index];

        Play(0);
    }

    private void Update()
    {
        if (!canPlay)
            return;

        if (source.isPlaying)
            return;

        source.Stop();

        timer += Time.deltaTime;
        if (timer < timeBetweenClips)
            return;

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
        source.loop = !canPlay;
        source.clip = clip;
    }
}
