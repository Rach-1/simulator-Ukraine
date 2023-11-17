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
}