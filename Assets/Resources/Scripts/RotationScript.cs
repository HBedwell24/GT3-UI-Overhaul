using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotationScript : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private bool rotateObject;

    public void OnSelect(BaseEventData eventData)
    {
        rotateObject = true;
    }
    public void OnDeselect(BaseEventData eventData)
    {
        
        rotateObject = false;
        
    }

    void Update()
    {
        if (rotateObject == true)
            transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
        else
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), 300F * Time.deltaTime);
    }
}
