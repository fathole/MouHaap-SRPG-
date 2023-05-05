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

        public void SaveLocalData(object file, string fileName, string fileExtension)
        {
            string content = JsonUtility.ToJson(file);
            File.WriteAllText(Application.persistentDataPath + "/" + fileName + fileExtension, Newtonsoft.Json.JsonConvert.SerializeObject(file));
        }

        public T LoadLocalData<T>(string fileName, string fileExtension)
        {            // Try To Load Local Data From Device
            try
            {
                string content = File.ReadAllText(Application.persistentDataPath + "/" +fileName + fileExtension);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);
            }
            // If Can't Find, Return default
            catch
            {
                return default;
            }
        }

        public List<T> LoadLocalDataList<T>(string fileExtension)
        {
            // Create A List To Return
            List<T> returnTypeList = new List<T>();
            // Get All File
            DirectoryInfo directory = new DirectoryInfo(Application.persistentDataPath + "/");
            // Find All File With Finding Type
            FileInfo[] fileInfoArray = directory.GetFiles("*" + fileExtension  +"*");

            // Get File Info
            foreach (FileInfo fileInfo in fileInfoArray)
            {
                string content = File.ReadAllText(Application.persistentDataPath + "/" + fileInfo.Name);
                returnTypeList.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content));
            }

            // Return The List
            return returnTypeList;
        }

        public void DeleteLocalFile(string fileName, string fileExtension)
        {
            string filePath = Application.persistentDataPath + "/" + fileName + fileExtension;

            File.Delete(filePath);
        }

        #endregion
    }
}