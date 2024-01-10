using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Province : MonoBehaviour
{
    public GameObject ProvMenu;
    public string Name; // Назва регіону
    public long Population; // Населення
    private Dictionary<string, string> tagToWord = new Dictionary<string, string>(); // Словник 
    public Economy economy;
    public Clock clock;

    //наявність ресурсів для видобутку
    public bool coal;
    public bool iron;
    public bool oil;//нафта
    public bool gas;

    //ліміти
    public int CoalLim;
    public int IronLim;
    public int OilLim;//нафта
    public int GasLim;

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

    [SerializeField] new Text name;
    [SerializeField] Text population;
    [SerializeField] Text coalT;
    [SerializeField] Text ironT;
    [SerializeField] Text oilT;
    [SerializeField] Text gasT;
    [SerializeField] Text metalT;
    [SerializeField] Text fuelT;
    [SerializeField] Text autoT;
    [SerializeField] Text planeT;
    [SerializeField] Text shipT;
    [SerializeField] Text sewingT;
    [SerializeField] Text electronicsT;
    [SerializeField] Text ItT;
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
                if (EventSystem.current.IsPointerOverGameObject())//якщл над об'єктом є щось (ui)
                {
                    return;
                }
                hitCollider.GetComponent<Province>().OpenMenu();
                economy.Prov = hitCollider.GetComponent<Province>();
            }
            else
            {
                //ProvMenu.SetActive(false);
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
        metalT.text = MetalFactory.ToString();
        fuelT.text = FuelFactory.ToString();
        autoT.text = AutoFactory.ToString();
        planeT.text = PlaneFactory.ToString();
        shipT.text = ShipDock.ToString();
        sewingT.text = SewingFactory.ToString();
        electronicsT.text = ElectronicsFactory.ToString();
        ItT.text = ItFactory.ToString();

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
        if (CoalMine < CoalLim)
        {
            CoalMine++;
            economy.BuySomething(coalMinePrice);
            OpenMenu();
        }
    }
    public void AddIronMine(int ironMinePrice)
    {
        if (IronMine < IronLim)
        {
            IronMine++;
            economy.BuySomething(ironMinePrice);
            OpenMenu();
        }
    }
    public void AddOilTower(int oilTowerPrice)
    {
        if (OilTower < OilLim)
        {
            OilTower++;
            economy.BuySomething(oilTowerPrice);
            OpenMenu();
        }
    }
    public void AddGasTower(int gasTowerPrice)
    {
        if (GasTower < GasLim)
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