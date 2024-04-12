using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DinosaursManager : MonoBehaviour
{
    public static DinosaursManager instance;
    [SerializeField] private TextMeshProUGUI count;

    private List<string> discoveredDinosaurs = new List<string>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        count.text = "Discovered dinosaurs: " + discoveredDinosaurs.Count.ToString() + "  / 13";
    }

    public void AddDiscoveredDinosaur(string dinosaurTag)
    {
        discoveredDinosaurs.Add(dinosaurTag);
        count.text = "Discovered dinosaurs: " + discoveredDinosaurs.Count.ToString() + "  / 13";
    }

    public bool IsDinosaurDiscovered(string dinosaurTag)
    {
        return discoveredDinosaurs.Contains(dinosaurTag);
    }

    public int GetDiscoveredDinosaursCount()
    {
        return discoveredDinosaurs.Count;
    }
}
