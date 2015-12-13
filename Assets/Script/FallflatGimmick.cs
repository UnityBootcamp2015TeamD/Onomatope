using UnityEngine;

public class FallflatGimmick : MonoBehaviour
{
    /// <summary>
    /// The effort point.
    /// </summary>
    /// <remarks>
    /// Relative position from the center position of rigidbody.
    /// </remarks>
    public Vector3 forcePosition = new Vector3(0, 0, 0);
    public Vector3 forceVector = new Vector3(1000, 0, 0);

    public void ExecuteFallflat()
    {
        var rigidbody = GetComponent<Rigidbody>();
        var worldCoordinate = forcePosition + rigidbody.position;

        rigidbody.AddForceAtPosition(forceVector, worldCoordinate);

        GameController.Instance.RaisePopup(1, worldCoordinate);
    }
}
