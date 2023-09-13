using System.Collections;
using UnityEngine;

namespace MY.Utils
{
    public class TransformLink : MonoBehaviour
    {
        [SerializeField]
        private Transform Linker;

        [SerializeField]
        private bool linkPosition;
        [SerializeField]
        private bool usePositionOffset;
        [SerializeField]
        private Vector3Bool positionConstraints;
        private Vector3 positionOffset;

        [SerializeField]
        private bool linkRotation;
        [SerializeField]
        private bool useRotationOffset;
        [SerializeField]
        private Vector3Bool rotationConstraints;
        private Vector3 rotationOffset;

        [SerializeField]
        private bool linkScale;
        [SerializeField]
        private bool useScaleOffset;
        [SerializeField]
        private Vector3Bool scaleConstraints;
        private Vector3 scaleOffset;

        private void Awake()
        {
            if (usePositionOffset) positionOffset = this.transform.position - Linker.position;

            if (useRotationOffset) rotationOffset = this.transform.rotation.eulerAngles - Linker.rotation.eulerAngles;

            if (useScaleOffset) scaleOffset =  this.transform.localScale - Linker.localScale;
        }

        private void Update()
        {
            if (linkPosition)
                this.transform.position = ApplyConstraints(this.transform.position, Linker.position + positionOffset, positionConstraints);

            if (linkRotation)
                this.transform.SetRotation(ApplyConstraints(this.transform.rotation.eulerAngles, Linker.rotation.eulerAngles + rotationOffset, rotationConstraints));

            if (linkScale)
                this.transform.localScale = ApplyConstraints(this.transform.localScale, Linker.localScale + scaleOffset, scaleConstraints);
        }

        private Vector3 ApplyConstraints(Vector3 original, Vector3 target, Vector3Bool constraints)
        {
            return new Vector3(
                constraints.x ? original.x : target.x,
                constraints.y ? original.y : target.y,
                constraints.z ? original.z : target.z);
        }
    }
}