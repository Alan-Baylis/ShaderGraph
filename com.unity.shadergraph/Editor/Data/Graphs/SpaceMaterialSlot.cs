using System;
using UnityEditor.Graphing;
using UnityEngine;

namespace UnityEditor.ShaderGraph
{
    [Serializable]
    public abstract class SpaceMaterialSlot : Vector3MaterialSlot
    {
        [SerializeField]
        private CoordinateSpace m_Space = CoordinateSpace.World;

        public CoordinateSpace space
        {
            get { return m_Space; }
            set { m_Space = value; }
        }

        protected SpaceMaterialSlot()
        {}

        protected SpaceMaterialSlot(int slotId, string displayName, string shaderOutputName, CoordinateSpace space,
                                    ShaderStage shaderStage = ShaderStage.Dynamic, bool hidden = false)
            : base(slotId, displayName, shaderOutputName, SlotType.Input, Vector3.zero, shaderStage, hidden: hidden)
        {
            this.space = space;
        }

        public override void CopyValuesFrom(MaterialSlot foundSlot)
        {
            var slot = foundSlot as NormalMaterialSlot;
            if (slot != null)
                space = slot.space;
        }
    }
}
