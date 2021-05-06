using System;

namespace lab_2___infbez
{
    class Program
    {
        static void Main(string[] args)
        {

            char[,] alphavite = {
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


            Console.WriteLine("Зашифровать строку: введите 1");
            Console.WriteLine("Расшифровать строку: введите 2");
            Console.WriteLine("Закончить: введите 0");

            string run = Console.ReadLine();
            while (run != "0")
            {
                if (run == "1")
                {
                    Console.WriteLine("Введите ключ:");
                    string key = Console.ReadLine();

                    Console.WriteLine("Введите строку:");
                    string inputText = Console.ReadLine();
                    string[] code = new string[inputText.Length];
                    bool sucsessFlag = true;
                    int keyCursor = 0;

                    for (int inputChar = 0; inputChar < inputText.Length; inputChar++)
                    {
                        int indexOfCharInAlphv = 0;
                        int indOfKeyInAlphv = 0;

                        if (keyCursor >= key.Length)
                        {
                            keyCursor = 0;
                        }

                        bool textNotFound = true;
                        bool keyNotFound = true;

                        for (int i = 0; i < 9; i++)
                        {

                            for (int j = 0; j < 8; j++)
                            {
                                if (inputText[inputChar] == alphavite[i, j] && textNotFound)
                                {
                                    indexOfCharInAlphv = i * 8 + j + 1;
                                    textNotFound = false;
                                }

                                if (key[keyCursor] == alphavite[i, j] && keyNotFound)
                                {
                                    indOfKeyInAlphv = i * 8 + j + 1;
                                    keyNotFound = false;
                                }

                                if (!textNotFound && !keyNotFound)
                                    break;
                            }

                            if (!textNotFound && !keyNotFound)
                            {
                                int indCod = (indexOfCharInAlphv + indOfKeyInAlphv) % 72;
                                indCod -= 1;
                                int iCod = indCod / 8;
                                int jCod = indCod % 8;

                                code[inputChar] = alphavite[iCod, jCod].ToString();
                                break;
                            }
                        }

                        keyCursor++;

                        if (textNotFound)
                        {
                            sucsessFlag = false;
                            Console.WriteLine("В введёной строке присутствует недопустимый символ, попробуйте снова\n");
                            break;
                        }

                        if (keyNotFound)
                        {
                            sucsessFlag = false;
                            Console.WriteLine("В введёном ключе присутствует недопустимый символ, попробуйте снова\n");
                            break;
                        }
                    }

                    if (sucsessFlag)
                    {
                        Console.WriteLine("Зашифрованная строка:");
                        for (int i = 0; i < code.Length; i++)
                        {
                            Console.Write(code[i]);
                        }
                        Console.WriteLine(); Console.WriteLine();
                    }

                }

                if (run == "2")
                {
                    Console.WriteLine("Введите ключ:");
                    string key = Console.ReadLine();
                    Console.WriteLine("Введите зашифрованную строку:");
                    string code = Console.ReadLine();
                    string[] output = new string[code.Length];
                    bool sucsessFlag = true;

                    int keyCursor = 0;
                    for (int charIndex = 0; charIndex < code.Length; charIndex++)
                    {
                        int indOfCode = 0;
                        int indOfKey = 0;

                        if (keyCursor >= key.Length)
                        {
                            keyCursor = 0;
                        }

                        bool textFlag = true;
                        bool keyFlag = true;

                        for (int i = 0; i < 9; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (code[charIndex] == alphavite[i, j] && textFlag)
                                {
                                    indOfCode = i * 8 + j + 1;
                                    textFlag = false;
                                }

                                if (key[keyCursor] == alphavite[i, j] && keyFlag)
                                {
                                    indOfKey = i * 8 + j + 1;
                                    keyFlag = false;
                                }
                                if (!textFlag && !keyFlag)
                                    break;

                            }

                            if (!textFlag && !keyFlag)
                            {
                                int indOfInput = indOfCode - indOfKey;
                                if (indOfInput <= 0)
                                {
                                    indOfInput += 72;
                                }
                                indOfInput = indOfInput - 1;
                                int iInp = indOfInput / 8;
                                int jInp = indOfInput % 8;

                                output[charIndex] = alphavite[iInp, jInp].ToString();
                                break;
                            }
                        }

                        keyCursor++;

                        if (textFlag)
                        {
                            sucsessFlag = false;
                            Console.WriteLine("В введёной строке присутствует недопустимый символ, попробуйте снова\n");
                            break;
                        }

                        if (keyFlag)
                        {
                            sucsessFlag = false;
                            Console.WriteLine("В введёном ключе присутствует недопустимый символ, попробуйте снова\n");
                            break;
                        }
                    }
                    if (sucsessFlag)
                    {
                        Console.WriteLine("Исходная строка:\n");
                        for (int i = 0; i < output.Length; i++)
                        {
                            Console.Write(output[i]);
                        }
                        Console.WriteLine();
                    }
                }

                Console.WriteLine("Зашифровать строку: введите 1");
                Console.WriteLine("Расшифровать строку: введите 2");
                Console.WriteLine("Закончить: введите 0");
                run = Console.ReadLine();
            }
        }
    }
}
