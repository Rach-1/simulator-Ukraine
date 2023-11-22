using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Province : MonoBehaviour
{
    public GameObject ProvMenu;
    public string Name; // ����� ������
    public long Population; // ���������
    public long Gdp; // ���
    private Dictionary<string, string> tagToWord = new Dictionary<string, string>(); // ������� 
    public Economy economy;

    //�������� ������� ��� ���������
    public bool coal;
    public bool iron;
    public bool oil;//�����
    public bool gas;

    //�������, ������ ������������
    public int Coal;
    public int Iron;
    public int Oil;//�����
    public int Gas;

    //����
    public int CoalLim;
    public int IronLim;
    public int OilLim;//�����
    public int GasLim;

    //������� �������
    public int Metal;

    //���������
    public int Auto;
    public int Plane;
    public int Fuel;
    public int It;

    //������ 
    public int CoalMine;
    public int IronMine;
    public int OilTower;
    public int GasTower;
    public int MetalFactory;
    public int AutoFactory;
    public int PlaneFactory;
    public int FuelFactory;
    public int ItFactory;

    //������� �������� 
    public int CoalMinePrice;
    public int IronMinePrice;
    public int OilTowerPrice;
    public int GasTowerPrice;
    public int MetalFactoryPrice;
    public int AutoFactoryPrice;
    public int PlaneFactoryPrice;
    public int FuelFactoryPrice;
    public int ItFactoryPrice;

    //��������� �������� ������� ������
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
        // ��� ��� - �����
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
        name.text = "����� ������: " + Name;
        population.text = "��������� ������: " + (Population / 1000000.0).ToString("0.000") + " ���";
        gdp.text = "��� ������: " + (Gdp / 1000000000.0).ToString("0.000") + " ����";
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