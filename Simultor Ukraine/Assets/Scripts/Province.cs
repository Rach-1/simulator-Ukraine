using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

public class Province : MonoBehaviour
{
    public GameObject ProvMenu;
    public string Name; // Назва регіону
    public long Population; // Населення
    public long Gdp; // ВВП
    private Dictionary<string, string> tagToWord = new Dictionary<string, string>(); // Словник 
    public Economy economy;
    public Clock clock;

    //наявність ресурсів для видобутку
    public bool coal;
    public bool iron;
    public bool oil;//нафта
    public bool gas;

    //скільки ресурсу на складах
    public int Coal;
    public int Iron;
    public int Oil;//нафта
    public int Gas;

    //ліміти
    public int CoalLim;
    public int IronLim;
    public int OilLim;//нафта
    public int GasLim;

    //вторинні ресурси
    public int Metal;

    //продукція
    public int Auto;
    public int Plane;
    public int Ship;
    public int Clothes;
    public int Fuel;
    public int Electronics;
    public int It;

    //заводи 
    public int CoalMine;
    public int IronMine;
    public int OilTower;
    public int GasTower;
    public int MetalFactory;
    public int AutoFactory;
    public int PlaneFactory;
    public int ShipDock;
    public int SewingFactory;
    public int FuelFactory;
    public int ElectronicsFactory;
    public int ItFactory;

    //виробнича здатність кожного заводу
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

    [SerializeField] new Text name;
    [SerializeField] Text population;
    [SerializeField] Text coalT;
    [SerializeField] Text ironT;
    [SerializeField] Text oilT;
    [SerializeField] Text gasT;
    [SerializeField] Text displaytext;

    void Awake()
    {
        // Тут тег - країна
        tagToWord.Add("Ukr", "Ukraine");
        tagToWord.Add("Pol", "Poland");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

            if (hitCollider != null && hitCollider.GetComponent<Province>() != null)
            {
                hitCollider.GetComponent<Province>().OpenMenu();
                economy.Prov = hitCollider.GetComponent<Province>();
            }
            else
            {
                //ProvMenu.SetActive(false);
            }

            //економіка
            if (clock.PickMonth)
            {
                Coal += CoalMine * CoalMineCapacity;
                Iron += IronMine * IronMineCapacity;
                Oil += OilTower * OilTowerCapacity;
                Gas += GasTower * GasTowerCapacity;

                Coal -= MetalFactory;
                Iron -= MetalFactory;
                Oil -= FuelFactory;
                Gas -= AutoFactory + PlaneFactory + ShipDock + SewingFactory + ElectronicsFactory + ItFactory;

                Metal += MetalFactory * MetalFactoryCapacity;
                Auto += AutoFactory * AutoFactoryCapacity;
                Plane += PlaneFactory * PlaneFactoryCapacity;
                Ship += ShipDock * ShipDockCapacity;
                Clothes += SewingFactory * SewingFactoryCapacity;
                Fuel += FuelFactory * FuelFactoryCapacity;
                Electronics += ElectronicsFactory * ElectronicsFactoryCapacity;
                It += ItFactory * ItFactoryCapacity;

                Metal -= AutoFactory + PlaneFactory + ShipDock + ElectronicsFactory;
                Fuel -= AutoFactory + PlaneFactory + ShipDock;
                Electronics -= AutoFactory + PlaneFactory + ShipDock + ItFactory;
            }
        }
    }
    
    public void OpenMenu()
    {
        ProvMenu.SetActive(true);
        name.text = "Назва регіону: " + Name;
        population.text = "Населення регіону: " + (Population / 1000000.0).ToString("0.000") + " млн";
        coalT.text = "Вугілля: " + CoalMine + "/" + CoalLim;
        ironT.text = "Залізо: " + IronMine + "/" + IronLim;
        oilT.text = "Нафта: " + OilTower + "/" + OilLim;
        gasT.text = "Газ: " + GasTower + "/" + GasLim;
        string country;
        if (tagToWord.TryGetValue(tag, out country))
        {
            displaytext.text = "Країна: " + country;
        }
        else
        {
            displaytext.text = "Країна: Невідома";
        }
    }

    public void AddCoalMine(int coalMinePrice)
    {
        if (Coal < CoalLim)
        {
            CoalMine++;
            economy.BuySomething(coalMinePrice);
            OpenMenu();
        }
    }
    public void AddIronMine(int ironMinePrice)
    {
        if (Iron < IronLim)
        {
            IronMine++;
            economy.BuySomething(ironMinePrice);
            OpenMenu();
        }
    }
    public void AddOilTower(int oilTowerPrice)
    {
        if (Oil < OilLim)
        {
            OilTower++;
            economy.BuySomething(oilTowerPrice);
            OpenMenu();
        }
    }
    public void AddGasTower(int gasTowerPrice)
    {
        if (Gas < GasLim)
        {
            GasTower++;
            economy.BuySomething(gasTowerPrice);
            OpenMenu();
        }
    }
    public void AddMetalFactory()
    {
        MetalFactory++;
        OpenMenu();
    }
    public void AddAutoFactory()
    {
        AutoFactory++;
        OpenMenu();
    }
    public void AddPlaneFactory()
    {
        PlaneFactory++;
        OpenMenu();
    }
    public void AddShipDock()
    {
        ShipDock++;
        OpenMenu();
    }
    public void AddSewingFactory()
    {
        SewingFactory++;
        OpenMenu();
    }
    public void AddFuelFactory()
    {
        FuelFactory++;
        OpenMenu();
    }
    public void AddElectronicsFactory()
    {
        ElectronicsFactory++;
        OpenMenu();
    }
    public void AddItFactory()
    {
        ItFactory++;
        OpenMenu();
    }
}