using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalParams
{
    public static float timer { get; set; }
    public static bool isObjectsFound { get; set; }
    public static int count { get; set; }

    // Declare and initialize a static list of dictionaries
    public static Dictionary<string, List<(Vector3 position, Vector3 rotation)>> objects = new Dictionary<string, List<(Vector3 position, Vector3 rotation)>>
    {
            { "paint_sheep", new List<(Vector3 position, Vector3 rotation)>
                {
                    (new Vector3(-2.368f, -0.07f, 16.5f), new Vector3(270f, 180f, 0f)),
                    (new Vector3(0.581f, -0.07f, 13.485f), new Vector3(270f, 180f, 0f)),
                    (new Vector3(4.476f,-0.07f,5.05f), new Vector3(270f, 180f, 90f)),
                    (new Vector3(1.66799998f,-0.0700000003f,7.50600004f), new Vector3(270,0,0))
                }
            },
            { "dollars", new List<(Vector3 position, Vector3 rotation)>
                {
                    (new Vector3(-0.144301012f,0.556999981f,-0.777999997f), new Vector3(90,0,0)),
                    (new Vector3(1.66999996f,0.47299999f,2.75f), new Vector3(90,0,0)),
                    (new Vector3(-6.97399998f,0.786000013f,5.66699982f), new Vector3(90,0,0))
                }
            },
            { "smartphone", new List<(Vector3 position, Vector3 rotation)>
                {
                    (new Vector3(-7.14479065f,0.8629601f,8.98799992f), new Vector3(2.50447806e-06f,0,0)),
                    (new Vector3(1.46179998f,0.248999998f,-2.15499997f), new Vector3(2.50447806e-06f,0,0))
                }
            }
    };

}
