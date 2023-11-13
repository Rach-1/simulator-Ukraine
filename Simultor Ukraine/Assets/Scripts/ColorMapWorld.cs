using UnityEngine;
using System.Collections.Generic;

public class ColorMapWorld : MonoBehaviour
{
    public Dictionary<string, Color> tagColors = new Dictionary<string, Color>();

    void Start()
    {
        // Додавання різних тегів і колорів
        tagColors.Add("Pol", Color.green);
        tagColors.Add("Ukr", Color.blue);

        // Присвоєння кольору кожному об'єкту знайденому за тегом
        foreach (var kvp in tagColors)
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(kvp.Key);

            foreach (GameObject obj in objectsWithTag)
            {
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = kvp.Value;
                }
            }
        }
    }
}
