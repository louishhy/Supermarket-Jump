using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PaintTinCtrl : MonoBehaviour
{
    [SerializeField] private float splashTime = 5.0f;
    private void ActivateSplash()
    {
        AfterEffectsManager.AEM.SplashOn(splashTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        ActivateSplash();
        Destroy(gameObject);
    }
}
