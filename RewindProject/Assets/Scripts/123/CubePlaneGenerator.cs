using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlaneGenerator : MonoBehaviour
{
    public Material MyMaterial;

    public float HieghtMultiplier = 1f;

    public int xSize = 10;
    public int zSize = 10;

    public GameObject [] CubesPlane;

    public float scale = 20f;
    public float offsetX = 100f;
    public float offsetZ = 100f;
    // Start is called before the first frame update
    void Start()
    {
        CubesPlane = new GameObject[xSize*zSize]; //creating plane of cubes with choosen size

        float[,] h = GenerateHeights();

        int i = 0;
        for (int x = 0; x < xSize; x++)
        {
            for (int z = 0; z < zSize; z++)
            {
                Debug.Log(h[x, z]);
                CubesPlane[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                CubesPlane[i].transform.parent = this.transform;
                CubesPlane[i].GetComponent<Renderer>().material = MyMaterial;
                CubesPlane[i].transform.position = new Vector3(Extrudeheight(h, x, z), this.transform.position.z + z, this.transform.position.x + x);//Vertical
                //CubesPlane[i].transform.position = new Vector3(this.transform.position.x + x, Extrudeheight(h,x,z), this.transform.position.z + z);//horizontal
                //CubesPlane[i].transform.position = new Vector3(this.transform.position.x + x, this.transform.position.z + z, Extrudeheight(h, x, z));
                i++;
            }
        }
    }
     
    void Update()
    {
        offsetX += Time.deltaTime;// make it move baybe
        offsetZ += Time.deltaTime;


        float[,] h = GenerateHeights();

        int i = 0;
        for (int x = 0; x < xSize; x++)
        {
            for (int z = 0; z < zSize; z++)
            {
                CubesPlane[i].transform.position = new Vector3(Extrudeheight(h, x, z), this.transform.position.z + z, this.transform.position.x + x);//Vertical
                //CubesPlane[i].transform.position = new Vector3(this.transform.position.x + x, Extrudeheight(h, x, z), this.transform.position.z + z);//horizontal
                //CubesPlane[i].transform.position = new Vector3(this.transform.position.x + x, this.transform.position.y + z, this.transform.position.z + Extrudeheight(h, x, z));
                i++;
            }
        }
    }

    float Extrudeheight(float[,] h, int x, int z)
    {
        float height = this.transform.position.x + h[x,z] * HieghtMultiplier;
        //float height = h[x, z] * HieghtMultiplier; // original
        return height;
    }
    float[,] GenerateHeights()
    {
        float[,] heights = new float[xSize,zSize];
        for (int x = 0; x < xSize; x++)
        {
            for (int z = 0; z < zSize; z++)
            {
                heights[x, z] = CalculateHeights(x,z);
            }
        }

        return heights;
    }

    float CalculateHeights(int x, int z)
    {
        float xCoord = (float)x / xSize * scale + offsetX;
        float zCoord = (float)z / zSize * scale + offsetZ;
        Debug.Log(xCoord);
        return Mathf.PerlinNoise(xCoord, zCoord);
    }

}
