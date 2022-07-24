using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSystem : MonoBehaviour
{
    private static AudioSource _audioSource;

    public AudioContainer[] containers;
    private static Dictionary<string, AudioContainer> _mappedContainers = new();

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        foreach (var container in containers)
        {
            _mappedContainers.Add(container.id, container);
        }
    }

    public static void PlayOneshot(string id, float volume = 0.5f)
    {
        if (!_mappedContainers.ContainsKey(id))
            return;

        AudioContainer container = _mappedContainers[id];

        _audioSource.pitch = 1 + Random.Range(-container.pitchRange, container.pitchRange);
        _audioSource.PlayOneShot(_mappedContainers[id].GetRandomClip(), volume);
        _audioSource.pitch = 1;

       
    }

    public static void Stop()
    {
        _audioSource.Stop();
    }
}