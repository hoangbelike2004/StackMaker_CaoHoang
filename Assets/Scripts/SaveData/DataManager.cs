using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public IUManager IU;
    private string soundstr, Musicstr, Vibratestr;

    public bool isSound,isMusic,isVibrate;
    private void OnEnable()
    {
        IUManager.ExitSettingEvent += SetSetting;
    }
    private void OnDisable()
    {
        IUManager.ExitSettingEvent -= SetSetting;
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

}
