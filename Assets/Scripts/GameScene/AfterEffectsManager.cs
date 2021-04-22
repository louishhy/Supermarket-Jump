using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterEffectsManager : MonoBehaviour
{

    public static AfterEffectsManager AEM;
    [SerializeField] private GameObject invincibleAfterEffect;
    [SerializeField] private GameObject splashImage;
    [SerializeField] private GameObject deathParticle;
    private void Awake()
    {
        AEM = this;
    }

    public void setInvincibleEffect(bool isInvincible)
    {
        if (isInvincible) invincibleAfterEffect.SetActive(true);
        else if (!isInvincible) invincibleAfterEffect.SetActive(false);
    }

    public void SplashOn(float duration)
    {
        splashImage.SetActive(true);
        Invoke("SplashOff", duration);
    }

    public void SplashOff()
    {
        splashImage.SetActive(false);
    }

    public void StartDeathParticleEffect(Vector3 pos)
    {
        Instantiate(deathParticle, pos, Quaternion.Euler(-90,0,0));
    }


}
