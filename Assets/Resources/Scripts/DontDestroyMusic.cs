using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{
    private void Awake()
    {
        for (int i = 0; i < Object.FindObjectsOfType<DontDestroyMusic>().Length; i++)
        {
            if (FindObjectsOfType<DontDestroyMusic>()[i] != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
