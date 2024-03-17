using CORE;
using UnityEngine;

namespace UNIT
{
    public class ADog : AnUnit
    {
        private bool m_hasStaminaSystem = true;
        private StaminaSystem m_staminaSystem = null;

        //==========================================================

        private void Start()
        {
            this.m_hasStaminaSystem = this.TryGetComponent<StaminaSystem>(out this.m_staminaSystem);
        }


        //==========================================================

        public bool GetIsStaminaFull()
        {
            if (!this.m_staminaSystem) return true;

            return this.m_staminaSystem.IsStaminaFull();
        }

        public bool GetIsOutOfStamina(float staminaCost)
        {
            if (!this.m_staminaSystem) return false;

            return this.m_staminaSystem.GetIsOutOfStamina(staminaCost);
        }

        public void AddStamina()
        {
            if (!this.m_hasStaminaSystem) return;

            this.m_staminaSystem.AddStamina();
        }

        public void DeductStamina(float cost)
        {
            if (!this.m_hasStaminaSystem) return;

            this.m_staminaSystem.DeductStamina(cost);
        }

        //==========================================================
    }
}