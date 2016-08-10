using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Business.Models
{
    public class ResumoValidacao
    {
        public static int CountEmpty = 0;
        public static int CountInvalid = 0;
        public static int CountValid = 0;
        public static int CountTotal
        {
            set { }
            get {
               return CountEmpty + CountInvalid + CountValid;
            }
        }

        public static double CalcularPorcentagem(int valor, int total)
        {
            try
            {
                return Math.Round((double)((valor * 100) / total));
            }
            catch { return 0; }
        }
    }
}
