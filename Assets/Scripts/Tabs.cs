using System.Collections.Generic;
using UnityEngine;

public class Tabs : MonoBehaviour
{
    [SerializeField] List<Tab> tabList;
    
    Dictionary<TabId, Tab> tabDict = new Dictionary<TabId, Tab>();

    TabId previousTabId;
    
    public delegate void TabSelected(TabId tabId);
    public event TabSelected OnTabSelected;
    
    public void SetSelectedTab(TabId tabId)
    {
        SelectTab(tabId);
    }

    void Start()
    {
        tabDict.Add(TabId.Controls, tabList[0]);
        tabDict.Add(TabId.Levels, tabList[1]);
        tabDict.Add(TabId.Info, tabList[2]);
        
        tabDict[previousTabId].SetSelected();
    }
    
    void OnEnable()
    {
        foreach (var tab in tabList)
        {
            tab.OnTabButtonSelected += OnTabButtonSelected;
        }
    }
    
    void OnDisable()
    {
        foreach (var tab in tabList)
        {
            tab.OnTabButtonSelected -= OnTabButtonSelected;
        }
    }
    
    void OnTabButtonSelected(TabId tabId)
    {
        SelectTab(tabId);
        OnTabSelected?.Invoke(tabId);
    }

    void SelectTab(TabId tabId, bool instant = false)
    {
        if (previousTabId != tabId)
        {
            tabDict[previousTabId].SetUnselected();
            tabDict[tabId].SetSelected();
            previousTabId = tabId;
        }
    }
}
