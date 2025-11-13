using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public void PlayBackGroundTrack(AudioClip clip)
    {
        SoundManager.Instance.playBackGroundTrack(clip);
    }

    public void SwitchBackGroundTrack(AudioClip clip)
    {
        SoundManager.Instance.switchBackGroundTrack(clip);
    }
    public void PlayButtonSFX(AudioClip clip)
    {
        SoundManager.Instance.playButtonSFX(clip);
    }
    public void PlayOtherSFX(AudioClip clip)
    {
        SoundManager.Instance.playOtherSFX(clip);
    }

    public void SwitchBackGroundTrackWithFade(AudioClip clip)
    {
        SoundManager.Instance.switchBackGroundTrackWithFade(clip);
    }
}
