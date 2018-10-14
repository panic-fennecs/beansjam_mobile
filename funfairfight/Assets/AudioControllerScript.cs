using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class AudioControllerScript : MonoBehaviour
{
    public static AudioControllerScript instance;

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
    private System.Random random;

    void Awake()
    {
        Assert.IsTrue(!instance);
        instance = this;
        random = new System.Random((int)System.DateTime.Now.Ticks);
    }

    public void playGfxScooter()
    {
        gfxScooter.Play();
    }
    public void playGfxHitTheLukas()
    {
        gfxHitTheLukas.Play();
    }
    public void playGfxGrabbler()
    {
        gfxGrabbler.Play();
    }
    public void playGfxFerisWheel()
    {
        gfxFerisWheel.Play();
    }
    public void playGfxAirGun()
    {
        gfxAirGun.Play();
    }

    public void playGfxBlood()
    {
        switch (random.Next(0, 3)) {
            case 0: gfxBlood0.Play(); break;
            case 1: gfxBlood1.Play(); break;
            case 2: gfxBlood2.Play(); break;
            case 3: gfxBlood3.Play(); break;
        }
    }

    public void playGfxExplosion()
    {
        switch (random.Next(0, 3)) {
            case 0: gfxExplosion0.Play(); break;
            case 1: gfxExplosion1.Play(); break;
            case 2: gfxExplosion2.Play(); break;
            case 3: gfxExplosion3.Play(); break;
        }
    }

    public void playSoundByAttack(Attack attack)
    {
        switch(attack) {
            case Attack.FerrisWheel:
                playGfxFerisWheel();
                break;
            case Attack.AirGun:
                playGfxAirGun();
                break;
            case Attack.HitTheLukas:
                playGfxHitTheLukas();
                break;
            case Attack.AutoScooter:
                playGfxScooter();
                break;
            case Attack.Grabbler:
                playGfxGrabbler();
                break;
        }
    }
}
