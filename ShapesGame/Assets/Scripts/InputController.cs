using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    private GameObject cube;
    private GameObject circle;
    private GameObject triangle;


    private UIManager managerUI;

    private void Start()
    {
        managerUI = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D ray = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (ray != false)
            {
                SelectShapes(ray.collider.gameObject);
               
            }
        }
    }

    private void SelectShapes(GameObject shape)
    {

        if (shape.CompareTag("Triangle"))
        {
            triangle = shape;
        }

        if(shape.CompareTag("Cube") && triangle != null)
        {
            ChangeSize(shape);

        }

        if (shape.CompareTag("Cube"))
        {
            cube = shape;
        }
        if (shape.CompareTag("Circle") && cube != null)
        {
            circle = shape;
            StartCoroutine(DestroyShapes(cube,circle));
        }

        
        
    }

    private void ChangeSize(GameObject cube)
    {
        if(managerUI.energy != 0)
        {
            cube.GetComponent<Shape>().GetSize(cube.GetComponent<Shape>().Size - 1);
            triangle.SetActive(false);
            managerUI.energy--;
            managerUI.ChangeTextEnergy();
        }
       
        triangle = null;
    }

   private IEnumerator DestroyShapes(GameObject currentCube , GameObject currentCircle)
   {
        if (currentCube.GetComponent<Shape>().Size == currentCircle.GetComponent<Shape>().Size)
        {
            currentCube.transform.position = currentCircle.transform.position;
            cube = null;
            circle = null;
            yield return new WaitForSeconds(1);
            managerUI.moves++;
            managerUI.ChangeTextMoves();
            currentCube.SetActive(false);
            currentCircle.SetActive(false);
            

        }
        

   }

  
}
