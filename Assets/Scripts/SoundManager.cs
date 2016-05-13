using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {
	#region Members

	[Header("MUSICS")]
	public List<AudioClip> Music = new List<AudioClip>();

	[Header("SOUNDS")]
	public List<AudioClip> Sound= new List<AudioClip>();

    [Header("MOWER")]
    public List<AudioClip> Mower = new List<AudioClip>();

    [Header("EXTRA")]
    public List<AudioClip> Extra = new List<AudioClip>();

    [Header("MENU")]
    public List<AudioClip> Menu = new List<AudioClip>();

    [Header("VOICES")]
	public List<AudioClip> Voice = new List<AudioClip>();

	[Header("Sound Listeners")]
	public List<AudioSource> Source = new List<AudioSource>();


    #endregion

    bool m_Ready = false;


	// Use this for initialization
	void Awake()
	{
        SoundManagerEvent.PlaySoundEvent += PlaySound;
        SoundManagerEvent.PlayMowerSoundEvent += PlayMowerSound;
        SoundManagerEvent.PlayMusicEvent += PlayMusic;
        SoundManagerEvent.PlayMenuEvent += PlayMenu;
        SoundManagerEvent.PlayExtraEvent += PlayExtra;
        SoundManagerEvent.PlayVoiceEvent += PlayVoice;
    }

	void OnDestroy()
	{
        SoundManagerEvent.PlaySoundEvent -= PlaySound;
        SoundManagerEvent.PlayMowerSoundEvent -= PlayMowerSound;
        SoundManagerEvent.PlayMusicEvent -= PlayMusic;
        SoundManagerEvent.PlayMenuEvent -= PlayMenu;
        SoundManagerEvent.PlayExtraEvent -= PlayExtra;
        SoundManagerEvent.PlayVoiceEvent -= PlayVoice;
    }

	public void PlaySound(SoundType emt)
	{
	}

    public void PlayMusic(MusicType emt)
    {
        switch (emt)
        {
            case MusicType.Menu:
                Source[0].loop = true;
                Source[0].Stop();
                Source[0].clip = Music[0];
                Source[0].Play();
                break;

            case MusicType.InGame:
                Source[0].loop = true;
                Source[0].Stop();
                Source[0].clip = Music[1];
                Source[0].Play();
                break;

            case MusicType.Defeat:
                Source[0].loop = true;
                Source[0].Stop();
                Source[0].clip = Music[2];
                Source[0].Play();
                break;

            case MusicType.Victory:
                Source[0].loop = true;
                Source[0].Stop();
                Source[0].clip = Music[3];
                Source[0].Play();
                break;
        }
    }

    public void PlayMowerSound(MowerType emt)
    {
       
    }

    public void PlayMenu(MenuType emt)
    {
       
    }

    public void PlayExtra(ExtraType emt)
    {
      
    }

    public void PlayVoice(VoiceType emt)
    {
       
    }

    IEnumerator DecreaseMoweSound()
    {
        while(Source[3].volume>0.5f)
        {
            Source[3].volume -= 0.01f;
            yield return new WaitForSeconds(0.1f);
        }

        Source[3].volume = 0.5f;
    }

    IEnumerator DecreaseMoweSoundBig()
    {
        while (Source[2].volume > 0.1f)
        {
            Source[2].volume -= 0.05f;
            yield return new WaitForSeconds(0.1f);
        }

        Source[2].volume = 0.1f;
    }


}
