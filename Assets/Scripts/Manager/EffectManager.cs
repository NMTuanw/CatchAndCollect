using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get; private set; }

    [Header("Reference to Slider")]
    [SerializeField] private GameEffectSO gameEffectSO;
    [SerializeField] private Transform playerParticlePoint;

    private GameObject player;
    private void Awake()
    {
        Instance = this;

        player = GameObject.FindWithTag("Player");
        playerParticlePoint = player.transform.Find("playerParticlePoint");
    }
    private void OnEnable()
    {
        // Register to event
        Item.OnItemCollect += Item_OnItemCollect;
        Obstacle.OnObstacleCollect += Obstacle_OnObstacleCollect;
        Coin.OnCoinCollect += Coin_OnCoinCollect;
        Health.OnHealthCollect += Health_OnHealthCollect;
        HealthManager.OnPlayerDie += HealthManager_OnPlayerDie;
    }

    private void Health_OnHealthCollect(object sender, System.EventArgs e)
    {
        PlayGameEffect(gameEffectSO.coinEffect_1, playerParticlePoint.position, new Vector3(7, 7f, 7f), 1);
    }

    private void HealthManager_OnPlayerDie(object sender, System.EventArgs e)
    {
        PlayRandomGameEffect(gameEffectSO.deadEffects, player.transform.position, new Vector3(10f, 10f, 10f), 1);
    }

    private void Coin_OnCoinCollect(object sender, System.EventArgs e)
    {
        PlayGameEffect(gameEffectSO.coinEffect_1, playerParticlePoint.position, new Vector3(7, 7f, 7f), 1);
    }

    private void Obstacle_OnObstacleCollect(object sender, System.EventArgs e)
    {
        PlayRandomGameEffect(gameEffectSO.hitEffects, playerParticlePoint.position, new Vector3(7f, 7f, 7f), 1);
    }

    private void Item_OnItemCollect(object sender, System.EventArgs e)
    {
        PlayGameEffect(gameEffectSO.collectEffect_1, playerParticlePoint.position, new Vector3(7f, 7f, 7f), 1);
    }

    private void OnDisable()
    {
        // Unregister from event
        Item.OnItemCollect -= Item_OnItemCollect;
        Obstacle.OnObstacleCollect -= Obstacle_OnObstacleCollect;
        Coin.OnCoinCollect -= Coin_OnCoinCollect;
        Health.OnHealthCollect -= Health_OnHealthCollect;
        HealthManager.OnPlayerDie -= HealthManager_OnPlayerDie;
    }
    public void PlayGameEffect(ParticleSystem particleEffect, Vector3 particlePosition, Vector3 particleScale, float particleSpeed)
    {
        ParticleSystem particle = Instantiate(particleEffect, particlePosition, Quaternion.identity);

        particle.transform.localScale = particleScale;
        particle.Play();
    }

    public void PlayRandomGameEffect(ParticleSystem[] particleEffect, Vector3 particlePosition, Vector3 particleScale, float particleSpeed)
    {
        int particleindex = Random.Range(0, particleEffect.Length);

        ParticleSystem selectedEffect = particleEffect[particleindex];

        ParticleSystem particle = Instantiate(selectedEffect, particlePosition, Quaternion.identity);

        particle.transform.localScale = particleScale;
        particle.Play();

    }
}
