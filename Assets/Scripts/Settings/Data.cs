// Carries all the data


using UnityEngine;

public static class Data
{
    public delegate void DataUpdate();
    public static DataUpdate volume;


    public static WaitForSeconds
        twentiethSecond = new WaitForSeconds(0.05f),
        quarterSecond = new WaitForSeconds(0.25f),
        halfSecond = new WaitForSeconds(0.5f),
        fullSecond = new WaitForSeconds(1f);


    private static float _sfxVolume = -1f;
    public static float sfxVolume {
        get {
            if (_sfxVolume < 0) _sfxVolume = PlayerPrefs.GetFloat("sfxVolume", 0.5f); 
            return _sfxVolume; 
        }
        set { 
            _sfxVolume = value; 
            if (volume != null) volume();
            PlayerPrefs.SetFloat("sfxVolume", _sfxVolume);
        }
    }

    
    private static float _musicVolume = -1f;
    public static float musicVolume {
        get {
            if (_sfxVolume < 0) _sfxVolume = PlayerPrefs.GetFloat("musicVolume", 0.5f); 
            return _musicVolume; 
        }
        set { 
            _musicVolume = value; 
            if (volume != null) volume();
            PlayerPrefs.SetFloat("musicVolume", _musicVolume);
        }
    }
}
