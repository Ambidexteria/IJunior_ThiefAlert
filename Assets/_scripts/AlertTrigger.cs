using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AlertTrigger : MonoBehaviour
{
    [SerializeField] private AlertSound _sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
            _sound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
            _sound.Stop();
    }
}
