using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Economy : MonoBehaviour
{
    private long gdp;
    private long peoples;

    public long Money;
    public long Income;
    public UI ui;

    [SerializeField] private int vat; //ןהג
    void Start()
    {
        gdp = ui.totalGdp;
        peoples = ui.totalPopulation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
