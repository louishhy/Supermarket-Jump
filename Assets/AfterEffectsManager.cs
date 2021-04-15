using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterEffectsManager : MonoBehaviour
{

    public static AfterEffectsManager AEM;
    [SerializeField] private GameObject invincibleAfterEffect;
    private void Awake()
    {
        AEM = this;
    }

    public void setInvincibleEffect(bool isInvincible)
    {
        if (isInvincible) invincibleAfterEffect.SetActive(true);
        else if (!isInvincible) invincibleAfterEffect.SetActive(false);
    }

    
}
