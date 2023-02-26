using UnityEngine;
public class UIButtons : MonoBehaviour//UI used in milestone 1 presentation gameplay
{
    public AudioSource Barking_Audio;
    public GameObject WaterFox;
    public GameObject FireFox;
    public GameObject PlantFox;
    private void Start()
    {
        Barking_Audio = GetComponent<AudioSource>();
    }
    public void PlantButton()
    {
        Debug.Log("Plant Button Pressed");
        PlantFox.SetActive(true);
        FireFox.SetActive(false);
        WaterFox.SetActive(false);
    }
    public void WaterButton()
    {
        Debug.Log("Water Button Pressed");
        PlantFox.SetActive(false);
        FireFox.SetActive(false);
        WaterFox.SetActive(true);
    }
    public void FireButton()
    {
        Debug.Log("Fire Button Pressed");
        PlantFox.SetActive(false);
        FireFox.SetActive(true);
        WaterFox.SetActive(false);
    }
    public void FoxButton()
    {
        Debug.Log("Fox Button Pressed");
        Barking_Audio.Play();

    }
}
