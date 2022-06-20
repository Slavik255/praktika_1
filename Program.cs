using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApplicationTest
{
    public static class Program
    {
        //Создание файла, если его нет
        public static void CreateFile(string directory, string path)
        {
            var directoryInfo = new DirectoryInfo(directory);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            FileStream file = new FileStream(path, FileMode.OpenOrCreate);
            file.Close();
        }

        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            string directory = @"E:\Program po 3d modelirovanii-o\Rabotu visual studio\praktika\praktika_zadanie\Practice";
            string path = directory + "\\input.txt";
            CreateFile(directory, path);

            bool working = true;
            bool error = true;
            do
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Добавить запись в файл");
                Console.WriteLine("2 - Просмотреть все записи файла");
                Console.WriteLine("3 - Вывести информацию о самом старшем студенте");
                Console.WriteLine("4 - Выход");
                int selector = int.Parse(Console.ReadLine());

                if (selector == 1)
                {
                    // Читаем из файла
                    string[] all_Lines = File.ReadAllLines(@"E:\Program po 3d modelirovanii-o\Rabotu visual studio\praktika\praktika_zadanie\input.txt");
                    // Преобразуем в массив студентов
                    Student[] all_students = new Student[all_Lines.Length];
                    for (int index = 0; index < all_Lines.Length; index++)
                    {
                        string line = all_Lines[index];
                        string[] fields = line.Split(';');
                        Student student = new Student(fields[0], fields[1], fields[2], Convert.ToInt32(fields[3]), fields[4], fields[5]);
                        all_students[index] = student;
                    }

                    StreamWriter sw = new StreamWriter(@"E:\Program po 3d modelirovanii-o\Rabotu visual studio\praktika\praktika_zadanie\Practice\input.txt");
                    foreach (Student student in all_students)
                    {
                        sw.WriteLine(student);
                    }

                    //Ввод данных
                    Console.Write("Введите имя: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите фамилия: ");
                    string surname = Console.ReadLine();
                    Console.Write("Введите отчество: ");
                    string middle_name = Console.ReadLine();

                    int yearOfBirth;
                    do
                    {
                        Console.Write("Введите год рождения: ");
                        try
                        {
                            yearOfBirth = int.Parse(Console.ReadLine());
                            error = false;
                        }
                        catch (FormatException)
                        {
                            yearOfBirth = 0;
                            Console.WriteLine("Введены неверные данные!");
                        }
                        catch (OverflowException)
                        {
                            yearOfBirth = 0;
                            Console.WriteLine("Введены неверные данные!");
                        }
                    }
                    while (error);
                    error = true;

                    string gender = string.Empty;
                    do
                    {
                        Console.Write("Введите пол (man или girl): ");
                        string man_or_girl = Console.ReadLine();
                        if (man_or_girl == "man")
                        {
                            gender = man_or_girl;
                            error = false;
                        }
                        else if (man_or_girl == "girl")
                        {
                            gender = man_or_girl;
                            error = false;
                        }
                        else
                        {
                            Console.WriteLine("Введите man или girl!");
                            Console.WriteLine();
                        }
                    }
                    while (error);
                    error = true;

                    int russian;
                    do
                    {
                        Console.Write("Введите массив оценок\nРусский язык - ");
                        try
                        {
                            russian = int.Parse(Console.ReadLine());
                            error = false;
                        }
                        catch (FormatException)
                        {
                            russian = 0;
                            Console.WriteLine("Введены неверные данные!");
                        }
                        catch (OverflowException)
                        {
                            russian = 0;
                            Console.WriteLine("Введены неверные данные!");
                        }
                    }
                    while (error);
                    error = true;

                    int physics;
                    do
                    {
                        Console.Write("Физика - ");
                        try
                        {
                            physics = int.Parse(Console.ReadLine());
                            error = false;
                        }
                        catch (FormatException)
                        {
                            physics = 0;
                            Console.WriteLine("Введены неверные данные!");
                        }
                        catch (OverflowException)
                        {
                            physics = 0;
                            Console.WriteLine("Введены неверные данные!");
                        }
                    }
                    while (error);
                    error = true;

                    int mathematics;
                    do
                    {
                        Console.Write("Математика - ");
                        try
                        {
                            mathematics = int.Parse(Console.ReadLine());
                            error = false;
                        }
                        catch (FormatException)
                        {
                            mathematics = 0;
                            Console.WriteLine("Введены неверные данные!");
                        }
                        catch (OverflowException)
                        {
                            mathematics = 0;
                            Console.WriteLine("Введены неверные данные!");
                        }
                    }
                    while (error);
                    error = true;

                    int programming;
                    do
                    {
                        Console.Write("Программирование - ");
                        try
                        {
                            programming = int.Parse(Console.ReadLine());
                            error = false;
                        }
                        catch (FormatException)
                        {
                            programming = 0;
                            Console.WriteLine("Введены неверные данные!");
                        }
                        catch (OverflowException)
                        {
                            programming = 0;
                            Console.WriteLine("Введены неверные данные!");
                        }
                    }
                    while (error);
                    error = true;

                    int english_language;
                    do
                    {
                        Console.Write("Английский язык - ");
                        try
                        {
                            english_language = int.Parse(Console.ReadLine());
                            error = false;
                        }
                        catch (FormatException)
                        {
                            english_language = 0;
                            Console.WriteLine("Введены неверные данные!");
                        }
                        catch (OverflowException)
                        {
                            english_language = 0;
                            Console.WriteLine("Введены неверные данные!");
                        }
                    }
                    while (error);
                    Console.WriteLine("Вы добавили в файл следующие данные:\n" + name + "; " + surname + "; " + middle_name + "; " + yearOfBirth + "; " + gender + "; Оценки: Русский язык - " + russian + ", Физика - " + physics + ", Математика - " + mathematics + ", Программирование - " + programming + ", Английский язык - " + english_language);

                    //Запись в файл
                    sw.WriteLine(name + "; " + surname + "; " + middle_name + "; " + yearOfBirth + "; " + gender + "; Оценки: Русский язык - " + russian + ", Физика - " + physics + ", Математика - " + mathematics + ", Программирование - " + programming + ", Английский язык - " + english_language);

                    //Закрытие файла
                    sw.Close();
                }

                if (selector == 2)
                {
                    // Читаем из файла
                    string[] all_Lines = File.ReadAllLines(@"E:\Program po 3d modelirovanii-o\Rabotu visual studio\praktika\praktika_zadanie\Practice\input.txt");
                    // Преобразуем в массив студентов
                    Student[] all_students = new Student[all_Lines.Length];
                    for (int index = 0; index < all_Lines.Length; index++)
                    {
                        string line = all_Lines[index];
                        string[] fields = line.Split(';');
                        Student student = new Student(fields[0], fields[1], fields[2], Convert.ToInt32(fields[3]), fields[4], fields[5]);
                        all_students[index] = student;
                    }

                    //Вывод данных из файла
                    foreach (Student student in all_students)
                    {
                        Console.WriteLine(student);
                        Console.WriteLine();
                    }
                }

                if (selector == 3)
                {
                    // Читаем из файла
                    string[] all_Lines = File.ReadAllLines(@"E:\Program po 3d modelirovanii-o\Rabotu visual studio\praktika\praktika_zadanie\Practice\input.txt");
                    // Преобразуем в массив студентов
                    Student[] all_students = new Student[all_Lines.Length];
                    for (int index = 0; index < all_Lines.Length; index++)
                    {
                        string line = all_Lines[index];
                        string[] fields = line.Split(';');
                        Student student = new Student(fields[0], fields[1], fields[2], Convert.ToInt32(fields[3]), fields[4], fields[5]);
                        all_students[index] = student;
                    }
                    Array.Sort(all_students);
                    int student_max = 0;
                    foreach (Student student in all_students)
                    {
                        if (student.Gender == " man")
                        {
                            Array.Sort(all_students);
                            student_max++;
                            if (student_max == 1)
                            {
                                Console.WriteLine("Информация о самом старшем студенте:\n" + student);
                                Console.WriteLine();
                            }
                        }
                    }
                }

                if (selector == 4)
                {
                    working = false;
                }

                if (selector <= 0 || selector >= 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Выберите 1, 2, 3 или 4");
                    Console.WriteLine();
                }
            }
            while (working);
        }
    }

    public struct Student : IComparable
    {
        public Student(string name, string surname, string middle_name, int yearOfBirth, string gender, string estimation)
            : this()
        {
            Name = name;
            Surname = surname;
            Middle_name = middle_name;
            YearOfBirth = yearOfBirth;
            Gender = gender;
            Estimation = estimation;
        }

        // имя
        public string Name { get; set; }
        // фамилия
        public string Surname { get; set; }
        // отчество
        public string Middle_name { get; set; }
        // год рождения
        public int YearOfBirth { get; set; }
        // пол
        public string Gender { get; set; }
        // оценки
        public string Estimation { get; set; }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            return YearOfBirth.CompareTo(((Student)obj).YearOfBirth);
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0};{1};{2}; {3};{4};{5}", Name, Surname, Middle_name, YearOfBirth, Gender, Estimation);
        }
    }
}