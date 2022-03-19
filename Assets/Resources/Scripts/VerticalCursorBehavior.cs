using UnityEngine;
using UnityEngine.InputSystem;

public class VerticalCursorBehavior : MonoBehaviour
{
    [SerializeField] RectTransform[] charBtn;
    [SerializeField] RectTransform indicator;
    [SerializeField] float moveDelay;

    int indicatorPos;
    float moveTimer;

    // Update is called once per frame
    void Update()
    {
        if (moveTimer < moveDelay)
        {
            moveTimer += Time.deltaTime;
        }
        if (Gamepad.current.dpad.down.IsPressed() || Gamepad.current.leftStick.down.IsPressed())
        {
            if (moveTimer >= moveDelay)
            {
                if (indicatorPos < charBtn.Length - 1)
                {
                    AudioManager.instance.PlaySoundEffect("Cursor");
                    indicatorPos++;
                }
                moveTimer = 0;
            }
        }
        else if (Gamepad.current.dpad.up.IsPressed() || Gamepad.current.leftStick.up.IsPressed())
        {
            if (moveTimer >= moveDelay)
            {
                if (indicatorPos > 0)
                {
                    AudioManager.instance.PlaySoundEffect("Cursor");
                    indicatorPos--;
                }
                moveTimer = 0;
            }
        }
        indicator.localPosition = Vector3.Lerp(indicator.localPosition, charBtn[indicatorPos].localPosition, 0.2f);
    }
}
