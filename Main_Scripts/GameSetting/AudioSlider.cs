using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SESlider;

    private void Start()
    {
       
        //BGM
        audioMixer.GetFloat("BGM", out float bgmVolume);
        BGMSlider.value = bgmVolume;
        //SE
        audioMixer.GetFloat("SE", out float seVolume);
        SESlider.value = seVolume;
    }

    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM", volume);
    }

    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SE", volume);
    }
}
