using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float shakeDuration = 0f;
    private float shakeAmplitude = 0.7f;
    private float decreaseFactor = 1.0f;

    private Vector3 originalPos;

    private void Start()
    {
        originalPos = transform.localPosition;
    }

    private void Update()
    {
        if (shakeDuration > 0)
        {
            float shakeX = Random.Range(-1f, 1f) * shakeAmplitude;

            transform.localPosition = new Vector3(originalPos.x + shakeX, originalPos.y, originalPos.z);

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = originalPos;
        }
    }

    public void Shake(float duration, float amount)
    {
        shakeDuration = duration;
        shakeAmplitude = amount;
    }
}
