using UnityEngine;
using UnityEngine.UI;

public class AchievementInfo : MonoBehaviour
{
    [SerializeField] private Text _textTitle;
    [SerializeField] private Text _textDescription;

    public void UpdateText(byte title, string description)
    {
        _textTitle.text = title + " / 10";
        _textDescription.text = description;
    }
}
