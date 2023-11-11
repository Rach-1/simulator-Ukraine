using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Province : MonoBehaviour
{
    public GameObject ProvMenu;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
            if (hitCollider != null && hitCollider.GetComponent<Province>() != null)
            {
                ProvMenu.SetActive(true);
            }
            else
            {
                ProvMenu.SetActive(false);
            }
        }
    }
}
