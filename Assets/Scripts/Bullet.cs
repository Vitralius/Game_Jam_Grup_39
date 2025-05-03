using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime); // Belirli sürede yok ol
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy'ye çarptı!");
            Destroy(gameObject); 
            Destroy(GameObject.FindWithTag("Enemy"));
        }
    }
}