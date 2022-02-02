using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField]
    private GameObject circlePrefab;
    [SerializeField]
    private GameObject cubePrefab;
    [SerializeField]
    private GameObject trianglePrefab;

    public List<GameObject> circles;
    public List<GameObject> cubes;
    public List<GameObject> triangles;

    private int triangleCount;

    private UIManager managerUI;

    private void Awake()
    {
        managerUI = GameObject.Find("UI Manager").GetComponent<UIManager>();

   
    }

    private void OnEnable()
    {
        if (managerUI.extension.isOn)
        {
            triangleCount = 3;
        }
        else
        {
            triangleCount = 0;
        }
    }

    private void InstantiateShapes(int circlesCount, int cubesCount, int triangleCount)
    {
        for (int i = 0; i < circlesCount; i++)
        {
            circles.Add(Instantiate(circlePrefab, gameObject.transform));
           
        }
        for (int i = 0; i < triangleCount; i++)
        {
            triangles.Add(Instantiate(trianglePrefab, gameObject.transform));

        }

        for (int i = 0; i < cubesCount; i++)
        {
            cubes.Add(Instantiate(cubePrefab, gameObject.transform));
            
        }
    }

    public void DestroyShapes()
    {
        foreach (var circle in circles)
        {
            Destroy(circle);
        }
        foreach (var cube in cubes)
        {
            Destroy(cube);
        }

        foreach (var triangle in triangles)
        {
            Destroy(triangle);
        }
        circles.Clear();
        cubes.Clear();
        triangles.Clear();
    }
    
    public void Levels(int numberLevel)
    {
        switch (numberLevel)
        {
            case 1:
                {
                    InstantiateShapes(3, 4, triangleCount);
                    break;
                }
            case 2:
                {
                    InstantiateShapes(4, 6, triangleCount);
                    break;
                }
            case 3:
                {
                    InstantiateShapes(3, 6, triangleCount);
                    break;
                }
            default:
                {
                    
                    break;
                }
        }
    }
   
    
}
