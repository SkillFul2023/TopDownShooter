using UnityEngine;

namespace TopDownShooter.Interface
{
    public interface IFindingTarget
    {
        public void FindTarget(Vector2 unitPosition, float radius);
        public void TrackTarget(Vector2 unitPosition, float radius);
    }
}
