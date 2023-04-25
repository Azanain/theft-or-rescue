using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum AchievmentQuality { Gold, Silver}
public class ButtonAchievement : AbstractButton, IPointerDownHandler
{
    [Header("Button Data")]
    [SerializeField] private byte _title;
    [SerializeField] private string _description;
    [SerializeField] private Image _imageBg;
    [SerializeField] private Image _imageAchiev;
    [SerializeField] private AchievementInfo _achievementInfo;
    [SerializeField] private AchievmentQuality _achievmentQuality;

    private void Awake()
    {
        if (_imageBg == null)
            _imageBg = transform.Find("ImageBG").GetComponent<Image>();
        if (_imageAchiev == null)
            _imageAchiev = transform.Find("ImageAchiev").GetComponent<Image>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        PressButton();
    }
    private void PressButton()
    {
        if (_achievementInfo != null)
        {
            _achievementInfo.gameObject.SetActive(true);
            _achievementInfo.UpdateText(_title, _description);
        }
    }
}
