using UnityEngine;

public class Rotator : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal); 

    [SerializeField] private float _rotationSpeed; 

    private void Update()
    {
        float direction = Input.GetAxis(Horizontal);
        transform.Rotate(Vector3.up, direction * _rotationSpeed * Time.deltaTime);
    }
}
