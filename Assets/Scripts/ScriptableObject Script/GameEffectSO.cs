using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GameEffectSO : ScriptableObject
{
    public ParticleSystem[] hitEffects;
    public ParticleSystem hitEffect_1;
    public ParticleSystem hitEffect_2;
    public ParticleSystem hitEffect_3;

    public ParticleSystem[] deadEffects;
    public ParticleSystem deadEffect_1;
    public ParticleSystem deadEffect_2;
    public ParticleSystem deadEffect_3;

    public ParticleSystem[] collectEffects;
    public ParticleSystem collectEffect_1;
    public ParticleSystem collectEffect_2;
    public ParticleSystem collectEffect_3;

    public ParticleSystem[] environmentEffects;
    public ParticleSystem environmentEffect_1;
    public ParticleSystem environmentEffect_2;
    public ParticleSystem environmentEffect_3;





}
