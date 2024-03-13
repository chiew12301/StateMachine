using System.Collections;
using UnityEngine;

namespace CORE
{
    public class StaminaSystem : MonoBehaviour
    {
        [SerializeField] private float m_maxStamina = 100.0f;
        [SerializeField] private float m_recoveringSpeed = 1.0f;

        private float m_elapsedStamina = 100.0f;

        private bool m_isOnCD = false;

        private Coroutine m_coolDownCO = null;
        private WaitForSeconds m_cdTime = new WaitForSeconds(2.0f);

        //===========================================

        //===========================================

        public bool IsStaminaFull() => this.m_elapsedStamina >= this.m_maxStamina;

        public bool GetIsOutOfStamina(float staminaCost)
        {
            return this.m_elapsedStamina - staminaCost < 0;
        }

        public void AddStamina()
        {
            if (this.m_isOnCD) return;

            this.m_elapsedStamina = Mathf.Clamp(this.m_elapsedStamina + this.m_recoveringSpeed, 0, this.m_maxStamina);
            this.StartCountDown();
        }

        public void DeductStamina(float staminaCost)
        {
            if (this.m_isOnCD) return;

            this.m_elapsedStamina = Mathf.Clamp(this.m_elapsedStamina - staminaCost, 0, this.m_maxStamina);
            this.StartCountDown();
        }

        private void StartCountDown()
        {
            if(this.m_coolDownCO != null)
            {
                this.StopCoroutine(this.m_coolDownCO);
                this.m_coolDownCO = null;
            }

            this.m_coolDownCO = this.StartCoroutine(this.StartCoolDownCO());
        }

        private IEnumerator StartCoolDownCO()
        {
            this.m_isOnCD = true;

            yield return this.m_cdTime;

            this.m_isOnCD = false;
        }

        //===========================================
    }
}
