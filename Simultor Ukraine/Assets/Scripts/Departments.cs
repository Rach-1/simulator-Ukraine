using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Departments : MonoBehaviour
{
    public float AntiCorruptionDepartment;
    public float AntiInflationDepartment;
    public int AntiCorruptionDepartmentPrice;
    public int AntiInflationDepartmentPrice;

    private float antiCorruptionChange;
    private float antiInflationChange;
    private float antiCorruptionChangePrice;
    private float antiInflationChangePrice;

    public Clock clock;
    public Economy economy;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(clock.PickMonth)
        {
            antiCorruptionChange = AntiCorruptionDepartment / 100;
            antiCorruptionChangePrice = AntiCorruptionDepartment * AntiCorruptionDepartmentPrice;
            economy.CorruptionCgange(antiCorruptionChange, (int)antiCorruptionChangePrice);

            antiInflationChange = AntiInflationDepartment / 100;
            antiInflationChangePrice = AntiInflationDepartment * AntiInflationDepartmentPrice;
            economy.InflationCgange(antiInflationChange, (int)antiInflationChangePrice);
        }
    }
    public void Corruption(float value)
    {
        AntiCorruptionDepartment = value;
    }
    public void Inflation(float value)
    {
        AntiCorruptionDepartment = value;
    }
}
