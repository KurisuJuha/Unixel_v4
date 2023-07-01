using System.Collections.Generic;
using UnityEngine;

namespace JuhaKurisu.Unixels.V4
{
    public class UnixelMono : MonoBehaviour
    {
        public Material material;
        public Texture2D texture;
        public Unixel unixel { get; private set; }

        private Mesh mesh;

        private void Start()
        {
            mesh = new();
            SetTexture();
        }

        private void LateUpdate()
        {
            GenerateMesh();
            SetColors();
            Graphics.DrawMesh(mesh, transform.position, transform.rotation, material, 0);
        }

        private void GenerateMesh()
        {
            float height = unixel.height / (float)unixel.width;
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

        private void SetTexture()
        {
            texture = new(unixel.width, unixel.height);
            texture.filterMode = FilterMode.Point;
            material.mainTexture = texture;
        }

        private void SetColors()
        {
            texture.SetPixels32(unixel.colors);
            texture.Apply();
            unixel.colors = texture.GetPixels32();
        }

        /// <summary>
        /// UnixelMonoのインスタンスを作成します。
        /// </summary>
        /// <param name="unixel">UnixelMonoの描画に使用するUnixelクラス</param>
        /// <returns>作成したインスタンス</returns>
        public static UnixelMono CreateUnixelDisplay(Unixel unixel)
        {
            UnixelMono unixelMono = new GameObject("[Unixel]").AddComponent<UnixelMono>();
            unixelMono.transform.position = new();
            unixelMono.transform.rotation = Quaternion.identity;
            unixelMono.material = new(Shader.Find("Sprites/Default"));
            unixelMono.unixel = unixel;

            return unixelMono;
        }
    }
}