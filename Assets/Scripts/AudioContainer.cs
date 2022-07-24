
using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioContainer", menuName = "Data/Audio Container")]
public class AudioContainer : ScriptableObject
{
    public string id;
    public AudioClip[] clips;

    public float pitchRange = 0;


    public AudioClip GetRandomClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }
}