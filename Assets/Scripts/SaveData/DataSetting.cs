using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DataSetting
{
    public string issound;
    public string ismusic;
    public string isvibrate;
    public int indexNextLevel;
    public DataSetting(string sound, string music, string vibrate)
    {
        issound = sound;
        ismusic = music;
        isvibrate = vibrate;
    }
    public DataSetting(int index) {
    indexNextLevel = index;
    }
}
