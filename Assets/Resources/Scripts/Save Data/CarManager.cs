using UnityEngine;

public class CarManager : MonoBehaviour
{
    public void OnSave()
    {
        SerializationManager.Save("carsave", SaveData.current);
    }

    public void OnLoad()
    {
        
    }
}