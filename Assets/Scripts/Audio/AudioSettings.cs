using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Settings data for AudioInstaller or any audio class
/// </summary>
[CreateAssetMenu(menuName = "Settings/Audio")]
public class AudioSettings : ScriptableObject
{
    public FloatReference fadeSpeed;
    public FloatVariable musicVolume, sfxVolume;
    public AudioMixerGroup musicMixer, sfxMixer;
}