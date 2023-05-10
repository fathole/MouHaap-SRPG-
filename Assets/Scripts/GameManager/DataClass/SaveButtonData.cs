using System;

[Serializable]
public class SaveFileData
{
    public string fileName;// File Name In Application.persistentDataPath E.g. SaveFile_1
    public string saveFileName;// User Input File Nmae
    public float playTime;// How Long Player Play
    public DateTime saveDate;// The Date Of Save
    public string saveVersion;// The Version When Saving
}
