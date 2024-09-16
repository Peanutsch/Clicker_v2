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

        public int NewPointsQuota(TextBox textBoxQuota) // Voeg de TextBox toe als parameter
        {
            int currentQuota;

            if (!isStartQuota)
            {
                // Verhoog startQuota met 10%
                double increasedQuota = startQuota * 1.10;

                // Rond naar boven af
                currentQuota = (int)Math.Ceiling(increasedQuota);
            }
            else
            {
                currentQuota = startQuota;
            }

            // Update de quota in de TextBox
            DisplayQuotaPoints(textBoxQuota, currentQuota); // Geef de TextBox en currentQuota door

            return currentQuota; // Geef de huidige quota terug
        }

        public void DisplayQuotaPoints(TextBox textBoxQuota, int currentQuota) // Voeg currentQuota toe als parameter
        {
            // Display quota in TextBox
            textBoxQuota.Text = $"QUOTA:\n{currentQuota}";
        }

        public static void InitCircleQuota()
        {
            // Logica voor het initialiseren van cirkelquota
        }


        #endregion
    }

}
