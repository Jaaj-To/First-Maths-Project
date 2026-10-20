using UnityEngine;

public class NewClone : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform mirror;
    
    void Update()
    {
        if (mirror == null || target == null) return;
        
        Vector3 lPlayerOffset = target.position - mirror.position;

        float[,] lMirrorBase = new float[3, 3];

        lMirrorBase[0, 0] = mirror.right.x;
        lMirrorBase[0, 1] = mirror.right.y;
        lMirrorBase[0, 2] = mirror.right.z;
        
        lMirrorBase[1, 0] = mirror.up.x;
        lMirrorBase[1, 1] = mirror.up.y;
        lMirrorBase[1, 2] = mirror.up.z;
        
        lMirrorBase[2, 0] = mirror.forward.x;
        lMirrorBase[2, 1] = mirror.forward.y;
        lMirrorBase[2, 2] = mirror.forward.z;

        Vector3 lPosMirrorBased = new Vector3
        ((lMirrorBase[0, 0] * lPlayerOffset.x) + (lMirrorBase[0, 1] * lPlayerOffset.y) + (lMirrorBase[0, 2] * lPlayerOffset.z),
            (lMirrorBase[1, 0] * lPlayerOffset.x) + (lMirrorBase[1, 1] * lPlayerOffset.y) + (lMirrorBase[1, 2] * lPlayerOffset.z),
            (lMirrorBase[0, 0] * lPlayerOffset.x) + (lMirrorBase[0, 1] * lPlayerOffset.y) + (lMirrorBase[0, 2] * lPlayerOffset.z));

        float[,] lFlipY = new float[3, 3];
        lFlipY[0, 0] = 1f;
        lFlipY[1, 1] = 1f;
        lFlipY[2, 2] = -1f;
        
        
        Vector3 lFlippedInZMirrorBased = new Vector3
        ((lFlipY[0, 0] * lPosMirrorBased.x) + (lFlipY[0, 1] * lPosMirrorBased.y) + (lFlipY[0, 2] * lPosMirrorBased.z),
            (lFlipY[1, 0] * lPosMirrorBased.x) + (lFlipY[1, 1] * lPosMirrorBased.y) + (lFlipY[1, 2] * lPosMirrorBased.z),
            (lFlipY[0, 0] * lPosMirrorBased.x) + (lFlipY[0, 1] * lPosMirrorBased.y) + (lFlipY[0, 2] * lPosMirrorBased.z));;
        
        Matrix4x4 lMirrorToWorld = Matrix4x4.identity;
        lMirrorToWorld.SetColumn(0, mirror.right);
        lMirrorToWorld.SetColumn(1, mirror.up);
        lMirrorToWorld.SetColumn(2, mirror.forward);
        
        Vector3 lMirroredOffset = lMirrorToWorld.MultiplyVector(lFlippedInZMirrorBased);
        
        transform.position = mirror.position + lMirroredOffset;
    }
}