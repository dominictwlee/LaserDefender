using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "Audio cues", menuName = "ScriptableObjects/AudioCue")]
public class AudioCue : ScriptableObject
{
    [SerializeField]
    AudioClip[] clips = null;

    [SerializeField]
    [Range(0,1)]
    float minVolume = 0;

    [SerializeField]
    [Range(0, 1)]
    float maxVolume = 0;

    public void Play(AudioSource source)
    {
        var (clip, volume) = RandomizeClipSettings();
        source.PlayOneShot(clip, volume);
    }
    public void PlayClipAtCameraMain()
    {
        var (clip, volume) = RandomizeClipSettings();
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
    }

    (AudioClip, float) RandomizeClipSettings()
    {
        var clip = clips[Random.Range(0, clips.Length)];
        var volume = Random.Range(minVolume, maxVolume);
        return (clip, volume);
    }

}
