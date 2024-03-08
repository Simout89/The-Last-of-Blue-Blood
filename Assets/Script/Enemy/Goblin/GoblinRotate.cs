using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoblinRotate : MonoBehaviour
{
    [SerializeField] private float RotateSpeed = 1f;
    private GoblinInput _goblininput;
    public static UnityEvent OnRotateRight = new UnityEvent();
    public static UnityEvent OnRotateLeft = new UnityEvent();
    private void Awake()
    {
        _goblininput = GetComponent<GoblinInput>();
        OnRotateRight.AddListener(HandleRotateRight);
        OnRotateLeft.AddListener(HandleRotateLeft);
    }
    private void HandleRotateRight()
    {
        RotateRight();
    }
    private void HandleRotateLeft()
    {
        RotateLeft();
    }
    private void RotateLeft()
    {
        StartCoroutine(Rotate(0f));
    }
    private void RotateRight()
    {
        StartCoroutine(Rotate(180f));
    }
    private IEnumerator Rotate(float angel)
    {
        Quaternion startRotation = _goblininput.GoblinBody.transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(0, angel, 0);
        float elapsedTime = 0.0f;
        while (elapsedTime < RotateSpeed)
        {
            _goblininput.GoblinBody.transform.localRotation = Quaternion.Slerp(startRotation, endRotation, (elapsedTime / RotateSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _goblininput.GoblinBody.transform.localRotation = endRotation;
    }
}
