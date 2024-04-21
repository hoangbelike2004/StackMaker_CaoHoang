using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitSetingUi : MonoBehaviour
{
    [SerializeField] Button Exit;//if are not change setting then exit
    [SerializeField] Button AgreeAndExit;
    [SerializeField] Button DisAgreeAndExit;
    [SerializeField] private GameObject AfterClickExitPanel;
    [SerializeField] private GameObject SettingPanel;
    private void Start()
    {
       
        AgreeAndExit.onClick.AddListener(OnAgreeAndExit);
        DisAgreeAndExit.onClick.AddListener(OnDisAgreeAndExit);
        //Exit.onClick.AddListener(ExitPanel);
    }
    private void OnEnable()
    {
        IUManager.AfterSetingEvent += ShowAfterClickExitPanel;
    }
    private void OnDisable()
    {
        IUManager.AfterSetingEvent -= ShowAfterClickExitPanel;
    }
    public void ShowAfterClickExitPanel()
    {
        AfterClickExitPanel.SetActive(true);
    }
    public void ExitPanel()
    {
        SettingPanel.SetActive(false);
    }
    private void OnAgreeAndExit()
    {
        AfterClickExitPanel.SetActive(false);
        SettingPanel.SetActive(false);
    }
    private void OnDisAgreeAndExit()
    {
        AfterClickExitPanel.SetActive(false);
        SettingPanel.SetActive(false);
    }
}
