using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f;
    [SerializeField] private Renderer backgrounds;
    [SerializeField] private Material[] backgroundMaterials; // Array of background materials
    private int currentMaterialIndex = 0; // Tracks the current background material
    private int sectionCounter = 0; // Counter to track sections generated

    // Public method to be called when a section is generated
    public void UpdateSectionCounter(int newSectionCount)
    {
        sectionCounter = newSectionCount;

        // Change background material based on section count
        if (sectionCounter == 2)
        {
            ChangeBackground(1); // Use backgroundMaterials[1] at section 7
        }
        else if (sectionCounter == 4)
        {
            ChangeBackground(2); // Use backgroundMaterials[2] at section 9
        }
        else if (sectionCounter == 6)
        {
            ChangeBackground(3); // Use backgroundMaterials[2] at section 9
        }
        else if (sectionCounter == 8)
        {
            ChangeBackground(4); // Use backgroundMaterials[2] at section 9
        }
        else if (sectionCounter == 9)
        {
            ChangeBackground(5); // Use backgroundMaterials[2] at section 9
        }
    }

    void Update()
    {
        backgrounds.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
    }

    private void ChangeBackground(int materialIndex)
    {
        if (materialIndex < backgroundMaterials.Length && materialIndex != currentMaterialIndex)
        {
            backgrounds.material = backgroundMaterials[materialIndex];
            currentMaterialIndex = materialIndex; // Update the current material index
        }
    }
}
