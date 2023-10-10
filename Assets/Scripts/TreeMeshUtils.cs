using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreeMeshUtils 
{

    public static Mesh CreateCylinder(Vector3 start, Vector3 end, float radius, int detail)
    {
        Mesh mesh = new Mesh();

        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();

        Vector3 axis = (end - start).normalized;

        ///TODO: experiment with fixed vector cross
        ///products to generate smooth joins
        Vector3 cross = NonZeroCrossProduct(axis);

        Vector3 u = Vector3.Cross(axis, cross).normalized;
        Vector3 v = Vector3.Cross(axis, u).normalized;

        float theta = 0.0f;

        for (int i = 0; i < detail; i++) 
        {
            theta = ((i * 1.0f) / detail) * 2.0f * Mathf.PI;
            Vector3 p = radius * ((u * Mathf.Cos(theta)) + (v * Mathf.Sin(theta)));
            Vector3 vertex = p + start;
            vertices.Add(vertex);
        }

        theta = 0.0f;

        for (int i = 0; i < detail; i++) 
        {
            theta = ((i * 1.0f) / detail) * 2.0f * Mathf.PI;
            Vector3 p = radius * ((u * Mathf.Cos(theta)) + (v * Mathf.Sin(theta)));
            Vector3 vertex = p + end;
            vertices.Add(vertex);
        }
        
        for (int i = 0; i < detail; i++) 
        {
            int i1 = (i + 1) % detail;
            int i2 = i1 + detail;
            int i4 = i;
            int i3 = i4 + detail;

            AddQuad(triangles, i1, i2, i3, i4);
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();

        return mesh;
    }
    
    public static void RenderTree(TreeGrowth growth, TreeInfo info, GameObject parent)
    {
        int i = 0;
        foreach (TreeInternode internode in growth.Internodes)
        {
            Mesh m = CreateCylinder(internode.Start.Position, internode.End.Position, internode.Size, info.Detail);
            GameObject go = new GameObject("Branch " + i);
            go.AddComponent<MeshFilter>();
            go.AddComponent<MeshRenderer>();
            go.GetComponent<MeshFilter>().mesh = m;
            Renderer rend = go.GetComponent<Renderer>();
            rend.material.color = info.Color;
            go.transform.parent = parent.transform;
            i++;
        }
    }

    public static void DebugTree(TreeGrowth growth)
    {
        GameObject sphereParent = new GameObject("SphereParent");
        
        foreach (TreeNode node in growth.Nodes)
        {
            GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            temp.transform.position = node.Position;
            temp.transform.localScale = Vector3.one * 0.1f;
            temp.transform.parent = sphereParent.transform;
        }

    }

    public static void CreateCRBranch()
    {
        return;
    }

    public static void AddTriangle(List<int> tris, int i1, int i2, int i3) 
    {
        tris.Add(i1);
        tris.Add(i2);
        tris.Add(i3);
    }

    public static void AddQuad(List<int> tris, int i1, int i2, int i3, int i4) 
    {
        AddTriangle(tris, i1, i2, i3);
        AddTriangle(tris, i1, i3, i4);
    }

    public static Vector3 MixTangent(Vector3 vector, Vector3 other)
    {
        float k = 0.10f;
        Vector3 result = (vector.normalized + k * other.normalized).normalized;
        return result;
    }

    ///TODO: rewrite to generate predictable orthogonal frames. 
    public static Vector3 NonZeroCrossProduct(Vector3 vector) 
    {
        Vector3 cross = new Vector3(Random.Range(0.0f, 1.0f), 
                                    Random.Range(0.0f, 1.0f),
                                    Random.Range(0.0f, 1.0f));
        
        while (Vector3.Cross(vector, cross) == Vector3.zero) {
            cross = new Vector3(Random.Range(0.0f, 1.0f), 
                                Random.Range(0.0f, 1.0f),
                                Random.Range(0.0f, 1.0f));
        }

        return cross.normalized;
    }
    
    public static Color GenerateRandomColor()
    {
        return new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
    }

}