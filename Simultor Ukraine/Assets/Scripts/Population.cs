using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Population : MonoBehaviour
{
    public long TotalPopulation;
    public float PopulationIncomeKoef;
    public int DevelopmentPoint;
    public int DevelopmentPointIncome;
    public int DevIncomeBasic;
    private bool firstRun = true;

    public Clock clock;
    public Province Prov;

    public string provinceTag = "Ukr";
    private Province[] provinces;

    [SerializeField] Text totalPopulationText;
    [SerializeField] Text developmentPointText;
    void Awake()
    {
        TotalPopulationLenght();
        DevelopmentPointIncome = DevIncomeBasic;
        ResTextUpdate();
    }

    void Update()
    {
        TotalPopulationLenght();
        DevPoint();
    }

    public void ProvLenght()
    {
        GameObject[] provinceObjects = GameObject.FindGameObjectsWithTag(provinceTag);
        provinces = new Province[provinceObjects.Length];
        for (int i = 0; i < provinceObjects.Length; i++)
        {
            provinces[i] = provinceObjects[i].GetComponent<Province>();
        }
    }
    public void TotalPopulationLenght()
    {
        if (clock.PickMonth || firstRun)
        {
            TotalPopulation = 0;
            ProvLenght();
            foreach (Province province in provinces)
            {
                TotalPopulation += province.Pop;
            }
            totalPopulationText.text = (TotalPopulation / 1000000.0).ToString("0.000") + " млн";
            firstRun = false;
        }
    }
    public void DevPoint()
    {
        if (clock.PickMonth)
        {
            DevelopmentPointIncome = DevIncomeBasic;
            DevelopmentPoint += DevelopmentPointIncome;
            ResTextUpdate();
        }
    }
    public void ResTextUpdate()
    {
        developmentPointText.text = DevelopmentPoint.ToString();
    }
    public void AddDevProvince()
    {
        Prov.DevIncrease();
    }
}
