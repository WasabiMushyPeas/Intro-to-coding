using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static bool mouseDown;

    public List<GameObject> planets;
    private GameObject child;
    private GameObject cloneOfPlanet;

    private float force;
    private Vector2 forceDirection;

    private Vector3 mousePos;
    private bool needToAddForce;

    private bool needToSpawn = true;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;

            if (needToSpawn)
            {
                
                print(Input.GetAxisRaw("Fire1"));
                
                
                var planet = Random.Range(0, 4);
                
                cloneOfPlanet = Instantiate(planets[planet],
                    new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                        Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0), Quaternion.identity);
                
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                needToSpawn = false;
                
                child = cloneOfPlanet.transform.GetChild(0).gameObject;
                child.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }

            if (!needToSpawn)
                while (0 < Input.GetAxisRaw("Fire1"))
                {
                    
                    print(Input.GetAxisRaw("Fire1"));
                    
                    
                    forceDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - child.transform.position;

                    force = Mathf.Atan2(forceDirection.y, forceDirection.x) * Mathf.Rad2Deg;

                    needToAddForce = true;

                    Debug.Log(needToAddForce + " " + force + " " + forceDirection);
                }
        }

        if (Input.GetMouseButtonUp(0) && needToAddForce)
        {
            print(Input.GetAxisRaw("Fire1"));
            
            
            needToSpawn = true;
            mouseDown = false;


            child.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            child.GetComponent<Rigidbody2D>().AddRelativeForce(forceDirection * (force + 1), ForceMode2D.Impulse);
            needToAddForce = false;
        }
    }
}