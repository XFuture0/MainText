using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Event/AudioEventSO")]
public class AudioEventSO : ScriptableObject
{
    public UnityAction<AudioClip> OnAudioEventRaised;
    public void AudioRaiseEvent(AudioClip Clip)
    {
        OnAudioEventRaised?.Invoke(Clip);
    }
}

