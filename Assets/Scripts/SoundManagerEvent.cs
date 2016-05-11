using UnityEngine;
using System.Collections;

/*
 * Comment émettre un event:
		SoundManagerEvent.emit(SoundManagerType.ENEMY_HIT);
 * 
 * Comment traiter un event (dans un start ou un initialisation)
		EventManagerScript.onEvent += (EventManagerType emt, GameObject go) => {
			if (emt == EventManagerType.ENEMY_HIT)
			{
				//SpawnFXAt(go.transform.position);
			}
		};
 * ou:
		void maCallback(EventManagerType emt, GameObject go) => {
			if (emt == EventManagerType.ENEMY_HIT)
			{
				//SpawnFXAt(go.transform.position);
			}
		};
		EventManagerScript.onEvent += maCallback;
 * 
 * qui permet de:
		EventManagerScript.onEvent -= maCallback; //Retire l'appel
 */


public enum SoundType
{
    PoolBounce,
    BalloonBounce,
    WoodShock,
    Meow,
    HitAir,
    PotBreak
}

public enum MusicType
{
    Elevator,
    LawnTheme,
    Mood,
    Neighborhood,
    Both
}

public enum MowerType
{
    MowerStart,
    MowerStartAndGo,
    MoweGrass
}

public enum MenuType
{
    MenuMove
}

public enum ExtraType
{
    Victory,
    HomeRun
}

public enum VoiceType
{
    W_FlowerPot
}

public class SoundManagerEvent : MonoBehaviour
{

    #region SoundEvent
    public delegate void SoundEvent(SoundType emt);
    public static event SoundEvent PlaySoundEvent;

    public static void sound(SoundType emt)
    {

        if (PlaySoundEvent != null)
        {
            PlaySoundEvent(emt);
        }
    }

    #endregion

    #region MowerSound
    public delegate void MowerSoundEvent(MowerType emt);
	public static event MowerSoundEvent PlayMowerSoundEvent;

    public static void mowerSound(MowerType emt)
    {

        if (PlayMowerSoundEvent != null)
        {
            PlayMowerSoundEvent(emt);
        }
    }

    #endregion

    #region Music
    public delegate void MusicEvent(MusicType emt);
    public static event MusicEvent PlayMusicEvent;

    public static void music(MusicType music)
    {

        if (PlayMusicEvent != null)
        {
            PlayMusicEvent(music);
        }
    }

    #endregion

    #region Menu
    public delegate void MenuEvent(MenuType emt);
    public static event MenuEvent PlayMenuEvent;

    public static void menu (MenuType menu)
    {

        if (PlayMusicEvent != null)
        {
            PlayMenuEvent(menu);
        }
    }

    #endregion

    #region Extra
    public delegate void ExtraEvent(ExtraType emt);
    public static event ExtraEvent PlayExtraEvent;

    public static void extra(ExtraType extra)
    {

        if (PlayExtraEvent != null)
        {
            PlayExtraEvent(extra);
        }
    }

    #endregion

    #region Voice
    public delegate void VoiceEvent(VoiceType emt);
    public static event VoiceEvent PlayVoiceEvent;

    public static void voice(VoiceType voice)
    {

        if (PlayVoiceEvent != null)
        {
            PlayVoiceEvent(voice);
        }
    }

    #endregion

    #region Singleton
    static private SoundManagerEvent s_Instance;
	static public SoundManagerEvent instance
	{
		get
		{
			return s_Instance;
		}
	}
	


	void Awake()
	{
		if (s_Instance == null)
			s_Instance = this;
		//DontDestroyOnLoad(this);
	}
    #endregion

    void Start()
	{
        PlaySoundEvent += (SoundType emt) => { };
        PlayMowerSoundEvent += (MowerType emt) => {  };
        PlayMusicEvent+= (MusicType emt) => { };
        PlayMenuEvent += (MenuType emt) => { };
        PlayExtraEvent += (ExtraType emt) => { };
        PlayVoiceEvent += (VoiceType emt) => { };
    }

	

    



}
