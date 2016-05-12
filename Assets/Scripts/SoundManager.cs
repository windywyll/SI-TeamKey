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
		switch (emt)
		{
            case SoundType.PoolBounce:
                Source[12].Stop();
                Source[12].clip = Sound[3];
                Source[12].Play();
                break;

            case SoundType.BalloonBounce:
                    Source[10].Stop();
                    Source[10].clip = Sound[0];
                    Source[10].Play();
                break;

            case SoundType.WoodShock:
                Source[4].Stop();
                Source[4].clip = Sound[4];
                Source[4].Play();
                break;

            case SoundType.Meow:
                Source[1].Stop();
                Source[1].clip = Sound[2];
                Source[1].Play();
                break;

            case SoundType.HitAir:
                Source[1].Stop();
                Source[1].clip = Sound[2];
                Source[1].Play();
                break;

            case SoundType.PotBreak:
                Source[2].Stop();

                if (Random.Range(1, 3) == 1)
                {
                    Source[2].clip = Sound[5];
                }
                else
                {
                    Source[2].clip = Sound[6];
                }

                Source[2].Play();
                break;
        }
	}

    public void PlayMusic(MusicType emt)
    {
        switch (emt)
        {
            case MusicType.Both:


                    Source[0].Stop();
                    Source[0].clip = Music[0];
                    Source[0].Play();

                    Source[1].Stop();
                    Source[1].clip = Music[1];
                    Source[1].Play();

                break;

            case MusicType.Elevator:
                Source[0].Stop();
                Source[1].Stop();
                Source[0].clip = Music[2];
                Source[0].Play();
                break;

            case MusicType.Mood:
                Source[0].Stop();
                Source[1].Stop();
                Source[0].clip = Music[0];
                Source[0].Play();
                break;

            case MusicType.Neighborhood:
                Source[0].Stop();
                Source[1].Stop();
                Source[0].clip = Music[1];
                Source[0].Play();
                break;

            case MusicType.LawnTheme:
                Source[0].Stop();
                Source[1].Stop();
                Source[0].clip = Music[3];
                Source[0].Play();
                break;
        }
    }

    public void PlayMowerSound(MowerType emt)
    {
        switch (emt)
        {
            case MowerType.MowerStart:
                    Source[3].loop = false;
                    Source[3].Stop();
                    Source[3].clip = Mower[0];
                    Source[3].Play();
                Source[3].volume = 1f;
                break;

            case MowerType.MowerStartAndGo:
                    Source[3].loop = false;
                    Source[3].Stop();
                    Source[3].clip = Mower[1];
                    Source[3].Play();
                Source[3].volume = 1f;
                Invoke("Grass", 1);
                break;

            case MowerType.MoweGrass:

                    Source[3].Stop();
                    Source[3].clip = Mower[2];
                    Source[3].Play();
                    Source[3].loop = true;

                StartCoroutine(DecreaseMoweSound());
                break;
        }
    }

    void Grass()
    {
        PlayMowerSound(MowerType.MoweGrass);
    }

    public void PlayMenu(MenuType emt)
    {
        switch (emt)
        {
            case MenuType.MenuMove:

                Source[11].Stop();
                Source[11].clip = Menu[0];
                Source[11].Play();

                break;
        }
    }

    public void PlayExtra(ExtraType emt)
    {
        switch (emt)
        {
            case ExtraType.HomeRun:

                Source[4].Stop();
                Source[4].clip = Extra[0];
                Source[4].Play();
                break;


            case ExtraType.Victory:

                Source[5].Stop();
                Source[5].clip = Extra[1];
                Source[5].Play();
                break;
        }
    }

    public void PlayVoice(VoiceType emt)
    {
        switch (emt)
        {
            case VoiceType.W_FlowerPot:
                Source[9].Stop();
                Source[9].clip = Voice[0];
                Source[9].Play();
                break;
        }
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
