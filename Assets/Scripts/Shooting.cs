using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public LineRenderer lineRenderer;
    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot();          
        }
    }
    IEnumerator HandleFire()
    {
        Debug.Log("Waited");
        yield return new WaitForSeconds(0.5f);
    }
   /* void Shoot()
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, mousePos - new Vector2(firePoint.position.x, firePoint.position.y), 2000f);
        HandleFire();
        if (hit)
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hit.point);
            if (hit.transform.CompareTag("Enemy"))
            {
                Debug.Log("Hit Enemy");
                enemyhp = hit.transform.parent.gameObject.GetComponent<EnemyHP>();
                enemyhp.GetShot();
            }
        }
    }*/
}
