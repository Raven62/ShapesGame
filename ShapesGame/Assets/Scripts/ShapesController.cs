using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesController : MonoBehaviour
{
   

    private Pool pool;
    private List<GameObject> circles;
    private List<GameObject> cubes;
    private List<GameObject> triangles;


    private GameObject[] mapSpawn;
    private Vector2[] mapSpawnPosition;
    
    [SerializeField]
    private float distance = 1.5f;
    private float maxSize;

    


    private void Awake()
    {
        pool = GameObject.Find("Pool").GetComponent<Pool>();
       
    }

    private void OnEnable()
    {
        triangles = pool.triangles;
        circles = pool.circles;
        cubes = pool.cubes;
        RestartLevel();
    }

    private void Update()
    {
        if (CheckCircelInScene())
        {
            RestartLevel();
        }
    }

    private void GetSize()
    {
       
        maxSize = 100;
        maxSize = (maxSize / (circles.Count + cubes.Count + triangles.Count) / 10);
        int[] circleSize = new int[circles.Count];
        if (maxSize > 0.9f)
        {
            maxSize = 0.9f;
        }

        foreach (var item in circles)
        {
            item.SetActive(true);
            int size = Random.Range(20, (int)(maxSize * 100));
            item.GetComponent<Shape>().GetSize(size);
            for (int i = 0; i < circleSize.Length; i++)
            {
                if (circleSize[i] == 0)
                {
                    circleSize[i] = size;
                    break;
                }
            }
        }



        for (int i = 0; i < circleSize.Length; i++)
        {

            foreach (var item in cubes)
            {
                item.SetActive(true);
                if (item.GetComponent<Shape>().Size == 0)
                {
                    item.GetComponent<Shape>().GetSize(circleSize[i]);
                    break;
                }

            }

        }

        foreach (var item in cubes)
        {

            if (item.GetComponent<Shape>().Size == 0)
            {
                item.GetComponent<Shape>().GetSize(Random.Range(20, (int)(maxSize * 100)));

            }
        }
    }

    private void GetShapePosition()
    {
        mapSpawn = new GameObject[circles.Count + cubes.Count + triangles.Count];
        mapSpawnPosition = new Vector2[circles.Count + cubes.Count + triangles.Count];

        float maxSizeX = 0f;
        float maxSizeY = 0f;
        for (int i = 0; i < mapSpawnPosition.Length; i++)
        {
            if(-5.3f + maxSizeX  >= 7.3f)
            {
                if (1.5f - maxSizeY  >= -3.5f)
                {
                    maxSizeY += maxSize + distance;
                    maxSizeX = 0;
                    mapSpawnPosition[i] = new Vector2(-5.3f + maxSizeX, 1.5f - maxSizeY);
                    maxSizeX += maxSize + distance;
                }
            }
            else
            {
                mapSpawnPosition[i] = new Vector2(-5.3f + maxSizeX , 1.5f - maxSizeY);
                maxSizeX += maxSize + distance;
            }

            
        }

        foreach (var circle in circles)
        {
            while (circle != null)
            {
                int random = Random.Range(0, mapSpawn.Length);
                if (mapSpawn[random] == null)
                {
                    mapSpawn[random] = circle;
                    break;
                }
            }
        }
        foreach (var cube in cubes)
        {
            while (cube != null)
            {
                int random = Random.Range(0, mapSpawn.Length);
                if (mapSpawn[random] == null)
                {
                    mapSpawn[random] = cube;
                    break;
                }
            }
        }
        foreach (var triangle in triangles)
        {
            while (triangle != null)
            {
                int random = Random.Range(0, mapSpawn.Length);
                if (mapSpawn[random] == null)
                {
                    mapSpawn[random] = triangle;
                    break;
                }
            }
        }

        for (int i = 0; i < mapSpawn.Length; i++)
        {
            mapSpawn[i].transform.position = mapSpawnPosition[i];
        }

    }
    
    private bool CheckCircelInScene()
    {
        bool notActive = false;
        if(circles.Count > 0)
        {
            foreach (var circle in circles)
            {
                if (circle.activeSelf)
                {
                    notActive = false;
                    break;
                }
                else
                {
                    notActive = true;
                }
            }
        }
       

        return notActive;
    }

    private void ActiveShapesInScene()
    {
        foreach (var circle in circles)
        {
            circle.SetActive(true);
        }

        foreach (var cube in cubes)
        {
            cube.SetActive(true);
        }
        foreach (var triangles in triangles)
        {
            triangles.SetActive(true);
        }

    }

    private void ResetShapesSize()
    {
        foreach (var circle in circles)
        {
            circle.GetComponent<Shape>().Size = 0;
        }

        foreach (var cube in cubes)
        {
            cube.GetComponent<Shape>().Size = 0;
        }
    }

    public void RestartLevel()
    {
        ActiveShapesInScene();
        ResetShapesSize();
        GetSize();
        GetShapePosition();
    }
}
