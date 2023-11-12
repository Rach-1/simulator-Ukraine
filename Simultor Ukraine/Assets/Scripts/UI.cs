using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public long PopulationUI;
    public long GDPUI;
    [SerializeField] Text populationui;
    [SerializeField] Text gdpui;
    void Update()
    {
        populationui.text = PopulationUI.ToString();
        gdpui.text = GDPUI.ToString();
    }
}
