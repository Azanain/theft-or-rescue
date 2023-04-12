using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class Options : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup mixer;
    [SerializeField] private AudioSource audioSourceMusicScene;

    //[Header("Music")]
    //private bool musicVolumeEnabled = true;

    [Header("Effects")]
    private bool effectsVolumeEnabled = true;

    [Header("UI Audio")]
    [SerializeField] private AudioSource clickButton;
    //private bool uIVolumeEnabled = true;

    private float valueVolumeMusic;
    private float valueVolumeEffects;
    private void Start()
    {
        StartMusicOnCurrentScene();
    }
    /// <summary>
    /// ������ ������ �� ������� �����
    /// </summary>
    private void StartMusicOnCurrentScene()
    {
        audioSourceMusicScene.Play();
    }
    /// <summary>
    /// ������������ ����� ������� ������
    /// </summary>
    public void ClickAudio()
    {
        if(clickButton != null)
            clickButton.Play();
    }
    /// <summary>
    /// ����� �� ����
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
    /// <summary>
    /// ������� ����� ������
    /// </summary>
    //public void ToggleVolumeMusic()
    //{
    //    if (!musicVolumeEnabled)
    //    {
    //        mixer.audioMixer.SetFloat("MusicVolume", valueVolumeMusic);
    //        musicVolumeEnabled = true;
    //    }
    //    else
    //    {
    //        mixer.audioMixer.SetFloat("MusicVolume", -80);
    //        musicVolumeEnabled = false;
    //    }
    //}
    /// <summary>
    ///  ������� ��������� ��������� ������
    /// </summary>
    /// <param name="volume"></param>
    public void ChangeVolumeMusic(float volume)
    {
        mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
        valueVolumeMusic = volume;
    }
    /// <summary>
    /// ������� ��������� ��������� ��������
    /// </summary>
    /// <param name="volume"></param>
    //public void ChangeVolumeEffects(float volume)
    //{
    //    mixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, volume));
    //    valueVolumeEffects = volume;
    //}
    /// <summary>
    /// ������� ����� ��������
    /// </summary>
    public void ToggleVolumeEffects()
    {
        if (!effectsVolumeEnabled)
        { 
            mixer.audioMixer.SetFloat("EffectsVolume", valueVolumeEffects);
            effectsVolumeEnabled = true;
        }
        else
        { 
            mixer.audioMixer.SetFloat("EffectsVolume", -80);
            effectsVolumeEnabled = false;
        }
    }
    /// <summary>
    /// ������� ���� UI
    /// </summary>
    //public void ToggleVolumeUI()
    //{
    //    if (!uIVolumeEnabled)
    //    { 
    //        mixer.audioMixer.SetFloat("UIVolume", 0);
    //        uIVolumeEnabled = true;
    //    }
    //    else
    //    { 
    //        mixer.audioMixer.SetFloat("UIVolume", -80);
    //        uIVolumeEnabled = false;
    //    }
    //}
}
