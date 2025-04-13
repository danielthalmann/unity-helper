using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class CustomMesh : MonoBehaviour
{
    [Range(0, 100f)]
    public float branch;

    private Vector3[] vectrices = new Vector3[8];
    private Vector2[] uv = new Vector2[8];
    private Vector2 c;
    private int[] triangles = new int[21];

    private Mesh mesh;

    private MeshRenderer mRender;
    private MeshFilter mFilter;


    private void Awake()
    {
        mRender = GetComponent<MeshRenderer>();
        if (mRender == null)
        {
            mRender = gameObject.AddComponent<MeshRenderer>();
        }

        mFilter = GetComponent<MeshFilter>();
        if (mFilter == null)
        {
            mFilter = gameObject.AddComponent<MeshFilter>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        generateMesh();
        mesh = new Mesh();
        mesh.name = "mesh";

        mFilter.mesh = mesh;

        mesh.vertices = vectrices;
        mesh.uv = uv;
        mesh.triangles = triangles;

    }

    public void Create()
    {
        Start();
    }
    

    void generateMesh()
    {
        c = new Vector2(-.5f, -.5f);

        vectrices[0] = new Vector3(0 + c.x, 0 + c.y, 0);
        vectrices[1] = new Vector3(0 + c.x, 1 + c.y, 0);
        vectrices[2] = new Vector3(1 + c.x, 1 + c.y, 0);
        vectrices[3] = new Vector3(1 + c.x, 0 + c.y, 0);

        vectrices[4] = new Vector3( -1 + c.x, .5f + c.y, 0);
        vectrices[5] = new Vector3(.5f + c.x,   2 + c.y, 0);
        vectrices[6] = new Vector3(  2 + c.x, .5f + c.y, 0);
        vectrices[7] = new Vector3(.5f + c.x,  -1 + c.y, 0);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        triangles[6] = 0;
        triangles[7] = 4;
        triangles[8] = 1;

        triangles[9] = 4;
        triangles[10] = 1;
        triangles[11] = 0;

        triangles[12] = 1;
        triangles[13] = 5;
        triangles[14] = 2;

        triangles[15] = 2;
        triangles[16] = 6;
        triangles[17] = 3;

        triangles[18] = 3;
        triangles[19] = 7;
        triangles[20] = 0;


        uv[0] = new Vector2(.25f, .25f);
        uv[1] = new Vector2(.75f, .25f);
        uv[2] = new Vector2(.75f, .75f);
        uv[3] = new Vector2(.25f, .75f);
        uv[4] = new Vector2(0, .5f);
        uv[5] = new Vector2(.5f, 1);
        uv[6] = new Vector2(1, .5f);
        uv[7] = new Vector2(.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {

        vectrices[4] = new Vector3(-1 + c.x - branch, .5f + c.y, 0);
        vectrices[5] = new Vector3(.5f + c.x, 2 + c.y + branch, 0);
        vectrices[6] = new Vector3(2 + c.x + branch, .5f + c.y, 0);
        vectrices[7] = new Vector3(.5f + c.x, -1 + c.y - branch, 0);
        mesh.vertices = vectrices;


    }
}
