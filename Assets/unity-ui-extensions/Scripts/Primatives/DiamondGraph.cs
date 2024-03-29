/// Credit koohddang
/// Sourced from - http://forum.unity3d.com/threads/onfillvbo-to-onpopulatemesh-help.353977/#post-2299311

using System.Collections.Generic;
using System;

namespace UnityEngine.UI.Extensions
{
    [ExecuteInEditMode]
    [AddComponentMenu("UI/Extensions/Primitives/Diamond Graph")]
    public class DiamondGraph : Graphic
    {
        public float a = 1;
        public float b = 1;
        public float c = 1;
        public float d = 1;

        protected override void OnPopulateMesh(Mesh m)
        {
            float wHalf = rectTransform.rect.width / 2;
            //float hHalf = rectTransform.rect.height / 2;
            a = Math.Min(1, Math.Max(0, a));
            b = Math.Min(1, Math.Max(0, b));
            c = Math.Min(1, Math.Max(0, c));
            d = Math.Min(1, Math.Max(0, d));

            Color32 color32 = color;
            using (var vh = new VertexHelper())
            {
                vh.AddVert(new Vector3(-wHalf * a, 0), color32, new Vector2(0f, 0f));
                vh.AddVert(new Vector3(0, wHalf * b), color32, new Vector2(0f, 1f));
                vh.AddVert(new Vector3(wHalf * c, 0), color32, new Vector2(1f, 1f));
                vh.AddVert(new Vector3(0, -wHalf * d), color32, new Vector2(1f, 0f));

                vh.AddTriangle(0, 1, 2);
                vh.AddTriangle(2, 3, 0);
                vh.FillMesh(m);
            }
        }
    }
}