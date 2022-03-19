using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMap : MonoBehaviour
{
    [SerializeField] 
    Transform[] levels;

    [SerializeField]
    float speed = .5f;

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
        cam.position = Vector2.Lerp(cam.position, levels[currentIndex].position, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetJoystickNames().Length > 0)
        {
            if (Gamepad.current.dpad.right.IsPressed() || Gamepad.current.leftStick.right.IsPressed())
            {
                Move(1);
            }
            else if (Gamepad.current.dpad.left.IsPressed() || Gamepad.current.leftStick.left.IsPressed())
            {
                Move(-1);
            }
        }
            
    }
}
