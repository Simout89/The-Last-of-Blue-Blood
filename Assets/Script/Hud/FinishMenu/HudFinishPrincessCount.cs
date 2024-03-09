using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class HudFinishPrincessCount : MonoBehaviour
{
    private TMP_Text text;
    public static UnityEvent<int> OnSetFinishPrincessCountText = new UnityEvent<int>();
    [SerializeField] PrincessScore princessScore;
    private void Awake()
    {
        OnSetFinishPrincessCountText.AddListener(HandleSetFinishPrincessCountText);
        text = GetComponent<TMP_Text>();
    }
    private void HandleSetFinishPrincessCountText(int time)
    {
        text.text = $"{time} out of {princessScore.MaxPrincess}".ToString();
    }
}
