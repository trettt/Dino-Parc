using UnityEngine;

public class SignpostInteraction : MonoBehaviour
{
    [SerializeField] private float detectionRadius;
    [SerializeField] private GameObject infoPanel; 

    private string message = "PRESS I TO READ MORE";
    private bool isHovering = false;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        infoPanel.SetActive(false);
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        isHovering = distanceToPlayer <= detectionRadius;

        if (isHovering && Input.GetKeyDown(KeyCode.I))
        {
            ToggleInfoPanel();
        }
    }

    private void ToggleInfoPanel()
    {
       
        infoPanel.SetActive(!infoPanel.activeSelf);
    }

    private void OnGUI()
    {
        if (isHovering && !infoPanel.activeSelf)
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
