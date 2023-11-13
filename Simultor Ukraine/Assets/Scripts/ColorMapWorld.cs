using UnityEngine;
using System.Collections.Generic;

public class ColorMapWorld : MonoBehaviour
{
    public Dictionary<string, Color> tagColors = new Dictionary<string, Color>();

    void Start()
    {
        // ��������� ����� ���� � ������
        tagColors.Add("Pol", Color.green);
        tagColors.Add("Ukr", Color.blue);

        // ��������� ������� ������� ��'���� ���������� �� �����
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
