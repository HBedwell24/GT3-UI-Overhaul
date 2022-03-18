using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotationScript : MonoBehaviour, ISelectHandler
{
    private bool rotateObject = false;

    public void OnSelect(BaseEventData eventData)
    {
        if (rotateObject == true) {
            rotateObject = false;
        }
        else
        {
            rotateObject = true;
        }

    }

        void Update() {  
            if (rotateObject == true)
                transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
        }
    }
