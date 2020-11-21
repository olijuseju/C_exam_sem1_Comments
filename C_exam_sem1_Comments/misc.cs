using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace C_exam_sem1_Comments
{
    class misc
    {

        public static object normalize(string input)
        {
            //Separamos la entrada por palabras
            string[] words = Regex.Split(input, @"[ ,;]+");
            string characters;
            string result = "";
            string[] greatwords = new string[100];
            //Recorremos el array con las palabras
            for (int i = 0; i < words.Length; i++)
            {
                //La primera palabra mayúscula y el resto minúscula en cada palabra
                characters = char.ToUpper(words[i][0]).ToString();
                for (int o = 1; o < words[i].Length; o++)
                {
                    characters += char.ToLower(words[i][o]);
                }
                //guardamos las buenas en este array
                result += characters + " ";
            }
            //Juntamos las palabras del array en un nuevo string separando por espacios
            /*foreach (string word in greatwords)
            {
                result += word;
                result += " ";
            }*/

            return result;
        }

        public static object adjust(double input)
        {
            if(input < 0)
            {
                input = 0;
                return input;
            }
            return Math.Round(input, 2);
        }
        public static object noNegative(int input)
        {
            if (input < 0)
            {
                input = 0;
                return input;
            }
            return input;
        }

    }
}
