using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker_v2
{
    internal class InitQuota
    {
        int CircleSize = 50;
        int startQuota = 100;
        int newQuota;

        bool isStartQuota;

        Color CircleColor = RandomizersTimers.RandomizerColor();

        public InitQuota(bool isStartQuota)
            {
                this.isStartQuota = isStartQuota;
            }



        #region QUOTA

        public int NewPointsQuota()
        {
            if (!isStartQuota)
            {
                // Verhoog de startQuota met 10%
                double increasedQuota = startQuota * 1.10;

                // Rond naar boven af
                return (int)Math.Ceiling(increasedQuota);
            }
            else
            {
                return startQuota;
            }
        }

        public static void InitCircleQuota()
        {
            
        }

        public void DisplayQuotaPoints(TextBox textBoxQuota)
        {
            int currentQuota = NewPointsQuota();

            textBoxQuota.Text = $"Quota:\n{currentQuota}";
        }

        #endregion
    }

}
