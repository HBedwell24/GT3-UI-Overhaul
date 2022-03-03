using System.IO;
using TMPro;
using UnityEngine;

namespace Assets.Resources.Scripts
{
    public class SaveManager : MonoBehaviour
    {
        public TMP_InputField saveName;
        public GameObject loadButtonPrefab;

        public void OnSave()
        {
            SerializationManager.Save(saveName.text, SaveData.current);
        }

        public string[] saveFiles;
        public void GetLoadFiles()
        {
            if (Directory.Exists(Application.persistentDataPath + "/saves/"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/saves/");
            }
            saveFiles = Directory.GetFiles(Application.persistentDataPath + "/saves/");
        }
    }
}