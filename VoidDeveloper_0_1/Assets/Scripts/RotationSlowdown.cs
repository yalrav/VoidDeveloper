using UnityEngine;

public class RotationSlowdown : MonoBehaviour
{
    public float slowdownRate = 0.5f; // Коэффициент замедления

    private void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * slowdownRate); // Замедление вращения по оси Y
    }
}