using DG.Tweening;
using UnityEngine;
using TMPro;

public class UserControlsUI : MonoBehaviour
{
    [SerializeField] Tabs tabs;
    [SerializeField] BodyPanelUI controls;
    [SerializeField] BodyPanelUI levels;
    [SerializeField] BodyPanelUI info;
    [SerializeField] RectTransform controlPanel;
    [SerializeField] TMP_Text controlPanelTitle;
    [SerializeField] Vector3 controlPanelHiddenPosition = new Vector3(0, 450f, 0);
    
    BodyPanelUI previousBodyPanel = null;
    
    Vector3 controlPanelShownPosition;
    
    bool controlPanelIsShowing = false;
    
    public void UIButtonTouched()
    {
        if (controlPanelIsShowing)
        {
            HideBodyPanel(previousBodyPanel);
            controlPanel.DOLocalMoveY(controlPanelHiddenPosition.y, 0.3f)
            .OnComplete(() =>
            {
                controlPanel.gameObject.SetActive(false);
                tabs.SetSelectedTab(TabId.Controls);
                controlPanelTitle.DOText("Open", 0.3f);
            })
            .SetEase(Ease.InBack);
            controlPanelIsShowing = false;
        }
        else
        {
            controlPanel.gameObject.SetActive(true);
            controlPanel.DOLocalMoveY(controlPanelShownPosition.y, 0.3f)
                .SetEase(Ease.OutBack)
                .OnComplete(() =>
                {
                    controlPanelIsShowing = true;
                    ShowBodyPanel(controls);
                    controlPanelTitle.DOText("Close", 0.3f);
                });
        }
    }

    void Awake()
    {
        controlPanelShownPosition = controlPanel.localPosition;
    }

    void Start()
    {
        controls.gameObject.SetActive(true);
        controlPanel.localPosition = controlPanelHiddenPosition;
        controlPanel.gameObject.SetActive(false);
        HideAllBodyPanels();
    }

    void OnEnable()
    {
        tabs.OnTabSelected += OnTabSelected;
    }
    
    void OnDisable()
    {
        tabs.OnTabSelected -= OnTabSelected;
    }
    
    void HideAllBodyPanels()
    {
        HideBodyPanel(controls);
        HideBodyPanel(levels);
        HideBodyPanel(info);
    }
    
    void OnTabSelected(TabId tabId)
    {
        switch (tabId)
        {
            case TabId.Controls:
                ShowBodyPanel(controls);
                break;
            case TabId.Levels:
                ShowBodyPanel(levels);
                break;
            case TabId.Info:
                ShowBodyPanel(info);
                break;
        }
    }
    
    void ShowBodyPanel(BodyPanelUI bodyPanel)
    {
        if(bodyPanel == previousBodyPanel) return;
        if (previousBodyPanel != null) HideBodyPanel(previousBodyPanel);
        
        bodyPanel.gameObject.SetActive(true);
        bodyPanel.Show();
        previousBodyPanel = bodyPanel;
    }
    
    void HideBodyPanel(BodyPanelUI bodyPanel)
    {
        if(bodyPanel == null) return;
        
        bodyPanel.Hide();
        bodyPanel.gameObject.SetActive(false);
        previousBodyPanel = null;
    }
}