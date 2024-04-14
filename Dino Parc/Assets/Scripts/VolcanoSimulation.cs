using UnityEngine;

public class VolcanoSimulation : MonoBehaviour
{
    [SerializeField] private float detectionRadius;
    [SerializeField] private AudioSource lavaSound;

    private string message = "PRESS E TO START THE SIMULATION";
    private bool playerIsNear = false;
    private bool isSimulationActive = false;
    private Transform player;
    private float distanceToPlayer;

    private ParticleSystem smokeParticles;
    private ParticleSystem lavaParticles;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lavaSound = GetComponent<AudioSource>();

        smokeParticles = GameObject.Find("Smoke").GetComponent<ParticleSystem>();
        lavaParticles = GameObject.Find("Lava").GetComponent<ParticleSystem>();

        lavaParticles.Stop();
        lavaSound.Stop();
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);
        playerIsNear = distanceToPlayer <= detectionRadius;

        if (playerIsNear && Input.GetKeyDown(KeyCode.E) && !isSimulationActive)
        {
            smokeParticles.Stop();
            StartSimulation();
            message = "";
        }
    }

    private void StartSimulation()
    {
        isSimulationActive = true;

        Invoke("StartLavaFlow", 5f);
        Invoke("StopSimulation", 15f);
        Invoke("ShowMessage", 15f);

        Camera.main.GetComponent<CameraShake>().Shake(15f, 0.3f);
    }

    private void StartLavaFlow()
    {
        lavaParticles.Play();
        lavaSound.Play();
    }

    private void StopSimulation()
    {
        lavaParticles.Stop();
        lavaSound.Stop();
        smokeParticles.Play();
        isSimulationActive = false;
    }

    private void ShowMessage()
    {
        message = "PRESS E TO START THE SIMULATION";
    }

    private void OnGUI()
    {
        if (playerIsNear && message != "")
        {
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.fontSize = 20;
            style.normal.textColor = Color.white;
            style.fontStyle = FontStyle.Bold;
            style.alignment = TextAnchor.MiddleCenter;

            GUI.Label(new Rect(0, Screen.height - 50, Screen.width, 50), message, style);
        }
    }
}