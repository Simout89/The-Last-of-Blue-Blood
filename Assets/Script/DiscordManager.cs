using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscordManager : MonoBehaviour
{
    Discord.Discord discord;
    [SerializeField] private string Text;
    void Start()
    {
        discord = new Discord.Discord(598486258573901825, (ulong)Discord.CreateFlags.NoRequireDiscord);
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
            State = "Playing Solo",
            Details = Text,
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
