using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Settings/Audio")]
public class AudioSettings : ScriptableObject
{
    public FloatReference fadeSpeed;
    public FloatVariable musicVolume, sfxVolume;
    public AudioMixerGroup musicMixer, sfxMixer;
}