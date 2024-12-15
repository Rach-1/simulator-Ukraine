using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Economy : MonoBehaviour
{
    public float taxes;
    public GameObject prov;
    public Province Prov;
    public Population population;

    public float Taxes;
    public int Money;
    public int Income;
    public int ResIncome;
    public int Outcome;
    public int ResOutcome;
    public int CorruptionOutcome;
    public float Corruption;
    public float Inflation;
    public int InflationOutcome;

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

    public bool CoalAutoSale = false;
    public bool IronAutoSale = false;
    public bool OilAutoSale = false;
    public bool GasAutoSale = false;
    public bool MetalAutoSale = true;
    public bool FuelAutoSale = true;
    public bool AutoAutoSale = true;
    public bool PlaneAutoSale = true;
    public bool ShipAutoSale = true;
    public bool ClothesAutoSale = true;
    public bool ElectronicsAutoSale = true;
    public bool ItAutoSale = true;

    [SerializeField] private int minSave = 50;

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
    [SerializeField] Text moneyText;
    [SerializeField] Text totalIncomeText;
    [SerializeField] Text corruptionText;
    [SerializeField] Text inflationText;
    [SerializeField] Text incomeText;
    [SerializeField] Text taxesIncomeText;
    [SerializeField] Text resIncomeText;
    [SerializeField] Text outcomeText;
    [SerializeField] Text resOutcomeText;
    [SerializeField] Text corruptionOutcomeText;
    [SerializeField] Text inflationOutcomeText;

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
        ResTextUpdate();
        //float totalIncome = totalGdp * incomeCoefficient;
        //totalIncomeText.text = (totalIncome / 1000000.0).ToString("0.000") + " млн";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ProvLenght();//потім перенести в захоплення провінцій і тд
        FactotyProd();
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
            AutoSale();

            taxes = (population.TotalPopulation * ((Taxes / 100)) / 12) / (Corruption / 100);
            Income += (int)taxes;
            Outcome += ResOutcome;

            Income += (int)ResIncome;
            Money += (int)Income;
            Money += (int)Outcome;

            ResTextUpdate();

            Income = 0;
            Outcome = 0;
            ResIncome = 0;
            ResOutcome = 0;
            CorruptionOutcome = 0;
            InflationOutcome = 0;

            return;
        }
    }

    public void CorruptionCgange(float change, int price)
    {
        Corruption -= change;
        CorruptionOutcome -= price;
        Outcome -= price;
        ResTextUpdate();
    }
    public void InflationCgange(float change, int price)
    {
        Inflation -= change;
        InflationOutcome -= price;
        Outcome -= price;
        ResTextUpdate();
    }  
    //автопродаж ресурсів
    public void AutoSale()
    {
        if(CoalAutoSale)
        {
            if(Coal >= minSave)
            {
                ResIncome += (Coal - minSave) * (int)(CoalPrice + CoalPrice * (Inflation / 100));
                Coal = minSave;
            }
        }
        if(IronAutoSale)
        {
            if (Iron >= minSave)
            {
                ResIncome += (Iron - minSave) * (int)(IronPrice + IronPrice * (Inflation / 100));
                Iron = minSave;
            }
        }
        if (OilAutoSale)
        {
            if (Oil >= minSave)
            {
                ResIncome += (Oil - minSave) * (int)(OilPrice + OilPrice * (Inflation / 100));
                Oil = minSave;
            }
        }
        if (GasAutoSale)
        {
            if (Gas >= minSave)
            {
                ResIncome += (Gas - minSave) * (int)(GasPrice + GasPrice * (Inflation / 100));
                Gas = minSave;
            }
        }
        if (MetalAutoSale)
        {
            if (Metal >= minSave)
            {
                ResIncome += (Metal - minSave) * (int)(MetalPrice + MetalPrice * (Inflation / 100));
                Metal = minSave;
            }
        }
        if (FuelAutoSale)
        {
            if (Fuel >= minSave)
            {
                ResIncome += (Fuel - minSave) * (int)(FuelPrice + FuelPrice * (Inflation / 100));
                Fuel = minSave;
            }
        }
        if (AutoAutoSale)
        {
            if (Auto >= minSave)
            {
                ResIncome += (Auto - minSave) * (int)(AutoPrice + AutoPrice * (Inflation / 100));
                Auto = minSave;
            }
        }
        if (PlaneAutoSale)
        {
            if (Plane >= minSave)
            {
                ResIncome += (Plane - minSave) * (int)(PlanePrice + PlanePrice * (Inflation / 100));
                Plane = minSave;
            }
        }
        if (ShipAutoSale)
        {
            if (Ship >= minSave)
            {
                ResIncome += (Ship - minSave) * (int)(ShipPrice + ShipPrice * (Inflation / 100));
                Ship = minSave;
            }
        }
        if (ClothesAutoSale)
        {
            if (Clothes >= minSave)
            {
                ResIncome += (Clothes - minSave) * (int)(ClothesPrice + ClothesPrice * (Inflation / 100));
                Clothes = minSave;
            }
        }
        if (ElectronicsAutoSale)
        {
            if (Electronics >= minSave)
            {
                ResIncome += (Electronics - minSave) * (int)(ElectronicsPrice + ElectronicsPrice * (Inflation / 100));
                Electronics = minSave;
            }
        }
        if (ItAutoSale)
        {
            if (It >= minSave)
            {
                ResIncome += (It - minSave) * (int)(ItPrice + ItPrice * (Inflation / 100));
                It = minSave;
            }
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

        moneyText.text = Money.ToString();
        corruptionText.text = Corruption.ToString();
        inflationText.text = Inflation.ToString();
        incomeText.text = Income.ToString();
        taxesIncomeText.text = taxes.ToString();
        resIncomeText.text = ResIncome.ToString();
        outcomeText.text = Outcome.ToString();
        resOutcomeText.text = ResOutcome.ToString();
        corruptionOutcomeText.text = CorruptionOutcome.ToString();
        inflationOutcomeText.text = InflationOutcome.ToString();
    }

    public void Import()
    {
        if (Coal < 0)
        {
            if(Money >= Coal * CoalImportPrice)
            {
                ResOutcome += Coal * (int)(CoalImportPrice + CoalImportPrice * (Corruption / 100) + CoalImportPrice * (Inflation / 100));
                Coal = 0;
            }
        }
        if (Iron < 0)
        {
            if (Money >= Iron * IronImportPrice)
            {
                ResOutcome += Iron * (int)(IronImportPrice + IronImportPrice * (Corruption / 100) + IronImportPrice * (Inflation / 100));
                Iron = 0;
            }
        }
        if (Oil < 0)
        {
            if (Money >= Oil * OilImportPrice)
            {
                ResOutcome += Oil * (int)(OilImportPrice + OilImportPrice * (Corruption / 100) + OilImportPrice * (Inflation / 100));
                Oil = 0;
            }
        }
        if (Gas < 0)
        {
            if (Money >= Gas * GasImportPrice)
            {
                ResOutcome += Gas * (int)(GasImportPrice + GasImportPrice * (Corruption / 100) + GasImportPrice * (Inflation / 100));
                Gas = 0;
            }
        }
        if (Metal < 0)
        {
            if (Money >= Metal * MetalImportPrice)
            {
                ResOutcome += Metal * (int)(MetalImportPrice + MetalImportPrice * (Corruption / 100) + MetalImportPrice * (Inflation / 100));
                Metal = 0;
            }
        }
        if (Fuel < 0)
        {
            if (Money >= Fuel * FuelImportPrice)
            {
                ResOutcome += Fuel * (int)(FuelImportPrice + FuelImportPrice * (Corruption / 100) + FuelImportPrice * (Inflation / 100));
                Fuel = 0;
            }
        }
        if (Electronics < 0)
        {
            if (Money >= Electronics * ElectronicsImportPrice)
            {
                ResOutcome += Electronics * (int)(ElectronicsImportPrice + ElectronicsImportPrice * (Corruption / 100) + ElectronicsImportPrice * (Inflation / 100));
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
                Money += SellKoef * (int)(CoalPrice + CoalPrice * (Inflation / 100));
            }
            else
            {
                Money += Coal * (int)(CoalPrice + CoalPrice * (Inflation / 100));
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
                Money += SellKoef * (int)(IronPrice + IronPrice * (Inflation / 100));
            }
            else
            {
                Money += Iron * (int)(IronPrice + IronPrice * (Inflation / 100));
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
                Money += SellKoef * (int)(OilPrice + OilPrice * (Inflation / 100));
            }
            else
            {
                Money += Oil * (int)(OilPrice + OilPrice * (Inflation / 100));
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
                Money += SellKoef * (int)(GasPrice + GasPrice * (Inflation / 100));
            }
            else
            {
                Money += Gas * (int)(GasPrice + GasPrice * (Inflation / 100));
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
                Money += SellKoef * (int)(MetalPrice + MetalPrice * (Inflation / 100));
            }
            else
            {
                Money += Metal * (int)(MetalPrice + MetalPrice * (Inflation / 100));
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
                Money += SellKoef * (int)(FuelPrice + FuelPrice * (Inflation / 100));
            }
            else
            {
                Money += Fuel * (int)(FuelPrice + FuelPrice * (Inflation / 100));
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
                Money += SellKoef * (int)(AutoPrice + AutoPrice * (Inflation / 100));
            }
            else
            {
                Money += Auto * (int)(AutoPrice + AutoPrice * (Inflation / 100));
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
                Money += SellKoef * (int)(PlanePrice + PlanePrice * (Inflation / 100));
            }
            else
            {
                Money += Plane * (int)(PlanePrice + PlanePrice * (Inflation / 100));
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
                Money += SellKoef * (int)(ShipPrice + ShipPrice * (Inflation / 100));
            }
            else
            {
                Money += Ship * (int)(ShipPrice + ShipPrice * (Inflation / 100));
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
                Money += SellKoef * (int)(ClothesPrice + ClothesPrice * (Inflation / 100));
            }
            else
            {
                Money += Clothes * (int)(ClothesPrice + ClothesPrice * (Inflation / 100));
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
                Money += SellKoef * (int)(ElectronicsPrice + ElectronicsPrice * (Inflation / 100));
            }
            else
            {
                Money += Electronics * (int)(ElectronicsPrice + ElectronicsPrice * (Inflation / 100));
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
                Money += SellKoef * (int)(ItPrice + ItPrice * (Inflation / 100));
            }
            else
            {
                Money += It * (int)(ItPrice + ItPrice * (Inflation / 100));
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
            Prov.AddMetalFactory(MetalFactoryPrice);
        }
    }
    public void BuildAutoFactory()
    {
        if (Money >= AutoFactoryPrice)
        {
            Prov.AddAutoFactory(AutoFactoryPrice);
        }
    }
    public void BuildPlaneFactory()
    {
        if (Money >= PlaneFactoryPrice)
        {
            Prov.AddPlaneFactory(PlaneFactoryPrice);
        }
    }
    public void BuildShipDock()
    {
        if (Money >= ShipDockPrice)
        {
            Prov.AddShipDock(ShipDockPrice);
        }
    }
    public void BuildSewingFactory()
    {
        if (Money >= SewingFactoryPrice)
        {
            Prov.AddSewingFactory(SewingFactoryPrice);
        }
    }
    public void BuildFuelFactory()
    {
        if (Money >= FuelFactoryPrice)
        {
            Prov.AddFuelFactory(FuelFactoryPrice);
        }
    }
    public void BuildElectronicsFactory()
    {
        if (Money >= ElectronicsFactoryPrice)
        {
            Prov.AddElectronicsFactory(ElectronicsFactoryPrice);
        }
    }
    public void BuildItFactory()
    {
        if (Money >= ItFactoryPrice)
        {
            Prov.AddItFactory(ItFactoryPrice);
        }
    }
    public void BuySomething(int price)
    {
        Money -= price + (int)(price * (Corruption / 100) + price * (Inflation / 100));
        AllFactories();
        ResTextUpdate();
    }
    
    //функції автопродажу для тумблера
    public void AutoSellCoal()
    {
        if(CoalAutoSale)
        {
            CoalAutoSale = false;
        }
        else
        {
            CoalAutoSale = true;
        }
    }
    public void AutoSellIron()
    {
        if (IronAutoSale)
        {
            IronAutoSale = false;
        }
        else
        {
            IronAutoSale = true;
        }
    }
    public void AutoSellOil()
    {
        if (OilAutoSale)
        {
            OilAutoSale = false;
        }
        else
        {
            OilAutoSale = true;
        }
    }
    public void AutoSellGas()
    {
        if (GasAutoSale)
        {
            GasAutoSale = false;
        }
        else
        {
            GasAutoSale = true;
        }
    }
    public void AutoSellMetal()
    {
        if (MetalAutoSale)
        {
            MetalAutoSale = false;
        }
        else
        {
            MetalAutoSale = true;
        }
    }
    public void AutoSellFuel()
    {
        if (FuelAutoSale)
        {
            FuelAutoSale = false;
        }
        else
        {
            FuelAutoSale = true;
        }
    }
    public void AutoSellAuto()
    {
        if (AutoAutoSale)
        {
            AutoAutoSale = false;
        }
        else
        {
            AutoAutoSale = true;
        }
    }
    public void AutoSellPlane()
    {
        if (PlaneAutoSale)
        {
            PlaneAutoSale = false;
        }
        else
        {
            PlaneAutoSale = true;
        }
    }
    public void AutoSellShip()
    {
        if (ShipAutoSale)
        {
            ShipAutoSale = false;
        }
        else
        {
            ShipAutoSale = true;
        }
    }
    public void AutoSellClothes()
    {
        if (ClothesAutoSale)
        {
            ClothesAutoSale = false;
        }
        else
        {
            ClothesAutoSale = true;
        }
    }
    public void AutoSellElectronics()
    {
        if (ElectronicsAutoSale)
        {
            ElectronicsAutoSale = false;
        }
        else
        {
            ElectronicsAutoSale = true;
        }
    }
    public void AutoSellIt()
    {
        if (ItAutoSale)
        {
            ItAutoSale = false;
        }
        else
        {
            ItAutoSale = true;
        }
    }
}
 