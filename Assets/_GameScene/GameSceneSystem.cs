﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneSystem : MonoBehaviour
{
    [System.NonSerialized]
    public float time;
    public static float start_time;
    TimerUI timerui;
    public bool IsGameTime;///ゲーム中か?(時間切れや勝利条件を満たしたならfalse)
    void Start()
    {
        time = start_time;
        timerui = GameObject.Find("TimerUI_Canvas/TimerUI").GetComponent<TimerUI>();
        IsGameTime = true;
    }


    void Update()
    {
        if (IsGameTime)
        {
            //終了の処理
        }
        else
        {
            //時間制限の処理----------------------------------
            time -= Time.deltaTime;
            if (time <= 0)
            {
                IsGameTime = false;
                return;
            }
            timerui.time = time;
            //勝利条件/敗北条件を確認する----------------------

            if(false)//どちらかが勝ったらtrueになるif文をかく
            {
                IsGameTime = false;
                return;
            }
        }
        
        
    }
}
