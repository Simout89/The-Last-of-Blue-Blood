using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudPrincessCount : MonoBehaviour
{
    private int _princesscount = 0;
    private TMP_Text Text;
    private void Start()
    {
        Text = GetComponent<TMP_Text>();
        PrincessCollect.OnCollectPrincess.AddListener(HandlePrincessCollect);
        Finish.OnFinish.AddListener(HandleFinish);

    }

    private void HandlePrincessCollect()
    {
        _princesscount++;
        Text.text = _princesscount.ToString();
    }
    private void HandleFinish()
    {
        StartCoroutine(Delay());
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.01f);
        HudFinishPrincessCount.OnSetFinishPrincessCountText.Invoke(_princesscount);
    }
}
