using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        // Создаем взрыв в позиции столкновения
        Instantiate(explosionPrefab, collision.contacts[0].point, Quaternion.identity);

        // Уничтожаем объект, с которым столкнулся снаряд
        Destroy(collision.gameObject);

        // Уничтожаем сам снаряд
        Destroy(gameObject);
    }
}