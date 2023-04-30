using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public class LocalDataManager : MonoBehaviour
    {
        #region Declaration

        // Comment: Nothing Declaration

        #endregion

        #region Init Stage

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            // Comment: Nothing init
        }

        #endregion

        #region Setup Stage

        public void SetupManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            // Comment: Nothing init
        }

        #endregion

        #region Main Function

        public T LoadLocalData<T>()
        {
            // Try To Load Local Data From Device
            try
            {
                string content = File.ReadAllText(Application.persistentDataPath + "/" + typeof(T).Name + ".json");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);
            }
            // If Can't Find, Return default
            catch
            {
                return default;
            }
        }

        public void SaveLocalData(object file)
        {
            string content = JsonUtility.ToJson(file);
            File.WriteAllText(Application.persistentDataPath + "/" + file.GetType().Name + ".json", Newtonsoft.Json.JsonConvert.SerializeObject(file));
        }

        #endregion
    }
}