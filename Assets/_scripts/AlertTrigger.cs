using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AlertTrigger : MonoBehaviour
{
    [SerializeField] private AlertSound _sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>() != null)
            _sound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Thief>() != null)
            _sound.Stop();
    }
}
