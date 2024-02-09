using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeManager
{
    private static float savedTime = 1;

    public static void Pause(float time = 1)
    {
        savedTime = time;
        Time.timeScale = 0;
    }

    public static void Resume() => Time.timeScale = savedTime;

    public static bool isPaused() => Time.timeScale == 0 ? true : false;

    public static void SwitchPauseStatus(float time = 1)
    {
        if (isPaused())
            Resume();
        else Pause(time);
    }
         

}
