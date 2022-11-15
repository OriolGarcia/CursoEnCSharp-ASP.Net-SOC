using System;
using System.Collections.Generic;
using System.Text;

namespace Utilidades
{
    internal static class Utils
    {

        public static float GetPromedio(int num1,int num2)
        {
            return (float)(num1 + num2) / 2;
        }
        public static int GetMayor(int num1, int num2)
        {
            return num1>num2? num1:num2;
        }

        public static double GetHipotenusa(int num1, int num2)
        {
            return Math.Sqrt((double)num1 * num1 + (double)num2 * num2);
        }
    }
}
