using System;

[Serializable]
public class SaveButtonData
{
    public string fileName;// File Name In Application.persistentDataPath E.g. SaveFile_1
    public string saveFileName;// User Select File Name
    public float playTime;
    public DateTime saveDate;
    public string saveVersion;
}
