using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PulsingActiveButton : MonoBehaviour
{
    public float FadeDuration = 1f;

    private Color startColor;
    private Color endColor;
    private float lastColorChangeTime;

    private Material material;

    private bool isSelected;

    void Start()
    {
        isSelected = false;
        material = GetComponent<Renderer>().material;
        startColor = Color.gray;
        endColor = Color.white;
    }

    public void OnSelect(BaseEventData data)
    {
        isSelected = true;
    }
    public void OnDeselect(BaseEventData data)
    {
        isSelected = false;
    }

    void Update()
    {
        if (isSelected)
        {
            var ratio = (Time.time - lastColorChangeTime) / FadeDuration;
            ratio = Mathf.Clamp01(ratio);
            material.color = Color.Lerp(startColor, endColor, ratio);

            if (ratio == 1f)
            {
                lastColorChangeTime = Time.time;

                // Switch colors
                var temp = startColor;
                startColor = endColor;
                endColor = temp;
            }
        }      
    }
}