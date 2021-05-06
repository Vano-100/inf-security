using System;


namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] alphavite =
            {
                {'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж'},
                {'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О'},
                {'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц'},
                {'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю'},
                {'Я', 'а', 'б', 'в', 'г', 'д', 'е', 'ё'},
                {'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н'},
                {'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х'},
                {'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э'},
                {'ю', 'я', ' ', '.', ':', '!', '?',','},
            };

            Console.WriteLine("Зашифровать строку - введите 1");
            Console.WriteLine("Расшифровать строку - введите 2");
            Console.WriteLine("Закончить - введите 0");

            string run = Console.ReadLine();

            while ( run != "0")
            {
                if(run == "1")
                {
                    Console.WriteLine("Введите строку");
                    string input = Console.ReadLine();
                    string[] code = new string[input.Length];
                    //провеку на валидность добавить
                    bool sucsess = true;

                    for (int charIndex = 0; charIndex < input.Length; charIndex++)
                    {
                        bool isCodeFound = false;

                        for (int i = 0; i < 9; i++)
                        {
                            if (isCodeFound)
                            {
                                break;
                            }

                            for (int j = 0; j < 8; j++)
                            {        
                                if (input[charIndex] == alphavite[i, j])
                                {
                                    code[charIndex] = i.ToString() + j.ToString();
                                    isCodeFound = true;
                                    break;
                                }
                            }
                        }

                        if (!isCodeFound)
                        {
                            sucsess = false;
                            Console.WriteLine("В ведённой строке присутствует недопустимый символ\n");
                            break;
                        }
                    }

                    if (sucsess)
                    {
                        Console.WriteLine("Зашифрованная строка:\n");
                        for (int i = 0; i < code.Length; i++)
                        {
                            Console.Write(code[i] + " ");
                        }
                    }

                }

                if (run == "2")
                {
                    Console.WriteLine("Введите зашифрованную строку");
                    string [] code = Console.ReadLine().Split(' ');
                    string[] result = new string[code.Length];

                    for (int codeIndex = 0; codeIndex < code.Length; codeIndex++)
                    {
                        result[codeIndex] = alphavite[int.Parse(code[codeIndex].Substring(0, 1)), int.Parse(code[codeIndex].Substring(1, 1))].ToString();
                        
                    }
                    Console.WriteLine("Исходная строка:\n");
                    for (int i = 0; i < result.Length; i++)
                    {
                        Console.Write(result[i]);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Зашифровать строку введите 1");
                Console.WriteLine("Расшифровать строку введите 2");
                Console.WriteLine("Закончить введите 0");
                run = Console.ReadLine();
            }
        }
    }
}
