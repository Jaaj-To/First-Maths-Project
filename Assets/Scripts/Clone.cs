using UnityEngine;

public class Clone : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform mirror;
    
    void Update()
    {
        if (mirror == null || target == null) return;
        
        Vector3 lPlayerOffsetFromMirror = target.position - mirror.position;
        
        Matrix4x4 lWorldToMirror = Matrix4x4.identity;
        lWorldToMirror.SetRow(0, mirror.right);
        lWorldToMirror.SetRow(1, mirror.up);
        lWorldToMirror.SetRow(2, mirror.forward);
        
        Vector3 lPosMirrorBased = lWorldToMirror.MultiplyVector(lPlayerOffsetFromMirror);

        Matrix4x4 lFlipY = Matrix4x4.identity;
        lFlipY.m22 = -1f;
        Vector3 lFlippedInZMirrorBased = lFlipY.MultiplyVector(lPosMirrorBased);
        
        Matrix4x4 lMirrorToWorld = Matrix4x4.identity;
        lMirrorToWorld.SetColumn(0, mirror.right);
        lMirrorToWorld.SetColumn(1, mirror.up);
        lMirrorToWorld.SetColumn(2, mirror.forward);
        
        Vector3 lMirroredOffset = lMirrorToWorld.MultiplyVector(lFlippedInZMirrorBased);
        
        transform.position = mirror.position + lMirroredOffset;
    }
}
