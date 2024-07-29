using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Wave : MonoBehaviour
{
    PlayableDirector pd;
    private void Awake()
    {
        pd = GetComponent<PlayableDirector>();
        pd.played += StartGunning;
    }

    private void StartGunning(PlayableDirector director)
    {
        foreach (Transform formation in gameObject.transform)
        {
            foreach (Transform ship in formation)
            {
                foreach (Transform shipComp in ship)
                {
                    ParticleSystem gun = shipComp.gameObject.GetComponent<ParticleSystem>();
                    if (gun)
                    {
                        ParticleSystem.EmissionModule em = gun.emission;
                        em.enabled = true;
                    }
                }
            }
        }

    }

    public void DestroyOnStopped()
    {
        foreach (Transform child in this.transform)
        {
            Debug.Log(child.gameObject.name);
            Destroy(child.gameObject);
        }
    }

}
