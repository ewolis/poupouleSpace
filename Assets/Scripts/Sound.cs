using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource _music;
    private bool _isMute = false;

    private void Awake()
    {
        _music = GetComponent<AudioSource>();
    }

    public void ToggleSound()
    {
        Debug.Log("ToggleSound()");
        if (!_isMute)
        {
            _music.Pause();
        }
        else
        {
            _music.Play();
        }

        _isMute = !_isMute;
    }
}
