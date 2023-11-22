using System.Collections.Generic;
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

    //наявність ресурсів для видобутку
    public bool coal;
    public bool iron;
    public bool oil;//нафта
    public bool gas;

    //ресурси, скільки видобувається
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
    public int Fuel;
    public int It;

    //заводи 
    public int CoalMine;
    public int IronMine;
    public int OilTower;
    public int GasTower;
    public int MetalFactory;
    public int AutoFactory;
    public int PlaneFactory;
    public int FuelFactory;
    public int ItFactory;

    //вартість подудови 
    public int CoalMinePrice;
    public int IronMinePrice;
    public int OilTowerPrice;
    public int GasTowerPrice;
    public int MetalFactoryPrice;
    public int AutoFactoryPrice;
    public int PlaneFactoryPrice;
    public int FuelFactoryPrice;
    public int ItFactoryPrice;

    //виробнича здатність кожного заводу
    [SerializeField] private int CoalMineCapacity;
    [SerializeField] private int IronMineCapacity;
    [SerializeField] private int OilTowerCapacity;
    [SerializeField] private int GasTowerCapacity;
    [SerializeField] private int MetalFactoryCapacity;
    [SerializeField] private int AutoFactoryCapacity;
    [SerializeField] private int PlaneFactoryCapacity;
    [SerializeField] private int FuelFactoryCapacity;
    [SerializeField] private int ItFactoryCapacity;

    [SerializeField] new Text name;
    [SerializeField] Text population;
    [SerializeField] Text gdp;
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
            }
            else
            {
                ProvMenu.SetActive(false);
            }
        }
    }
    
    public void OpenMenu()
    {
        ProvMenu.SetActive(true);
        name.text = "Назва регіону: " + Name;
        population.text = "Населення регіону: " + (Population / 1000000.0).ToString("0.000") + " млн";
        gdp.text = "ВВП регіону: " + (Gdp / 1000000000.0).ToString("0.000") + " млрд";
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
    public void BuildCoalMine()
    {
        if(coal)
        {
            if(Coal < CoalLim)
            {
                CoalMine++;
                economy.Money -= CoalMinePrice;
            }
        }
    }
    public void BuildIronMine()
    {
        if (iron)
        {
            if (Iron < IronLim)
            {
                IronMine++;
                economy.Money -= IronMinePrice;
            }
        }
    }
    public void BuildOilTowerMine()
    {
        if (oil)
        {
            if (Oil < OilLim)
            {
                OilTower++;
                economy.Money -= OilTowerPrice;
            }
        }
    }
    public void BuildGasTowerMine()
    {
        if (gas)
        {
            if (Gas < GasLim)
            {
                GasTower++;
                economy.Money -= GasTowerPrice;
            }
        }
    }
}