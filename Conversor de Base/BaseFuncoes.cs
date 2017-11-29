using System;

namespace Conversor_de_Base
{
    public class BaseFuncoes
    {
        /// <summary>
        /// Reverte a string.
        /// </summary>
        /// <param name="s">String a ser revertida.</param>
        private string ReverterString(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        /// <summary>
        /// Checa se o algarismo pertecente a base.
        /// </summary>
        /// <param name="Algarismo">Algarismo a ser testado.</param>
        /// <param name="ComprimentoAlgarismo">Comprimento do algarismo.</param>
        /// <param name="Base">Base relacionada ao algarismo.</param>
        private bool ChecarBaseAlgarismo(string Algarismo, int Base)
        {
            int Numero;
            for (int i = 0; i < Algarismo.Length; i++)
            {
                if (Algarismo[i] >= 48 && Algarismo[i] <= 57) Numero = int.Parse(Algarismo[i].ToString());
                else if (Algarismo[i] >= 65 && Algarismo[i] <= 86) Numero = Algarismo[i] - 55;
                else if (Algarismo[i] >= 97 && Algarismo[i] <= 118) Numero = Algarismo[i] - 87;
                else return false;

                if (Numero >= Base) return false;
            }
            return true;
        }

        /// <summary>
        /// Converte o algarismo da posição em um número inteiro.
        /// </summary>
        /// <param name="Algarismo">Algarismo a ser convertido.</param>
        private int AlgarismoParaNumero(char Algarismo)
        {
            int Numero;
            if (Algarismo >= 65 && Algarismo <= 86) Numero = Algarismo - 55;
            else if (Algarismo >= 97 && Algarismo <= 118) Numero = Algarismo - 87;
            else Numero = int.Parse(Algarismo.ToString());
            return Numero;
        }

        /// <summary>
        /// Converte um número inteiro em algarismo.
        /// </summary>
        /// <param name="Numero">Número inteiro a ser convertido.</param>
        private char NumeroParaAlgarismo(int Numero)
        {
            char Algarismo;
            if (Numero >= 10 && Numero <= 31) Algarismo = (char)(Numero + 55);
            else Algarismo = char.Parse(Numero.ToString());
            return Algarismo;
        }

        /// <summary>
        /// Converte o algarismo para decimal.
        /// </summary>
        /// <param name="Algarismo">Algarismo a ser convertido.</param>
        /// <param name="Base">Base que o algarismo está.</param>
        private string ConverterAlgarismoParaDecimal(string Algarismo, int Base)
        {
            if (Algarismo.Length <= 0) throw new Exception("Digite algum algarismo para ser convertido.");
            if (Algarismo.Contains(".") || Algarismo.Contains(",")) throw new Exception("Use apenas algarismos inteiros.");
            if (!ChecarBaseAlgarismo(Algarismo, Base)) throw new Exception("Esse algarismo não pertecem a essa base.");
            int i, Exp = 0;
            Int64 Numero = 0;
            for (i = 0; i < Algarismo.Length; i++)
            {
                Exp = (Algarismo.Length - (1 + i));
                Numero += (AlgarismoParaNumero(Algarismo[i]) * (Int64)Math.Pow(Base, Exp));
            }
            if (decimal.Parse(Numero.ToString()) > Int32.MaxValue) throw new Exception("O valor a ser convertido é muito alto.");
            return Numero.ToString();
        }

        /// <summary>
        /// Converte o decimal para algarismo.
        /// </summary>
        /// <param name="Algarismo">Algarismo em decimal a ser convertido.</param>
        /// <param name="Base">Para que base o algarismo em decimal deve ser convertido.</param>
        private string ConverterDecimalParaAlgarismo(string Algarismo, int Base)
        {
            if (Algarismo.Length <= 0) throw new Exception("Digite algum algarismo para ser convertido.");
            if (Algarismo.Contains(".") || Algarismo.Contains(",")) throw new Exception("Use apenas algarismos inteiros.");
            if (!ChecarBaseAlgarismo(Algarismo, 10)) throw new Exception("Esse algarismo não pertecem a essa base.");
            int Resto;
            Int64 Numero;
            Numero = Int64.Parse(Algarismo);
            Algarismo = String.Empty;
            while (Numero > 0)
            {
                Resto = (int)(Numero % Base);
                Algarismo += NumeroParaAlgarismo(Resto);
                Numero = Numero / Base;
            }
            return ReverterString(Algarismo);
        }

        /// <summary>
        /// Converte o decimal para algarismo.
        /// </summary>
        /// <param name="Algarismo">Algarismo a ser convertido.</param>
        /// <param name="DaBase">Base em que o algarismo está.</param>
        /// <param name="ParaBase">Para que base o algarismo deve ser convertido.</param>
        public string ConverterAlgarismo(string Algarismo, int DaBase, int ParaBase)
        {
            try
            {
                return ConverterDecimalParaAlgarismo(ConverterAlgarismoParaDecimal(Algarismo, DaBase), ParaBase);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
