using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        // ������� ����� � ������� ������������
        Instantiate(explosionPrefab, collision.contacts[0].point, Quaternion.identity);

        // ���������� ������, � ������� ���������� ������
        Destroy(collision.gameObject);

        // ���������� ��� ������
        Destroy(gameObject);
    }
}