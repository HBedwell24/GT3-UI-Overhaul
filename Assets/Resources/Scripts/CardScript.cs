using UnityEngine;
using UnityEngine.EventSystems;

public class CardScript : MonoBehaviour, IDeselectHandler
{
    public void OnDeselect(BaseEventData eventData)
    {
        AudioManager.instance.PlaySoundEffect("Cursor");
    }
}