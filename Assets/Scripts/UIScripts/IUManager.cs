using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IUManager : Singleton<IUManager>
{
    [SerializeField] Button Setting;
    [SerializeField] Button ExitSetting;
    [SerializeField] Button EffectSound;
    [SerializeField] Button OffEffectSound;
    [SerializeField] Button Music;
    [SerializeField] Button OffMusic;
    [SerializeField] Button Vibrate;
    [SerializeField] Button OffVibrate;
    public bool sound,music,vibrate;
    [SerializeField] Button AgreeSetting;
    [SerializeField] private GameObject SettingPanel;


    [SerializeField] private GameObject WinGame;
    [SerializeField] private Button WinContinue;
    [SerializeField] private Button WinExit;

    public delegate void DelegateAfterExitSeting();
    public static DelegateAfterExitSeting AfterSetingEvent;
    public delegate void DelegateExitSetting();
    public static DelegateExitSetting ExitSettingEvent;
    public delegate void DelegateWinContinue();
    public static DelegateExitSetting WinEvent;
    [SerializeField] private DataManager _DataManager;

    private void OnEnable()
    {
        RemoveStack.FinishEvent += ShowWin;
    }
    private void OnDisable()
    {
        sound = true; music = true; vibrate = true;
        RemoveStack.FinishEvent -= ShowWin;
    }

    void Start()
    {
        WinContinue.onClick.AddListener(ContinueThenWin);
        WinExit.onClick.AddListener(WinAndExit);

        Setting.onClick.AddListener(ActivePanel);
        ExitSetting.onClick.AddListener(DeActivePanel);//when click exit setting 
        EffectSound.onClick.AddListener(OnclickEffectSound);
        Music.onClick.AddListener(OnClickMusic);
        Vibrate.onClick.AddListener(OnClickVibrate);

        OffEffectSound.onClick.AddListener(OnclickEffectSound);
        OffMusic.onClick.AddListener(OnClickMusic);
        OffVibrate.onClick.AddListener(OnClickVibrate);
        AgreeSetting.onClick.AddListener(OnAgreeSetting);
    }
    private void OnclickEffectSound()
    {
        
        if (EffectSound.gameObject.activeSelf == true)
        {

            OffEffectSound.gameObject.SetActive(true);
            EffectSound.gameObject.SetActive(false);
        }
        else if (OffEffectSound.gameObject.activeSelf == true)
        {

            OffEffectSound.gameObject.SetActive(false);
            EffectSound.gameObject.SetActive(true);
        }
        

    }
    private void OnClickMusic()
    {
        
        if (Music.gameObject.activeSelf == true)
        {

            OffMusic.gameObject.SetActive(true);
            Music.gameObject.SetActive(false);
        }
        else if (OffMusic.gameObject.activeSelf == true)
        {

            OffMusic.gameObject.SetActive(false);
            Music.gameObject.SetActive(true);
        }
        
    }
    private void OnClickVibrate()
    {
        
        if (Vibrate.gameObject.activeSelf == true)
        {

            OffVibrate.gameObject.SetActive(true);
            Vibrate.gameObject.SetActive(false);
        }
        else if (OffVibrate.gameObject.activeSelf == true)
        {

            OffVibrate.gameObject.SetActive(false);
            Vibrate.gameObject.SetActive(true);
        }
        
    }
    private void OnAgreeSetting()
    {
        SettingPanel.SetActive(false);
    }
    private void ActivePanel()
    {
        SettingPanel.SetActive(true);
        sound = EffectSound.gameObject.activeSelf == true ? true : false;
        music = Music.gameObject.activeSelf == true ? true: false;
        vibrate = Vibrate.gameObject == true ? true : false;
        ExitSettingEvent?.Invoke();
        

    }
    private void DeActivePanel()
    {
        if (_DataManager.isSound != EffectSound.gameObject.activeSelf || _DataManager.isVibrate != Vibrate.gameObject.activeSelf
            || _DataManager.isMusic != Music.gameObject.activeSelf)
        {
            
            AfterSetingEvent?.Invoke();//when on click exit then call delegate AftersetingEvent
        }
        if (EffectSound.gameObject.activeSelf== _DataManager.isSound && Vibrate.gameObject.activeSelf== _DataManager.isVibrate
            &&  Music.gameObject.activeSelf== _DataManager.isMusic)
        {
            
            SettingPanel.SetActive(false);
        }
        
    }
    private void ShowWin()
    {
        WinGame.SetActive(true);
    }
    void ContinueThenWin()
    {
        WinGame.SetActive(false);
        WinEvent?.Invoke();
    }
    void WinAndExit()
    {
        WinGame.SetActive(false);
        Application.Quit();
    }
}
