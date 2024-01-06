using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public string provinceTag = "Ukr"; // � �� ����� �� �� � ��� �����, ������ ���� ����������� � �� �������
    public Province[] provinces;
    [SerializeField] Text totalPopulationText;
    [SerializeField] Text totalGdpText;
    [SerializeField] Text totalIncomeText;
    public long totalPopulation = 0;
    public long totalGdp = 0;
    public long totalIncome = 0;
    private float incomeCoefficient = 0.001f; // ���������� ������ (0,1%)
    void Awake()
    {
        GameObject[] provinceObjects = GameObject.FindGameObjectsWithTag(provinceTag);
        provinces = new Province[provinceObjects.Length];
        for (int i = 0; i < provinceObjects.Length; i++)
        {
            provinces[i] = provinceObjects[i].GetComponent<Province>();
        }
        
        foreach (Province province in provinces)
        {
            totalPopulation += province.Population;
            totalGdp += province.Gdp;
        }
        totalPopulationText.text = (totalPopulation / 1000000.0).ToString("0.000") + " ���";
        totalGdpText.text = (totalGdp / 1000000000.0).ToString("0.000") + " ����";
        //float totalIncome = totalGdp * incomeCoefficient;
        //totalIncomeText.text = (totalIncome / 1000000.0).ToString("0.000") + " ���";
    }
}