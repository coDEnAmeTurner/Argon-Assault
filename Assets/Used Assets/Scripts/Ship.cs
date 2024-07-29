using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class Ship : MonoBehaviour
{
    [SerializeField] GameObject shipExplosionPrefab;
    [SerializeField] Transform effectParent;

    ShipControl shipController;

    PlayableDirector masterTimeline;

    GameObject tryAgain;
    GameObject exit;

    bool uiOn = false;

    [Obsolete]
    private void Awake() {
        shipController = GetComponent<ShipControl>();
        masterTimeline = GameObject.FindGameObjectWithTag("Master Timeline").GetComponent<PlayableDirector>();
        tryAgain = GameObject.FindWithTag("Try Again");
        tryAgain.SetActive(false);
        exit = GameObject.FindWithTag("Exit");
        exit.SetActive(false);
    }

    private void Update() {
        StageClear sc = FindAnyObjectByType<StageClear>();

        if (uiOn == false && sc == null)
            HideCursor();
        else 
            ShowCursor();

    }

    private void HideCursor()
    {
        Cursor.visible = false;
    }

    private void ShowCursor()
    {
        Cursor.visible = true;
    }


    private void ResetShip(PlayableDirector director)
    {
        shipController.ResetFields();
    }

    private void OnCollisionEnter(Collision other) {
        Explode();
        DisplayFailUI();
    }

    private void OnParticleCollision(GameObject other) {
        if (shipController.Lasers.Contains(other))
            return;

        Explode();
        DisplayFailUI();
    }

    private void DisplayFailUI()
    {
        tryAgain.SetActive(true);
        exit.SetActive(true);
        uiOn = true;
    }

    private void Explode()
    {
        PlayExplosionEffect();
        LoseControl();
        StopMoving();
    }

    private void StopMoving()
    {
        masterTimeline.Stop();
    }

    private void LoseControl()
    {
        shipController.enabled = false;
    }

    private void PlayExplosionEffect()
    {
        GameObject vfx = Instantiate(shipExplosionPrefab, transform.position, Quaternion.identity);
        vfx.transform.parent = effectParent;
    }
}
