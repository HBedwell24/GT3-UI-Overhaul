using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class IdleDetector : MonoBehaviour
{
    public GameObject loadingManager;
    private float idleCounter = 0.0f;

    void Update()
    {
        if (Gamepad.current != null)
        {
            //Debug.Log(idleCounter);
            if (Gamepad.current.allControls.Any(x => x is ButtonControl button && x.IsPressed() && !x.synthetic))
            {
                idleCounter = 0.0f;
            }
            else if (idleCounter > 120.0f)
            {
                if (SceneManager.GetActiveScene().name != "Launch Screen")
                {
                    idleCounter = 0.0f;
                    loadingManager.GetComponent<LoadingManager>().LoadScene("Launch Screen,false");
                }
            }
        }
        else
        {
            idleCounter += Time.deltaTime;
        }
        Debug.Log(idleCounter);
    }
}
