using System.Collections.Generic;
using UnityEngine;

namespace JuhaKurisu.Unixels.V4
{
    internal class UnixelMono : MonoBehaviour
    {
        public Material material;
        public int height;
        public int width;

        private Mesh mesh;

        private void Start()
        {
            mesh = new();
        }

        private void Update()
        {
            GenerateMesh();
            Graphics.DrawMesh(mesh, transform.position, transform.rotation, material, 0);
        }

        private void GenerateMesh()
        {
            float height = this.height / (float)this.width;
            float width = 1;

            float m = width / height > Camera.main.aspect
                ? Camera.main.orthographicSize * Camera.main.aspect
                : Camera.main.orthographicSize / height;

            width *= m;
            height *= m;

            mesh.Clear();
            mesh.SetVertices(new Vector3[]
            {
                new Vector3(-width,-height),
                new Vector3(-width,height),
                new Vector3(width,height),
                new Vector3(width,-height),
            });
            mesh.SetTriangles(new int[]
            {
                0,1,2,
                0,2,3,
            }, 0);
            mesh.SetUVs(0, new List<Vector2>()
            {
                new Vector2(0,0),
                new Vector2(0,1),
                new Vector2(1,1),
                new Vector2(1,0),
            });
        }

        public void SetTexture(Texture2D texture)
        {
            material.mainTexture = texture;
        }
    }
}