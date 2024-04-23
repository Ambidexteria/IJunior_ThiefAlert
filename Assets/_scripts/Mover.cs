using UnityEngine;

public class Mover : MonoBehaviour
{
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _speed;

    private void Update()
    {
        float direction = Input.GetAxis(Vertical);
        transform.Translate(direction * _speed * Time.deltaTime * transform.forward, Space.World);
    }
}
