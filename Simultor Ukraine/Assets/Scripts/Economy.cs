using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Economy : MonoBehaviour
{
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

    //всього шахт, заводів...
    [SerializeField] private int AllCoalMine;
    [SerializeField] private int AllIronMine;
    [SerializeField] private int AllOilTower;
    [SerializeField] private int AllGasTower;
    [SerializeField] private int AllMetalFactory;
    [SerializeField] private int AllAutoFactory;
    [SerializeField] private int AllPlaneFactory;
    [SerializeField] private int AllShipDock;
    [SerializeField] private int AllSewingFactory;
    [SerializeField] private int AllFuelFactory;
    [SerializeField] private int AllElectronicsFactory;
    [SerializeField] private int AllItFactory;

    //скільки ресурсу на складах
    public int Coal;
    public int Iron;
    public int Oil;//нафта
    public int Gas;

    //вторинні ресурси
    public int Metal;
    public int Fuel;

    //продукція
    public int Auto;
    public int Plane;
    public int Ship;
    public int Clothes;
    public int Electronics;
    public int It;

    public int CoalPrice;
    public int IronPrice;
    public int OilPrice;
    public int GasPrice;
    public int MetalPrice;
    public int FuelPrice;
    public int AutoPrice;
    public int PlanePrice;
    public int ShipPrice;
    public int ClothesPrice;
    public int ElectronicsPrice;
    public int ItPrice;

    //виробнича потужність кожного заводу
    [SerializeField] private int CoalMineCapacity;
    [SerializeField] private int IronMineCapacity;
    [SerializeField] private int OilTowerCapacity;
    [SerializeField] private int GasTowerCapacity;
    [SerializeField] private int MetalFactoryCapacity;
    [SerializeField] private int AutoFactoryCapacity;
    [SerializeField] private int PlaneFactoryCapacity;
    [SerializeField] private int ShipDockCapacity;
    [SerializeField] private int SewingFactoryCapacity;
    [SerializeField] private int FuelFactoryCapacity;
    [SerializeField] private int ElectronicsFactoryCapacity;
    [SerializeField] private int ItFactoryCapacity;

    [SerializeField] Text coal;
    [SerializeField] Text iron;
    [SerializeField] Text oil;
    [SerializeField] Text gas;
    [SerializeField] Text metal;
    [SerializeField] Text fuel;
    [SerializeField] Text auto;
    [SerializeField] Text plane;
    [SerializeField] Text ship;
    [SerializeField] Text clothes;
    [SerializeField] Text electronics;
    [SerializeField] Text it;

    public string provinceTag = "Ukr"; 
    private Province[] provinces;
    [SerializeField] Text totalPopulationText;
    [SerializeField] Text totalGdpText;
    [SerializeField] Text totalIncomeText;
    public long totalPopulation = 0;

    public int SellKoef = 5; //коефіцієнт продажу

    public int CoalImportPrice;
    public int IronImportPrice;
    public int OilImportPrice;
    public int GasImportPrice;
    public int MetalImportPrice;
    public int FuelImportPrice;
    public int ElectronicsImportPrice;

    public Clock clock;

    void Awake()
    {
        ProvLenght();
        AllFactories();
        foreach (Province province in provinces)
        {
            totalPopulation += province.Population;
        }
        totalPopulationText.text = (totalPopulation / 1000000.0).ToString("0.000") + " млн";
        //float totalIncome = totalGdp * incomeCoefficient;
        //totalIncomeText.text = (totalIncome / 1000000.0).ToString("0.000") + " млн";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ProvLenght();//потім перенести в захоплення провінцій і тд
        FactotyProd();
        Money += (long)taxes;
        taxes = (peoples * (Taxes / 100))/365;
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
    public void AllFactories()
    {
        AllCoalMine = 0;
        AllIronMine = 0;
        AllOilTower = 0;
        AllGasTower = 0;
        AllMetalFactory = 0;
        AllFuelFactory = 0;
        AllAutoFactory = 0;
        AllPlaneFactory = 0;
        AllShipDock = 0;
        AllSewingFactory = 0;
        AllElectronicsFactory = 0;
        AllItFactory = 0;

        foreach (Province province in provinces)
        {
            AllCoalMine += province.CoalMine;
            AllIronMine += province.IronMine;
            AllOilTower += province.OilTower;
            AllGasTower += province.GasTower;

            AllMetalFactory += province.MetalFactory;
            AllFuelFactory += province.FuelFactory;

            AllAutoFactory += province.AutoFactory;
            AllPlaneFactory += province.PlaneFactory;
            AllShipDock += province.ShipDock;
            AllSewingFactory += province.SewingFactory;
            AllElectronicsFactory += province.ElectronicsFactory;
            AllItFactory += province.ItFactory;
        }
    }

    public void FactotyProd()
    {
        if (clock.PickMonth)
        {
            Coal += AllCoalMine * CoalMineCapacity;
            Iron += AllIronMine * IronMineCapacity;
            Oil += AllOilTower * OilTowerCapacity;
            Gas += AllGasTower * GasTowerCapacity;

            Coal -= AllMetalFactory;
            Iron -= AllMetalFactory;
            Oil -= AllFuelFactory;
            Gas -= AllAutoFactory + AllPlaneFactory + AllShipDock + AllSewingFactory + AllElectronicsFactory + AllItFactory;

            Metal += AllMetalFactory * MetalFactoryCapacity;
            Auto += AllAutoFactory * AutoFactoryCapacity;
            Plane += AllPlaneFactory * PlaneFactoryCapacity;
            Ship += AllShipDock * ShipDockCapacity;
            Clothes += AllSewingFactory * SewingFactoryCapacity;
            Fuel += AllFuelFactory * FuelFactoryCapacity;
            Electronics += AllElectronicsFactory * ElectronicsFactoryCapacity;
            It += AllItFactory * ItFactoryCapacity;

            Metal -= AllAutoFactory + AllPlaneFactory + AllShipDock + AllElectronicsFactory;
            Fuel -= AllAutoFactory + AllPlaneFactory + AllShipDock;
            Electronics -= AllAutoFactory + AllPlaneFactory + AllShipDock + AllItFactory;
            Import();
            
            ResTextUpdate();
            return;
        }
    }

    public void ResTextUpdate()
    {
        coal.text = Coal.ToString();
        iron.text = Iron.ToString();
        oil.text = Oil.ToString();
        gas.text = Gas.ToString();
        metal.text = Metal.ToString();
        fuel.text = Fuel.ToString();
        auto.text = Auto.ToString();
        plane.text = Plane.ToString();
        ship.text = Ship.ToString();
        clothes.text = Clothes.ToString();
        electronics.text = Electronics.ToString();
        it.text = It.ToString();
    }

    public void Import()
    {
        if (Coal < 0)
        {
            if(Money >= Coal * CoalImportPrice)
            {
                Money -= Coal * CoalImportPrice;
                Coal = 0;
            }
        }
        if (Iron < 0)
        {
            if (Iron >= Iron * IronImportPrice)
            {
                Money -= Iron * IronImportPrice;
                Iron = 0;
            }
        }
        if (Oil < 0)
        {
            if (Money >= Oil * OilImportPrice)
            {
                Money -= Oil * OilImportPrice;
                Oil = 0;
            }
        }
        if (Gas < 0)
        {
            if (Money >= Gas * GasImportPrice)
            {
                Money -= Gas * GasImportPrice;
                Gas = 0;
            }
        }
        if (Metal < 0)
        {
            if (Money >= Metal * MetalImportPrice)
            {
                Money -= Metal * MetalImportPrice;
                Metal = 0;
            }
        }
        if (Fuel < 0)
        {
            if (Money >= Fuel * FuelImportPrice)
            {
                Money -= Fuel * FuelImportPrice;
                Fuel = 0;
            }
        }
        if (Electronics < 0)
        {
            if (Money >= Electronics * ElectronicsImportPrice)
            {
                Money -= Electronics * ElectronicsImportPrice;
                Electronics = 0;
            }
        }
    }

    //продажа ресурсів
    public void SellCoal(bool koef)
    {
        if (Coal > 0)
        {
            if (koef) //якщо з коефіцієнтом
            {
                Coal -= SellKoef;
                Money += SellKoef * CoalPrice;
            }
            else
            {
                Money += Coal * CoalPrice;
                Coal = 0;
            }
            ResTextUpdate();
        }
    }
    public void SellIron(bool koef)
    {
        if (Iron > 0)
        {
            if (koef) //якщо з коефіцієнтом
            {
                Iron -= SellKoef;
                Money += SellKoef * IronPrice;
            }
            else
            {
                Money += Iron * IronPrice;
                Iron = 0;
            }
            ResTextUpdate();
        }
    }
    public void SellOil(bool koef)
    {
        if (Oil > 0)
        {
            if (koef) //якщо з коефіцієнтом
            {
                Oil -= SellKoef;
                Money += SellKoef * OilPrice;
            }
            else
            {
                Money += Oil * OilPrice;
                Oil = 0;
            }
            ResTextUpdate();
        }
    }
    public void SellGas(bool koef)
    {
        if (Gas > 0)
        {
            if (koef) //якщо з коефіцієнтом
            {
                Gas -= SellKoef;
                Money += SellKoef * GasPrice;
            }
            else
            {
                Money += Gas * GasPrice;
                Gas = 0;
            }
            ResTextUpdate();
        }
    }
    public void SellMetal(bool koef)
    {
        if (Metal > 0)
        {
            if (koef) //якщо з коефіцієнтом
            {
                Metal -= SellKoef;
                Money += SellKoef * MetalPrice;
            }
            else
            {
                Money += Metal * MetalPrice;
                Metal = 0;
            }
            ResTextUpdate();
        }
    }
    public void SellFuel(bool koef)
    {
        if (Fuel > 0)
        {
            if (koef) //якщо з коефіцієнтом
            {
                Fuel -= SellKoef;
                Money += SellKoef * FuelPrice;
            }
            else
            {
                Money += Fuel * FuelPrice;
                Fuel = 0;
            }
            ResTextUpdate();
        }
    }
    public void SellAuto(bool koef)
    {
        if (Auto > 0)
        {
            if (koef) //якщо з коефіцієнтом
            {
                Auto -= SellKoef;
                Money += SellKoef * AutoPrice;
            }
            else
            {
                Money += Auto * AutoPrice;
                Auto = 0;
            }
            ResTextUpdate();
        }
    }
    public void SellPlane(bool koef)
    {
        if (Plane > 0)
        {
            if (koef) //якщо з коефіцієнтом
            {
                Plane -= SellKoef;
                Money += SellKoef * PlanePrice;
            }
            else
            {
                Money += Plane * PlanePrice;
                Plane = 0;
            }
            ResTextUpdate();
        }
    }
    public void SellShip(bool koef)
    {
        if (Ship > 0)
        {
            if (koef) //якщо з коефіцієнтом
            {
                Ship -= SellKoef;
                Money += SellKoef * ShipPrice;
            }
            else
            {
                Money += Ship * ShipPrice;
                Ship = 0;
            }
            ResTextUpdate();
        }
    }
    public void SellClothes(bool koef)
    {
        if (Clothes > 0)
        {
            if (koef) //якщо з коефіцієнтом
            {
                Clothes -= SellKoef;
                Money += SellKoef * ClothesPrice;
            }
            else
            {
                Money += Clothes * ClothesPrice;
                Clothes = 0;
            }
            ResTextUpdate();
        }
    }
    public void SellElectronics(bool koef)
    {
        if (Electronics > 0)
        {
            if (koef) //якщо з коефіцієнтом
            {
                Electronics -= SellKoef;
                Money += SellKoef * ElectronicsPrice;
            }
            else
            {
                Money += Electronics * ElectronicsPrice;
                Electronics = 0;
            }
            ResTextUpdate();
        }
    }
    public void SellIt(bool koef)
    {
        if (It > 0)
        {
            if (koef) //якщо з коефіцієнтом
            {
                It -= SellKoef;
                Money += SellKoef * ItPrice;
            }
            else
            {
                Money += It * ItPrice;
                It = 0;
            }
            ResTextUpdate();
        }
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
        AllFactories();
    }
}
 