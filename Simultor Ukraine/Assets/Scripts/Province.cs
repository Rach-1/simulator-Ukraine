using UnityEngine;
using UnityEngine.UI;

public class Province : MonoBehaviour
{
    public GameObject ProvMenu;
    public string Name;
    public string CountryTag;
    public int Population;
    public float Natality; //приріст населення

    [SerializeField] Text name;
    [SerializeField] Text population;
    [SerializeField] Text natality;

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
        name.text = Name;
        population.text = Population.ToString();
        natality.text = Natality.ToString();
    }
}
