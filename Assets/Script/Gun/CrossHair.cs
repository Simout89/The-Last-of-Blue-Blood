using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    private void LateUpdate()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = 3;
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(mouse);
        transform.position = cursorPosition;
    }
}
