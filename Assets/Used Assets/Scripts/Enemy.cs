using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    ScoreBoard scoreBoard;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 2;
    [SerializeField] GameObject enemyExplosionPrefab;
    [SerializeField] GameObject enemyHitPrefab;

    Transform parent;

    [Obsolete]
    private void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parent = GameObject.FindGameObjectWithTag("Effect Parent").transform;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!other.CompareTag("Laser"))
            return;

        GetHit();

        if (hitPoints < 1)
            Explode();
    }

    private void GetHit()
    {
        IncreaseScore();
        DecrementHitPoints();
        PlayEnemyHitEffect();
    }

    private void DecrementHitPoints()
    {
        hitPoints--;
    }

    private void PlayEnemyExplosionEffect()
    {
        GameObject fx = Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
    }

    private void PlayEnemyHitEffect() {
        GameObject vfx = Instantiate(enemyHitPrefab, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
    }

    private void IncreaseScore()
    {
        scoreBoard.IncreaseScore(scorePerHit);
    }

    private void Destroy() {
        Destroy(this.gameObject);

    }

    private void Explode()
    {
        PlayEnemyExplosionEffect();
        Destroy();
    }
}
