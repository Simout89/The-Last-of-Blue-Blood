using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudHeightJumpImage : MonoBehaviour
{
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
        HudHightJumpDelayText.OnHeightJumpDelayState.AddListener(HadleHeightJumpDelayState);
    }
    private void HadleHeightJumpDelayState(bool flag)
    {
        if (!flag)
            image.color = Color.white;
        else
            image.color = Color.gray;
    }
}
