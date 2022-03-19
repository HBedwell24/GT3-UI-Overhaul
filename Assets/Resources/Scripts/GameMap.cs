using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMap : MonoBehaviour
{
    [SerializeField] 
    Transform[] levels;

    [SerializeField] RectTransform indicator;
    [SerializeField] float moveDelay;

    int indicatorPos;
    float moveTimer;

    [SerializeField]
    float speed;

    Transform cam;
    int currentIndex = 0;

    void Start()
    {
        cam = Camera.main.transform.parent;
    }

    void Move(int dir)
    {
        currentIndex += dir;
        currentIndex = (currentIndex < 0) ? levels.Length - 1 : currentIndex;
        currentIndex = (currentIndex >= levels.Length) ? 0 : currentIndex;

        
    }

    private void LateUpdate()
    {
        if (moveTimer < moveDelay)
        {
            moveTimer += Time.deltaTime;
        }
        if (moveTimer >= moveDelay)
        {
            cam.position = Vector2.Lerp(cam.position, levels[currentIndex].position, speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTimer < moveDelay)
        {
            moveTimer += Time.deltaTime;
        }
        if (Input.GetJoystickNames().Length > 0)
        {
            if (Gamepad.current.dpad.right.IsPressed() || Gamepad.current.leftStick.right.IsPressed())
            {
                if (moveTimer >= moveDelay)
                {
                    if (indicatorPos < levels.Length - 1)
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
                Move(1);
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
                        indicatorPos = levels.Length - 1;
                    }
                    moveTimer = 0;
                }
                Move(-1);
            }
            indicator.localPosition = Vector3.Lerp(indicator.localPosition, levels[indicatorPos].localPosition, 0.2f);
        }
    }
}
