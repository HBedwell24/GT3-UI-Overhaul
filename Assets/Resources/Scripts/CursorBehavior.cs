using UnityEngine;
using UnityEngine.InputSystem;

public class CursorBehavior : MonoBehaviour
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
        if (Gamepad.current.dpad.right.IsPressed() || Gamepad.current.leftStick.right.IsPressed())
        {
            if (moveTimer >= moveDelay)
            {
                if (indicatorPos < charBtn.Length - 1)
                {
                    AudioManager.instance.PlaySoundEffect("Cursor");
                    indicatorPos++;
                }
                else
                {
                    AudioManager.instance.PlaySoundEffect("Cursor");
                    indicatorPos = 0;
                }
                moveTimer = 0;
            }
        }
        else if (Gamepad.current.dpad.left.IsPressed() || Gamepad.current.leftStick.left.IsPressed())
        {
            if (moveTimer >= moveDelay)
            {
                if (indicatorPos > 0)
                {
                    AudioManager.instance.PlaySoundEffect("Cursor");
                    indicatorPos--;
                }
                else
                {
                    AudioManager.instance.PlaySoundEffect("Cursor");
                    indicatorPos = charBtn.Length - 1;
                }
                moveTimer = 0;
            }
        }
        indicator.localPosition = Vector3.Lerp(indicator.localPosition, charBtn[indicatorPos].localPosition, 0.2f);
    }
}
