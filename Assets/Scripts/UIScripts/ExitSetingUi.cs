using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitSetingUi : MonoBehaviour
{
    [SerializeField] Button AgreeAndExit;
    [SerializeField] Button DisAgreeAndExit;
    [SerializeField] private GameObject AfterClickExitPanel;
    [SerializeField] private GameObject SettingPanel;
    private void Start()
    {
        AgreeAndExit.onClick.AddListener(OnAgreeAndExit);
        DisAgreeAndExit.onClick.AddListener(OnDisAgreeAndExit);
    }
    private void OnEnable()
    {
        Debug.Log("Chay");
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
