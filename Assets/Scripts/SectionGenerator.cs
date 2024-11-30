using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionGenerator : MonoBehaviour
{
    public GameObject[] sections;  // Array of section prefabs
    public Transform spawnPoint;   // Where to spawn new sections
    public float scrollSpeed = 5f; // Scrolling speed of platforms

    private GameObject lastSection;

    public GameObject finalSection; // The unique final section prefab
    public int maxScenes = 10; // number of normal sections before the final scene
    private int sceneCounter = 0; // counter for generated scenes
    private bool finalSceneGenerated = false; // Track if the final scene is generated
    private backgroundScroller backgroundScroller; // Reference to the BackgroundScroller script

    void Start()
    {
        // Get the BackgroundScroller component
        backgroundScroller = FindObjectOfType<backgroundScroller>();
        // Initialize the first section
        lastSection = Instantiate(sections[0], spawnPoint.position, Quaternion.identity);
    }

    void Update()
    {
        // Move the current sections leftward
        foreach (GameObject section in GameObject.FindGameObjectsWithTag("Section"))
        {
            section.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        }

        // Check if we need to spawn a new section
        Transform endpoint = lastSection.transform.Find("Endpoint");
        if (endpoint.position.x < spawnPoint.position.x)
        {
            SpawnNextSection();
        }

        // Destroy sections that go off-screen
        foreach (GameObject section in GameObject.FindGameObjectsWithTag("Section"))
        {
            // Calculate the left edge of the camera view
            float offScreenX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;

            Transform endpoint_de = section.transform.Find("Endpoint");
            if (endpoint_de != null && endpoint_de.position.x < offScreenX) // Adjust threshold as needed
            {
                Destroy(section);
            }
        }
    }

    void SpawnNextSection()
    {
        if (sceneCounter < maxScenes)
        {
            // Randomly select the next section or use a sequence
            GameObject nextSection = sections[Random.Range(0, sections.Length)];
            lastSection = Instantiate(nextSection, spawnPoint.position, Quaternion.identity);
            sceneCounter++;

            // Notify the BackgroundScroller about the new section count
            if (backgroundScroller != null)
            {
                backgroundScroller.UpdateSectionCounter(sceneCounter);
            }
        }
        else if (!finalSceneGenerated)
        {
            lastSection = Instantiate(finalSection, spawnPoint.position, Quaternion.identity);
            finalSceneGenerated = true;
        }
    }

}
