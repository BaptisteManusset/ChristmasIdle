using UnityEngine;

public class AudioHandler : Singleton<AudioHandler>
{
    private AudioSource m_audiosource;
    [SerializeField] private AudioClip m_click;


    protected override void Awake()
    {
        base.Awake();
        m_audiosource = GetComponent<AudioSource>();
    }

    public void ClickSound()
    {
        m_audiosource.PlayOneShot(m_click);
    }
}