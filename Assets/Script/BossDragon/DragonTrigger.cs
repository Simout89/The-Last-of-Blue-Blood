using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragonTrigger : MonoBehaviour
{
    public static UnityEvent<bool> OnBossFight = new UnityEvent<bool>();

    [SerializeField] private GameObject Door;
    [SerializeField] private AudioClip closedoorsound;
    private Collider Trigger;
    private AudioSource audios;
    private void Awake()
    {
        Trigger = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        audios = GetComponent<AudioSource>();
        if (other.tag == "Player")
        {
            StartCoroutine(delay());
        }
    }
    private IEnumerator delay()
    {
        PlayerInput.OnInputState.Invoke(false);
        audios.PlayOneShot(closedoorsound);
        Door.transform.DORotate(new Vector3(0,-90f,0), 0.5f);
        yield return new WaitForSeconds(1);
        PlayerInput.OnInputState.Invoke(true);
        OnBossFight.Invoke(true);
        Trigger.enabled = false;
    }
}
