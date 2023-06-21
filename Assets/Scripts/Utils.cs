using UnityEngine;


namespace Atrabile {
public static class Utils {

    /*#########*/
    /* B Y T E */
    /*#########*/

        public static float Normalized(this byte f) =>
            (float)f * 0.00390625f;

    /*#################*/
    /* V E C T O R   2 */
    /*#################*/

        public static Vector2 Pow(this Vector2 f, float p) =>
            new Vector2(Mathf.Pow(f.x, p), Mathf.Pow(f.y, p));

        public static Vector2 Abs(this Vector2 f) =>
            new Vector2(Mathf.Abs(f.x), Mathf.Abs(f.y));

        public static Vector2 Dot(this Vector2 v, Vector2 w) =>
            new Vector2(v.x * w.x, v.y * w.y);

        public static Vector2 Sign(this Vector2 f) =>
            new Vector2(Mathf.Sign(f.x), Mathf.Sign(f.y));

        public static Vector2 XConstraint(this Vector2 f) =>
            new Vector2(f.x, 0f);

        public static Vector2 YConstraint(this Vector2 f) =>
            new Vector2(0f, f.y);

        public static Vector3 ToFlat3D(this Vector2 f) =>
            new Vector3(f.x, 0f, f.y);

    
    /*#################*/
    /* V E C T O R   3 */
    /*#################*/

        public static Vector3 Pow(this Vector3 f, float p) =>
            new Vector3(Mathf.Pow(f.x, p), Mathf.Pow(f.y, p), Mathf.Pow(f.z, p));

        public static Vector3 Abs(this Vector3 f) =>
            new Vector3(Mathf.Abs(f.x), Mathf.Abs(f.y), Mathf.Abs(f.z));

        public static Vector3 Dot(this Vector3 v, Vector3 w) =>
            new Vector3(v.x * w.x, v.y * w.y, v.z * w.z);

        public static Vector3 Sign(this Vector3 f) =>
            new Vector3(Mathf.Sign(f.x), Mathf.Sign(f.y), Mathf.Sign(f.z));

        public static Vector3 XConstraint(this Vector3 f) =>
            new Vector3(f.x, 0f, 0f);

        public static Vector3 YConstraint(this Vector3 f) =>
            new Vector3(0f, f.y, 0f);

        public static Vector3 ZConstraint(this Vector3 f) =>
            new Vector3(0f, 0f, f.z);

        public static Vector3 XYConstraint(this Vector3 f) =>
            new Vector3(f.x, f.y, 0f);

        public static Vector3 XZConstraint(this Vector3 f) =>
            new Vector3(f.x, 0f, f.z);
            
        public static Vector3 YZConstraint(this Vector3 f) =>
            new Vector3(0f, f.y, f.z);

        public static Vector3 AnyOr(this Vector3 f, Vector3 or) {
            if (f == Vector3.zero) return or;
            else                   return f;
        } // Vector3 ..
}} // namespace ..
