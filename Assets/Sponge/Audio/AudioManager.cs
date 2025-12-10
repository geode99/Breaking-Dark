using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header ("Audio Clip")]
    public AudioClip background;
    public AudioClip buttons;
    public AudioClip dash;
    public AudioClip hurt;
    public AudioClip jump;
    public AudioClip portal;
    public AudioClip change;
}
