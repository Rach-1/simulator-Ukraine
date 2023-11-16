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
}