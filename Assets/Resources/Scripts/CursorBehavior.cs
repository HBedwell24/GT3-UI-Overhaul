using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CursorBehavior : MonoBehaviour
{
    [SerializeField] RectTransform[] charBtn;
    [SerializeField] RectTransform indicator;
    [SerializeField] float moveDelay;

    float moveTimer;

    public int checkCharBtns(string param)
    {
        int i = 0;
        foreach (RectTransform btn in charBtn)
        {
            if (btn.name == param)
            {
                return i;
            }
            i++;
        }
        return 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject current = EventSystem.current.currentSelectedGameObject;
        int pos = checkCharBtns(current.name);

        if (moveTimer < moveDelay)
        {
            moveTimer += Time.deltaTime;
        }
        if (Input.GetJoystickNames().Length > 0)
        {
            if (Gamepad.current.dpad.IsPressed() || Gamepad.current.leftStick.IsPressed())
            {
                if (moveTimer >= moveDelay)
                {
                    moveTimer = 0;
                }
            }
            indicator.localPosition = Vector3.Lerp(indicator.localPosition, charBtn[pos].localPosition, 0.2f);
        }
    }
}
