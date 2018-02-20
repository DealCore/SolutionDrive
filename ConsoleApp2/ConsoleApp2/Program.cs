using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {

        static void Main(string[] args)
        {
            
            String st; // переменная для вводного значения
            String comChar = ""; // переменная для [COMMAND_CHARACTER]
            String param = ""; // переменная для [PARAMETERS]

            String helpFreq = "";
            String helpDur = "";
            int frequency;
            int duration;

            int l = 0; // переменная для длины строки
            

            Console.WriteLine("Please input -/");
            st = Console.ReadLine(); // запись вводных данных в переменную st

            l = st.Length; // определение длинны вводных данных
            An(st); // запуск метода на проверку корректности полученных данных

            void An(string f) { // метод принимает вводные данные
                if (f[0].Equals('P') && f[l - 1].Equals('E')) // проверка на начало и конец вводных данных
                {   
                    RazBil(st); // запуск метода для определения [COMMAND_CHARACTER] и [PARAMETERS]
                    DetectCommands(comChar); // запуск метода для определения вводимой команды
                }
                else {
                    Console.WriteLine(false);
                }
            }
            Console.ReadLine();
            void RazBil(string h) { // метод принимает переменную с вводными данными
                if(true)
                for (int i = 1; i < l - 2; i++) { 
                        if (!h[i].Equals(':')) { // если не определён символ ':'
                            comChar += h[i]; // то включить текущий символ в переменную r
                        }
                        if (h[i].Equals(':')) { //если определён символ ':'
                            i++;
                            for (; i < l - 2; i++) // продолжить цикл
                                param += h[i]; // добавить текущий символ в переменную r2

                                if (h[i].Equals(':')) { // если определён символ ':'
                                break;
                                }
                        }
                }
            }
            
            void DetectCommands(string det) { // метод для определения вводимой команды

                switch (det) { 
                    case "T": // если введён символ T
                        TextOu(param); // запустить метод для вывода значения переменной param в консоль
                        break;
                    case "S": // если введён символ S
                        Sound(param); // запустить метод для звука
                        break;
                    default:
                        Console.WriteLine("NACK"); // введена не действительная команда
                        break;
                }
            }
            void TextOu(string p) { // метод для вывода значения переменной param
                Console.WriteLine(p);
            }
            void Sound(string j) { // метод принимает значение переменной param
                for (int i = 0; i < j.Length; i++) {
                    if (!j[i].Equals(',')) { // если не обнаружен знак ','
                        helpFreq += j[i]; // то добавить текущий символ в переменную helpFreq
                    }

                    if (j[i].Equals(',')) { // если обнаружен символ ','
                        i++; // инкремента, для пропуска символа ','
                        for (; i < j.Length; i++) { // цикл продолжается с того же символа
                            helpDur += j[i]; //добавить символ в переменную helpDur

                        }
                        frequency = int.Parse(helpFreq); // преобразование значения [COMMAND_CHARACTER]
                        duration = int.Parse(helpDur); // преобразование значения [PARAMETERS]
                        Console.Beep(frequency, duration); // использование полученых значений в функции Beep
                    }
                }
            }
        }
    }
}

