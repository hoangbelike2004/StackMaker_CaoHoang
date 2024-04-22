using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public IUManager IU;
    private string soundstr, Musicstr, Vibratestr,levelStr;

    public bool isSound,isMusic,isVibrate;
    public int valesLevel=0;
    private void Start()
    {
        //Debug.Log(PlayerPrefs.GetInt("Keylevel"));
        //PlayerPrefs.DeleteKey("Keylevel");

    }
    private void OnEnable()
    {
        IUManager.ExitSettingEvent += SetSetting;
        IUManager.WinEvent += SetLevel;
    }
    private void OnDisable()
    {
        IUManager.ExitSettingEvent -= SetSetting;
        IUManager.WinEvent -= SetLevel;
    }
    
    private void SetSetting()
    {
        //PlayerPrefs.DeleteKey("key_sound");
        //PlayerPrefs.DeleteKey("key_music");
        //PlayerPrefs.DeleteKey("key_vibrate");
        PlayerPrefs.DeleteKey("key_sound");
         soundstr = IU.sound.ToString();
         Musicstr = IU.music.ToString();
         Vibratestr = IU.vibrate.ToString();
        //Debug.Log("so "+ soundstr);
        DataSetting datasetting = new DataSetting(soundstr, Musicstr, Vibratestr);
        string jsonSetting = JsonUtility.ToJson(datasetting);
        PlayerPrefs.SetString("key_jsonSetting", jsonSetting);

        DataSetting jsonDataSetting = JsonUtility.FromJson<DataSetting>(jsonSetting);
        //Debug.Log("Json" + jsonDataSetting.issound.ToString());
        //Debug.Log("Json" + jsonDataSetting.ismusic.ToString());
        //Debug.Log("Json" + jsonDataSetting.isvibrate.ToString());


        //get data and change to string => bool
        isSound = bool.Parse(jsonDataSetting.issound.ToString());
        isMusic = bool.Parse(jsonDataSetting.ismusic.ToString());
        isVibrate = bool.Parse(jsonDataSetting.isvibrate.ToString());
        

        //string strSound = IU.sound.ToString();
        //string strMusic = IU.music.ToString();
        //string strVibrate= IU.vibrate.ToString();


        //PlayerPrefs.SetString("key_sound", strSound);
        //PlayerPrefs.SetString("key_music", strMusic);
        //PlayerPrefs.SetString("key_vibrate", strVibrate);

        //Debug.Log(PlayerPrefs.GetString("key_sound"));
    }
    void SetLevel()
    {

        //levelStr = GameController.Instance.indexLevelMap.ToString();
        //DataSetting _dataSetting = new DataSetting(GameController.Instance.indexLevelMap);
        //string jsonlevel = JsonUtility.ToJson(_dataSetting);
        //PlayerPrefs.SetString("key_jsonlevel", jsonlevel);

        //DataSetting jsonDataseting = JsonUtility.FromJson<DataSetting>(jsonlevel);

        //PlayerPrefs.DeleteKey("Keylevel");
        PlayerPrefs.SetInt("Keylevel",GameController.Instance.indexLevelMap+1);
        
        Debug.Log("Save: " + PlayerPrefs.GetInt("Keylevel"));
        
    }
}
