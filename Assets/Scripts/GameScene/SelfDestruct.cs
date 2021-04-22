using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            Destroy(gameObject, 2);
        }
    }
}
