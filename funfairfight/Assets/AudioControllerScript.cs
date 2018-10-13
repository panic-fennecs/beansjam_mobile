using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class AudioControllerScript : MonoBehaviour
{
    public static AudioControllerScript instance;

    public AudioSource music;
    public AudioSource gfxScooter;
    public AudioSource gfxHitTheLukas;
    public AudioSource gfxGrabbler;
    public AudioSource gfxFerisWheel;
    public AudioSource gfxAirGun;
    public AudioSource gfxExplosion0;
    public AudioSource gfxExplosion1;
    public AudioSource gfxExplosion2;
    public AudioSource gfxExplosion3;
    public AudioSource gfxBlood0;
    public AudioSource gfxBlood1;
    public AudioSource gfxBlood2;
    public AudioSource gfxBlood3;

    void Awake()
    {
        Assert.IsTrue(!instance);
        instance = this;
    }

    void Start()
    {
        gfxAirGun.Play();
    }

    void playBlood()
    {
        switch (new System.Random().Next(0, 3)) {
            case 0: gfxBlood0.Play(); break;
            case 1: gfxBlood1.Play(); break;
            case 2: gfxBlood2.Play(); break;
            case 3: gfxBlood3.Play(); break;
        }
    }

    void playExplosion()
    {
        switch (new System.Random().Next(0, 3)) {
            case 0: gfxExplosion0.Play(); break;
            case 1: gfxExplosion1.Play(); break;
            case 2: gfxExplosion2.Play(); break;
            case 3: gfxExplosion3.Play(); break;
        }
    }
}
