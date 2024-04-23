using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlertSound : MonoBehaviour
{
    private const float MaxVolume = 1f;
    private const float MinVolume = 0f;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeChangeSpeed = 0.25f;

    private float _currentVolume;

    private Coroutine _increaseCorotine;
    private Coroutine _decreaseCorotine;

    private void Start()
    {
        _audioSource.volume = MinVolume;
    }

    public void Play()
    {
        if (_decreaseCorotine != null)
            StopCoroutine(_decreaseCorotine);

        _audioSource.Play();
        _currentVolume = _audioSource.volume;
        _increaseCorotine = StartCoroutine(IncreaseVolume());
    }

    public void Stop()
    {
        if (_increaseCorotine != null)
            StopCoroutine(_increaseCorotine);

        _currentVolume = _audioSource.volume;
        _decreaseCorotine = StartCoroutine(DecreaseVolume());
    }

    private IEnumerator IncreaseVolume()
    {
        bool isWork = true;

        while (isWork)
        {
            _audioSource.volume = Mathf.Clamp01(Mathf.MoveTowards(_currentVolume, MaxVolume, _volumeChangeSpeed * Time.deltaTime));
            _currentVolume = _audioSource.volume;

            yield return null;

            if (_audioSource.volume == MaxVolume)
                isWork = false;
        }
    }

    private IEnumerator DecreaseVolume()
    {
        bool isWork = true;

        while (isWork)
        {
            _audioSource.volume = Mathf.Clamp01(Mathf.MoveTowards(_currentVolume, MinVolume, _volumeChangeSpeed * Time.deltaTime));
            _currentVolume = _audioSource.volume;

            yield return null;

            if (_audioSource.volume == MinVolume)
            {
                _audioSource.Pause();
                isWork = false;
            }
        }
    }
}
