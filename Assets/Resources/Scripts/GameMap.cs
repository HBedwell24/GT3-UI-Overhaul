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
    Camera camera;
    int currentIndex = 0;

    void Start()
    {
        camera = Camera.main;
    }

    void Move(int dir)
    {
        currentIndex += dir;
        currentIndex = (currentIndex < 0) ? levels.Length - 1 : currentIndex;
        currentIndex = (currentIndex >= levels.Length) ? 0 : currentIndex;

        camera.transform.position = Vector2.Lerp(camera.transform.position, levels[currentIndex].position, speed);
    }

    // Update is called once per frame
    void Update()
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
