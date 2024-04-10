using UnityEngine;

public class FootstepsSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource footstepSound;
    private FirstPersonController player;

    void Start()
    {
        footstepSound = GetComponent<AudioSource>();
        player = FindAnyObjectByType<FirstPersonController>();
    }

    void Update()
    {
        // Play footstep sound if the player is grounded and moving
        if (player.isMoving() && player.isGrounded())
        {
            if (!footstepSound.isPlaying)
            {
                footstepSound.Play();
            }
        }
        else
        {
            footstepSound.Stop();
        }
    }
}
