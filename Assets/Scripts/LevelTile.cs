using UnityEngine;
using UnityEngine.UI;

public class LevelTile : MonoBehaviour
{
    [SerializeField] Image unlocked;
    [SerializeField] Image locked;
    [SerializeField] bool isUnlocked;

    
    void Awake()
    {
        SetUnlocked(isUnlocked);
    }

    public void SetUnlocked(bool isUnlocked)
    {
        unlocked.gameObject.SetActive(isUnlocked);
        locked.gameObject.SetActive(!isUnlocked);
    }
}

