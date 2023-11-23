using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tab : MonoBehaviour
{
    [SerializeField] string titleString;
    [SerializeField] TabId id;
    [SerializeField] TMP_Text title;
    [SerializeField] Image selectedImage;
    [SerializeField] Image unselectedImage;
    
    float alphaDuration = 0.3f;
    Ease alphaEase = Ease.InOutQuad;
    
    public delegate void TabButtonSelected(TabId id);
    public event TabButtonSelected OnTabButtonSelected;

    void Start()
    {
        this.title.text = titleString;
    }
    
    public void SetSelected()
    {
        selectedImage.DOFade(1f, alphaDuration).SetEase(alphaEase);
        unselectedImage.DOFade(0, alphaDuration).SetEase(alphaEase);
    }
    
    public void SetUnselected()
    {
        selectedImage.DOFade(0, alphaDuration).SetEase(alphaEase);
        unselectedImage.DOFade(1f, alphaDuration).SetEase(alphaEase);
    }

    public void ButtonTouched()
    {
        OnTabButtonSelected?.Invoke(id);
    }
}
