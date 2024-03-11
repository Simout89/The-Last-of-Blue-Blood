using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiscordManager : MonoBehaviour
{
    KillCounter killCounter;
    TryCount tryCount;
    TotalPrincess totalPrincess;
    Discord.Discord discord;
    void Start()
    {
        HudFinishMenuButtons.OnRestart.AddListener(HandleNext);
        HudFinishMenuButtons.OnNext.AddListener(HandleNext);
        TotalTime.OnResetTime.AddListener(HandleNext);
        HudTimer.FixTime.AddListener(HandleNext);
        totalPrincess = GetComponent<TotalPrincess>();
        tryCount = GetComponent<TryCount>();
        killCounter = GetComponent<KillCounter>();
        discord = new Discord.Discord(598486258573901825, (ulong)Discord.CreateFlags.NoRequireDiscord);
        ChangeActivity();
    }

    private void HandleNext()
    {
        ChangeActivity();
    }

    void OnDisable()
    {
        discord.Dispose();
    }
    public void ChangeActivity()
    {
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            State = $"Death: {tryCount.DeathCount} | Kill: {killCounter.goblin}",
            Details = $"{SceneManager.GetActiveScene().name} | Princess: {totalPrincess.CountPrincess}/{totalPrincess.MaxPrincess}",
            Assets =
            {
                LargeImage = "button"
            },
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            Debug.Log("Activity Update!");
        });
    }
    void Update()
    {
        discord.RunCallbacks();
    }
}
