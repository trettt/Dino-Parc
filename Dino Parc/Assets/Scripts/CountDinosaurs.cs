using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDinosaurs : MonoBehaviour
{
    [SerializeField] private float detectionRadius;
    private Transform player;
    private float distanceToPlayer;
    private bool isHovering = false;
    private string dinosaurName;
    private string message = "";

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dinosaurName = gameObject.name;
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);
        isHovering = distanceToPlayer <= detectionRadius;

        if (isHovering)
        {
            if (!IsDinosaurDiscovered(dinosaurName))
            {
                DinosaursManager.instance.AddDiscoveredDinosaur(dinosaurName);
                message = "Discovered " + dinosaurName;
            }
        }
    }

    private bool IsDinosaurDiscovered(string tag)
    {
        return DinosaursManager.instance.IsDinosaurDiscovered(tag);
    }

    private void OnGUI()
    {
        if (isHovering && IsDinosaurDiscovered(dinosaurName))
        {
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.fontSize = 20;
            style.normal.textColor = Color.white;
            style.fontStyle = FontStyle.Bold;
            style.alignment = TextAnchor.MiddleCenter;

            GUI.Label(new Rect(0, Screen.height - 70, Screen.width, 50), message, style);
        }
    }
}
