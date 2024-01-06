using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Economy : MonoBehaviour
{
    private long gdp;
    private long peoples;
    private float taxes;
    public GameObject prov;
    public Province Prov;

    public float Taxes;
    public long Money;
    public long Income;

    //вартість подудови 
    public int CoalMinePrice;
    public int IronMinePrice;
    public int OilTowerPrice;
    public int GasTowerPrice;
    public int MetalFactoryPrice;
    public int AutoFactoryPrice;
    public int PlaneFactoryPrice;
    public int ShipDockPrice;
    public int SewingFactoryPrice;
    public int FuelFactoryPrice;
    public int ElectronicsFactoryPrice;
    public int ItFactoryPrice;

    [SerializeField] private int vat; //пдв
   

    // Update is called once per frame
    void Update()
    {
        Money += (long)taxes;
        taxes = (peoples * (Taxes / 100))/365;
    }
    public void BuildCoalMine()
    {
        if (Prov.coal)
        {
            if (Money >= CoalMinePrice)
            {
                Prov.AddCoalMine(CoalMinePrice);
            }
        }
    }
    public void BuildIronMine()
    {
        if (Prov.iron)
        {
            if (Money >= IronMinePrice)
            {
                Prov.AddIronMine(IronMinePrice);
            }
        }
    }
    public void BuildOilTower()
    {
        if (Prov.oil)
        {
            if (Money >= OilTowerPrice)
            {
                Prov.AddOilTower(OilTowerPrice);
            }
        }
    }
    public void BuildGasTower()
    {
        if (Prov.gas)
        {
            if (Money >= GasTowerPrice)
            {
                Prov.AddGasTower(GasTowerPrice);
            }
        }
    }
    public void BuildMetalFactory()
    {
        if(Money >= MetalFactoryPrice)
        {
            Prov.AddMetalFactory();
            Money -= MetalFactoryPrice;
        }
    }
    public void BuildAutoFactory()
    {
        if (Money >= AutoFactoryPrice)
        {
            Prov.AddAutoFactory();
            Money -= AutoFactoryPrice;
        }
    }
    public void BuildPlaneFactory()
    {
        if (Money >= PlaneFactoryPrice)
        {
            Prov.AddPlaneFactory();
            Money -= PlaneFactoryPrice;
        }
    }
    public void BuildShipDock()
    {
        if (Money >= ShipDockPrice)
        {
            Prov.AddShipDock();
            Money -= ShipDockPrice;
        }
    }
    public void BuildSewingFactory()
    {
        if (Money >= SewingFactoryPrice)
        {
            Prov.AddSewingFactory();
            Money -= SewingFactoryPrice;
        }
    }
    public void BuildFuelFactory()
    {
        if (Money >= FuelFactoryPrice)
        {
            Prov.AddFuelFactory();
            Money -= FuelFactoryPrice;
        }
    }
    public void BuildElectronicsFactory()
    {
        if (Money >= ElectronicsFactoryPrice)
        {
            Prov.AddElectronicsFactory();
            Money -= ElectronicsFactoryPrice;
        }
    }
    public void BuildItFactory()
    {
        if (Money >= ItFactoryPrice)
        {
            Prov.AddItFactory();
            Money -= ItFactoryPrice;
        }
    }
    public void BuySomething(int price)
    {
        Money -= price;
    }
}
 