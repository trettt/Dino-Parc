using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DinosaursManager : MonoBehaviour
{
    public static DinosaursManager instance;
    [SerializeField] private TextMeshProUGUI count;
    [SerializeField] private ParticleSystem meteorShower;
    [SerializeField] private AudioSource explosionSound;

    private List<string> discoveredDinosaurs = new List<string>();

    // Unity calls Awake when an enabled script instance is being loaded.
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

        meteorShower.Stop();
        explosionSound.playOnAwake = false;
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

    private void Update()
    {
        if (GetDiscoveredDinosaursCount () == 13)
        {
            count.text = "All dinosaurs discovered!";
            meteorShower.Play();
            if (!explosionSound.isPlaying)
            {
                explosionSound.loop = true;
                explosionSound.Play();
            }

            Invoke("TheEnd", 5f);
        }
    }

    private void TheEnd()
    {
        Application.Quit();
    }

}
