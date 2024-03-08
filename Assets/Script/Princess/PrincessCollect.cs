using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PrincessCollect : MonoBehaviour
{
    public static UnityEvent OnCollectPrincess = new UnityEvent();
    private Animator animator;
    private AudioSource audioSource;
    private string currentState;
    private Collider collider;
    private void Awake()
    {
        collider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(delay());
        }
    }
    private IEnumerator delay()
    {
        collider.enabled = false;
        audioSource.Play(); 
        ChangeAnimationState("Armature|joy");
        OnCollectPrincess.Invoke();
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    private void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
}
