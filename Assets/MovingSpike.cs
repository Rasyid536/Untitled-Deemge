using UnityEngine;

public class MovingSpike : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 1f;

    private void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1f);

        transform.position = Vector3.Lerp(
            pointA.position,
            pointB.position,
            t
        );
    }
}