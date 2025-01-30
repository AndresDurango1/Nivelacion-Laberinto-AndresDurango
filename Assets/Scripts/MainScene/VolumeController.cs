using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] public AudioSource _backgroundSound;

    [SerializeField] private Slider _volumeSlider;

    void Start()
    {
        _volumeSlider.value = PlayerPrefs.GetFloat("GameVolume", 1f);
        _backgroundSound.volume = _volumeSlider.value;
        _volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    public void ChangeVolume(float volume)
    {
        _backgroundSound.volume = volume;
        PlayerPrefs.SetFloat("GameVolume", volume);
        PlayerPrefs.Save();
    }
}
