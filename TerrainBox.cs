using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[ExecuteInEditMode]
public class TerrainBox : MonoBehaviour
{
    public float xsize = 1;
    public float ysize = 1;
    public float zsize = 1;

    public GameObject Left;
    public GameObject Right;
    public GameObject Front;
    public GameObject Back;

    public GameObject Bottom;

    public bool AutoUpdate;

    void Update()
    {
        if (AutoUpdate) { UpdateTransform(); }
    }

    [Button("Update")]
    public void UpdateTransform()
    {
        //Scale
        var s = Bottom.transform.localScale;
        Bottom.transform.localScale = new Vector3(xsize, s.y, ysize);
        Left.transform.localScale = new Vector3(Left.transform.localScale.x, zsize, ysize);
        Right.transform.localScale = new Vector3(Right.transform.localScale.x, zsize, ysize);
        Front.transform.localScale = new Vector3(xsize, zsize, Front.transform.localScale.z);
        Back.transform.localScale = new Vector3(xsize, zsize, Back.transform.localScale.z);

        s = Left.transform.localScale;
        Bottom.transform.localScale = new Vector3(xsize, 1, ysize);

        //Pos
        var oriPos = Bottom.transform.position;
        Left.transform.position = oriPos + new Vector3(xsize / 2, zsize/2, 0);
        Right.transform.position = oriPos + new Vector3(-xsize / 2, zsize / 2, 0);
        Front.transform.position = oriPos + new Vector3(0, zsize / 2, ysize / 2);
        Back.transform.position = oriPos + new Vector3(0, zsize / 2, -ysize / 2);

    }
}
