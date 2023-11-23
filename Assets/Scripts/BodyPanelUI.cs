using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class BodyPanelUI : MonoBehaviour
{
    [SerializeField] List<RectTransform> tileList;
    
    public void Show(bool instant = false)
    {
        foreach(RectTransform rt in tileList)
        {
            DoScale(rt, 1f, 0.3f, instant);
        }
    }
    
    public void Hide(bool instant = false)
    {
        foreach(RectTransform rt in tileList)
        {
            DoScale(rt, 0f, 0.3f, instant);
        }
    }
    
    void DoScale(RectTransform rt, float scale, float duration, bool instant = false)
    {
        if (!instant)
        {
            rt.DOScale(scale, duration).SetEase(Ease.OutExpo);
            return;
        }
        
        rt.localScale = new Vector3(scale, scale, scale);
    }
}
