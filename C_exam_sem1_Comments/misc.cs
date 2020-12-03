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
            string[] words = Regex.Split(input, @"[ ,;]+");//WE SEPARATE THE INPUT INTO WORDS WITH THIS REGEX EXPRESSION, STORED IN THE WORDS ARRAY
            string characters;// THIS WILL BE THE CORRECTED WORD
            string result = "";//THIS WILL BE THE CORRECTED INPUT
            string[] greatwords = new string[100];//WE DON'T USE THIS
            for (int i = 0; i < words.Length; i++)//RECORREMOS EL ARRAY DE PALABRAS
            {

                if(words[i].Length != 0)//RECORREMOS LAS LETRAS DE CADA PALABRA
                {
                    characters = char.ToUpper(words[i][0]).ToString();//UPPERCASE THE FIRST LETTER
                    for (int o = 1; o < words[i].Length; o++)
                    {
                        characters += char.ToLower(words[i][o]);//LOWERCASE THE REMAINING LETTERS
                    }
                    result += characters + " ";//WE ADD EACH WORD + A SPACE IN THE RESULT STRING
                }
                
            }
            
            return result;//RETURN THIS STRING
        }

        public static object adjust(double input)
        {
            if(input < 0)//IF THE INPUT IS LOWER THAN 0 SEPILLO
            {
                input = 0;
                return input;
            }
            return Math.Round(input, 2);//REDONDEAMOS A 2 DECIMALES LOS PARAMETROS SON EL NUMERO Y LOS DECIMALES QUE QUEREMOS QUE TENGA
        }
        public static object noNegative(int input)
        {
            if (input < 0)//IF THE INPUT IS LOWER THAN 0 SEPILLO
            {
                input = 0;
                return input;
            }
            return input;
        }

    }
}
