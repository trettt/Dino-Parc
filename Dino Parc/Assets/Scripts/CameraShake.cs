using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Durata shake-ului
    private float shakeDuration = 0f;

    // Amplitudinea shake-ului
    private float shakeAmount = 0.7f;

    // Factorul de reducere a shake-ului în timp
    private float decreaseFactor = 1.0f;

    // Poziția originală a camerei
    private Vector3 originalPos;

    private void Start()
    {
        originalPos = transform.localPosition;
    }

    private void Update()
    {
        if (shakeDuration > 0)
        {
            // Generează o valoare de shake pe axa X
            float shakeX = Random.Range(-1f, 1f) * shakeAmount;

            // Aplică shake-ul pe axa X
            transform.localPosition = new Vector3(originalPos.x + shakeX, originalPos.y, originalPos.z);

            // Scade durata shake-ului
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            // Resetează poziția camerei la cea originală
            shakeDuration = 0f;
            transform.localPosition = originalPos;
        }
    }

    // Funcție pentru a porni shake-ul camerei
    public void Shake(float duration, float amount)
    {
        shakeDuration = duration;
        shakeAmount = amount;
    }
}
