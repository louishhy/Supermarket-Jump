using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PaintTinCtrl : MonoBehaviour
{
    [SerializeField] private float splashTime = 5.0f;
    private void ActivateSplash()
    {
        AfterEffectsManager.AEM.SplashOn(splashTime);
        CommonButtonSoundPlay.CBSP.PlayTinCrash();
        CommonButtonSoundPlay.CBSP.PlaySplash();
    }


    private void OnCollisionEnter(Collision collision)
    {
        ActivateSplash();
        Destroy(gameObject, 1.5f);
    }
}
