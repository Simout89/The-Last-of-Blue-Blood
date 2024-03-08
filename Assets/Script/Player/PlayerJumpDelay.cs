using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerJumpDelay : MonoBehaviour
{
    public static UnityEvent OnJumpDelayInput = new UnityEvent();
    public static UnityEvent<bool> OnJumpDelayOutput = new UnityEvent<bool>();

    private void Awake()
    {
        OnJumpDelayInput.AddListener(HandleJumpDelayInput);
    }
    private void HandleJumpDelayInput()
    {
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        OnJumpDelayOutput.Invoke(false);
        yield return new WaitForSeconds(0.1f);
        OnJumpDelayOutput.Invoke(true);
    }
}
