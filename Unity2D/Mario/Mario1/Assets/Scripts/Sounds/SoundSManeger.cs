using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSManeger : MonoBehaviour {

    public AudioClip coins, arm, bump, pause, jumpSmall, destroy, armAtt, background, gameOver;
    // Use this for initialization
    public AudioSource audioSource;
	
	public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "coins":
                audioSource.clip = coins;
                audioSource.PlayOneShot(coins, 1f);
                break;
            case "arm":
                audioSource.clip = arm;
                audioSource.PlayOneShot(arm, 1f);
                break;
            case "bump":
                audioSource.clip = bump;
                audioSource.PlayOneShot(bump, 2f);
                break;
            case "pause":
                audioSource.clip = pause;
                audioSource.PlayOneShot(pause, 1f);
                break;
            case "jumpSmall":
                audioSource.clip = jumpSmall;
                audioSource.PlayOneShot(jumpSmall, 1f);
                break;
            case "destroy":
                audioSource.clip = destroy;
                audioSource.PlayOneShot(destroy, 1f);
                break;
            case "armAtt":
                audioSource.clip = armAtt;
                audioSource.PlayOneShot(armAtt, 1f);
                break;
            case "background":
                audioSource.clip = background;
                audioSource.PlayOneShot(background);
                break;
            case "gameOver":
                audioSource.clip = gameOver;
                audioSource.PlayOneShot(gameOver);
                break;
                

        }
    }
}
