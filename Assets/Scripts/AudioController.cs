using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource flap;
    public AudioSource hit;
    public AudioSource gameover;

    public void playFlap()
    {
        flap.Play();
    }

    public void playHit()
    {
        hit.time = 0.01f;
        hit.Play();
    }

    public void playGameOver()
    {
        gameover.Play();
    }
}
