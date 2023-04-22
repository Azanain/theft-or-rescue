using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class Options : MonoBehaviour
{
    public static Options instance{ get; private set; }

    [SerializeField] private AudioMixerGroup mixer;
    [SerializeField] private AudioSource audioSourceMusicScene;

    [Header("Effects")]
    private bool effectsVolumeEnabled = true;
    [SerializeField] private Slider _sliderMusic;

    [Header("UI Audio")]
    [SerializeField] private AudioSource clickButton;

    private float valueVolumeMusic;
    private float valueVolumeEffects;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        StartMusicOnCurrentScene();
        LoadData();
    }
    private void LoadData()
    {
        valueVolumeMusic = PlayerPrefs.GetFloat("MusicVolume");
        ChangeVolumeMusic(valueVolumeMusic);
        _sliderMusic.value = valueVolumeMusic;

        valueVolumeEffects = PlayerPrefs.GetFloat("EffectsVolume");
        mixer.audioMixer.SetFloat("EffectsVolume", valueVolumeEffects);

        if (valueVolumeEffects == 0)
            effectsVolumeEnabled = true;
        else
            effectsVolumeEnabled = false;
    }
    /// <summary>
    /// ������ ������ �� ������� �����
    /// </summary>
    private void StartMusicOnCurrentScene()
    {
        if(audioSourceMusicScene != null)
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
    ///  ������� ��������� ��������� ������
    /// </summary>
    /// <param name="volume"></param>
    public void ChangeVolumeMusic(float volume)
    {
        mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
        valueVolumeMusic = volume;

        PlayerPrefs.SetFloat("MusicVolume", valueVolumeMusic);
    }
    /// <summary>
    /// ������� ����� ��������
    /// </summary>
    public void ToggleVolumeEffects()
    {
        if (!effectsVolumeEnabled)
        {
            valueVolumeEffects = 0;
            mixer.audioMixer.SetFloat("EffectsVolume", valueVolumeEffects);
            effectsVolumeEnabled = true;
        }
        else
        {
            valueVolumeEffects = -80;
            mixer.audioMixer.SetFloat("EffectsVolume", valueVolumeEffects);
            effectsVolumeEnabled = false;
        }

        PlayerPrefs.SetFloat("EffectsVolume", valueVolumeEffects);
        ClickAudio();
    }
}
