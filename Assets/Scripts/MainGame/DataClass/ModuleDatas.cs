using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Module Datas", menuName = "TW/Module Data")]
public class ModuleDatas : ScriptableObject
{
    public List<ModuleData> moduleDataList;
}

[Serializable]
public class ModuleData
{
    public string moduleName;// The Unique Name Of The Module
    public string managerName;// The Manager Of Current Module
    public List<string> sceneNameList;// The Scene That Module Need To Load    
}
