using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Province : MonoBehaviour
{
    public GameObject ProvMenu;
    public string Name; // ����� ������
    public long Pop; // ���������
    public int PopIncrease;
    public int Develompment; //��������
    public int DevCost; //���� ��������
    public int DevCostIncrease; //���� ���� �������� ��� ��������
    private Dictionary<string, string> tagToWord = new Dictionary<string, string>(); // ������� 
    public Economy economy;
    public Clock clock;
    public Population population;

    //��������� ������� ��� ���������
    public bool coal;
    public bool iron;
    public bool oil;//�����
    public bool gas;

    //����
    public int CoalLim;
    public int IronLim;
    public int OilLim;//�����
    public int GasLim;

    //������ 
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
    [SerializeField] Text populationT;
    [SerializeField] Text develompmentT;
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
        // ��� ��� - �����
        tagToWord.Add("Ukr", "Ukraine");
        tagToWord.Add("Pol", "Poland");

        PopIncrease = ((int)(Develompment * population.PopulationIncomeKoef))*10;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

            if (hitCollider != null && hitCollider.GetComponent<Province>() != null)
            {
                if (EventSystem.current.IsPointerOverGameObject())//���� ��� ��'����� � ���� (ui)
                {
                    return;
                }
                hitCollider.GetComponent<Province>().OpenMenu();
                economy.Prov = hitCollider.GetComponent<Province>();
                population.Prov = hitCollider.GetComponent<Province>();
            }
            else
            {
                //ProvMenu.SetActive(false);
            }
        }
        PopulationIncrease();
    }
    
    public void OpenMenu()
    {
        ProvMenu.SetActive(true);
        name.text = "����� ������: " + Name;
        populationT.text = "��������� ������: " + (Pop / 1000000.0).ToString("0.000") + " ���";
        coalT.text = "������: " + CoalMine + "/" + CoalLim;
        ironT.text = "�����: " + IronMine + "/" + IronLim;
        oilT.text = "�����: " + OilTower + "/" + OilLim;
        gasT.text = "���: " + GasTower + "/" + GasLim;
        develompmentT.text = "��������: " + Develompment;
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
            displaytext.text = "�����: " + country;
        }
        else
        {
            displaytext.text = "�����: �������";
        }
    }

    public void DevIncrease()
    {
        if(DevCost <= population.DevelopmentPoint)
        {
            population.DevelopmentPoint -= DevCost;
            Develompment++;
            DevCost += DevCostIncrease;
            PopIncrease = ((int)(Develompment * population.PopulationIncomeKoef)) * 10;
            develompmentT.text = "��������: " + Develompment;
            population.ResTextUpdate();
        }
    }
    
    public void PopulationIncrease()
    {
        if(clock.PickMonth)
        {
            Pop += PopIncrease;
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
    public void AddMetalFactory(int metalFactoryPrice)
    {
        MetalFactory++;
        economy.BuySomething(metalFactoryPrice);
        OpenMenu();
    }
    public void AddAutoFactory(int autoFactoryPrice)
    {
        AutoFactory++;
        economy.BuySomething(autoFactoryPrice);
        OpenMenu();
    }
    public void AddPlaneFactory(int planeFactoryPrice)
    {
        PlaneFactory++;
        economy.BuySomething(planeFactoryPrice);
        OpenMenu();
    }
    public void AddShipDock(int shipFactoryPrice)
    {
        ShipDock++;
        economy.BuySomething(shipFactoryPrice);
        OpenMenu();
    }
    public void AddSewingFactory(int sewingFactoryPrice)
    {
        SewingFactory++;
        economy.BuySomething(sewingFactoryPrice);
        OpenMenu();
    }
    public void AddFuelFactory(int fuelFactoryPrice)
    {
        FuelFactory++;
        economy.BuySomething(fuelFactoryPrice);
        OpenMenu();
    }
    public void AddElectronicsFactory(int electronicsFactoryPrice)
    {
        ElectronicsFactory++;
        economy.BuySomething(electronicsFactoryPrice);
        OpenMenu();
    }
    public void AddItFactory(int itFactoryPrice)
    {
        ItFactory++;
        economy.BuySomething(itFactoryPrice);
        OpenMenu();
    }
}