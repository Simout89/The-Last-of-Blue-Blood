using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class HudTimer : MonoBehaviour
{
    private TMP_Text _text;
    private float _elapsedTime = 0f;
    private string _timetext;
    private bool _isPlaying = true;
    private void Awake()
    {
        PlayerInput.OnInputState.AddListener(HandleInputState);

        Finish.OnFinish.AddListener(HandleFinish);
        _text = GetComponent<TMP_Text>();
    }

    private void HandleInputState(bool arg0)
    {
        if(arg0)
            _isPlaying = true;
        else
            _isPlaying = false;
    }

    private void Update()
    {
        if( _isPlaying )
        {
            _elapsedTime += Time.deltaTime;
            string minutes = Mathf.Floor(_elapsedTime / 60).ToString("00");
            string seconds = (_elapsedTime % 60).ToString("00");
            _timetext = $"{minutes}.{seconds}";
            _text.text = string.Format(_timetext);
        }
    }
    private void HandleFinish()
    {
        _isPlaying = false;
        StartCoroutine(Delay());
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.01f);
        HudFinishTime.OnSetFinishTimeText.Invoke(_timetext);
    }
}
