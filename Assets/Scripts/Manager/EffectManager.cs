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
        //Obstacle.OnObstacleCollect += Obstacle_OnObstacleCollect;
        //Coin.OnCoinCollect += Coin_OnCoinCollect;
        //HealthManager.OnPlayerDie += HealthManager_OnPlayerDie;
    }

    private void Item_OnItemCollect(object sender, System.EventArgs e)
    {
        PlayGameEffect(gameEffectSO.collectEffect_1, playerParticlePoint.position, new Vector3(5f, 5f, 5f), 1);
    }

    private void OnDisable()
    {
        // Unregister from event
        Item.OnItemCollect -= Item_OnItemCollect;
        //Obstacle.OnObstacleCollect -= Obstacle_OnObstacleCollect;
        //Coin.OnCoinCollect -= Coin_OnCoinCollect;
        //HealthManager.OnPlayerDie -= HealthManager_OnPlayerDie;
    }
    public void PlayGameEffect(ParticleSystem particleEffect, Vector3 particlePosition, Vector3 particleScale, float particleSpeed)
    {
        ParticleSystem particle = Instantiate(particleEffect, particlePosition, Quaternion.identity);

        particle.transform.localScale = particleScale;
        particle.playbackSpeed = particleSpeed;
        particle.Play();
    }

    public void PlayRandomGameEffect(ParticleSystem[] particleEffect, Vector3 particlePosition, float particleScale, float particleSpeed)
    {
        int particleindex = Random.Range(0, particleEffect.Length);

        ParticleSystem selectedEffect = particleEffect[particleindex];

        ParticleSystem particle = Instantiate(selectedEffect, particlePosition, Quaternion.identity);

        particle.Play();

        particle.playbackSpeed = particleSpeed;
    }
}
