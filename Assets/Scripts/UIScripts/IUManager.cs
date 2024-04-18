using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IUManager : MonoBehaviour
{
    [SerializeField] Button Setting;
    [SerializeField] Button ExitSetting;
    [SerializeField] Button EffectSound;
    [SerializeField] Button OffEffectSound;
    [SerializeField] Button Music;
    [SerializeField] Button OffMusic;
    [SerializeField] Button Vibrate;
    [SerializeField] Button OffVibrate;
    [SerializeField] Button AgreeSetting;
    [SerializeField] private GameObject SettingPanel;


    [SerializeField] private GameObject WinGame;
    [SerializeField] private Button WinContinue;
    [SerializeField] private Button WinExit;

    public delegate void DelegateAfterExitSeting();
    public static DelegateAfterExitSeting AfterSetingEvent;

    private void OnEnable()
    {
        RemoveStack.FinishEvent += ShowWin;
    }
    private void OnDisable()
    {
        RemoveStack.FinishEvent -= ShowWin;
    }

    void Start()
    {
        WinContinue.onClick.AddListener(ContinueThenWin);
        WinExit.onClick.AddListener(WinAndExit);

        Setting.onClick.AddListener(ActivePanel);
        ExitSetting.onClick.AddListener(DeActivePanel);
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

    }
    private void DeActivePanel()
    {
        AfterSetingEvent?.Invoke();
    }
    private void ShowWin()
    {
        WinGame.SetActive(true);
    }
    void ContinueThenWin()
    {
        WinGame.SetActive(false);
    }
    void WinAndExit()
    {
        WinGame.SetActive(false);
        Application.Quit();
    }
}
