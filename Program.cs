using System.Text;
using System.Threading.Channels;

namespace HW_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Цель практической работы
            Научиться работать с файловой системой. Вы сможете читать данные из файла и записывать их туда.
            Что нужно сделать
            Создайте справочник «Сотрудники».
            Разработайте для предполагаемой компании программу, которая будет добавлять записи новых сотрудников в файл. Файл должен содержать следующие данные:
            ID
            Дату и время добавления записи
            Ф.И.О.
            Возраст
            Рост
            Дату рождения
            Место рождения
            Для этого необходим ввод данных с клавиатуры.После ввода данных:
            если файла не существует, его необходимо создать;
            если файл существует, то необходимо записать данные сотрудника в конец файла. 
            При запуске программы должен быть выбор:
            введём 1 — вывести данные на экран;
            введём 2 — заполнить данные и добавить новую запись в конец файла.*/    
            

            Console.WriteLine("СОТРУДНИКИ \nВведите 1 для вовыда списка сотрудников \nВведите 2 для добавления нового сотрудника");
            int inputNumber = int.Parse(Console.ReadLine());
            switch (inputNumber)
            {
                case 1:
                    ReadInfo();
                    break;
                case 2:
                    InputInfo();
                    break;
            }
        }
        static void ReadInfo()
        {
            if (File.Exists("notebookWorkers.txt"))
            {
                string[] lines = File.ReadAllLines("notebookWorkers.txt");
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else Console.WriteLine("Ошибка. Отсутсвует файл!");
        }
        static void InputInfo()
        {
            Console.WriteLine("Персональный номер(ID) сотрудника: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("ФИО сотрудника: ");
            string fullName= Console.ReadLine();
            Console.WriteLine("Возраст сотрудника: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Рост сотрудника: ");
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine("Дата рождения сотрудника: ");
            DateTime dateTimeOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Место рождения сотрудника: ");
            string placeOfBirth= Console.ReadLine();

            string newWorker = string.Format("{0}#{1}#{2}#{3}#{4}#{5}", id, DateTime.UtcNow, fullName, age, height, dateTimeOfBirth, placeOfBirth);
            File.AppendAllText("notebookWorkers.txt", newWorker + Environment.NewLine);
        }
    }
}
