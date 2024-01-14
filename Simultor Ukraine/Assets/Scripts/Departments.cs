using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Departments : MonoBehaviour
{
    public float AntiCorruptionDepartment;
    public int AntiCorruptionDepartmentPrice;

    private float antiCorruptionChange;
    private float antiCorruptionChangePrice;

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
        }
    }
    public void Corruption(float value)
    {
        AntiCorruptionDepartment = value;
    }
}
