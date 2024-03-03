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
        StartCoroutine(RotateRight());

    }
    private void HandleRotateLeft()
    {
        StartCoroutine(RotateLeft());
    }
    private IEnumerator RotateLeft()
    {
        Quaternion startRotation = _goblininput.GoblinBody.transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(0, 0, 0);
        float elapsedTime = 0.0f;
        while (elapsedTime < RotateSpeed)
        {
            _goblininput.GoblinBody.transform.localRotation = Quaternion.Slerp(startRotation, endRotation, (elapsedTime / RotateSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _goblininput.GoblinBody.transform.localRotation = endRotation;
    }
    private IEnumerator RotateRight()
    {
        Quaternion startRotation = _goblininput.GoblinBody.transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(0, 180, 0);
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
