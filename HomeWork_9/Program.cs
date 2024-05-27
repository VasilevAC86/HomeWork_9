using System.Timers;

namespace HomeWork_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ------------ Задача 1 - Среднее арифметическое в списке положительных чисел -----------
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Задача 1 - Среднее арифметическое в списке положительных чисел.");
            Console.ForegroundColor= ConsoleColor.White;
            List<int> list = new List<int>();
            Random r = new Random();
            for (int i = 0; i < 10; i++) 
                list.Add(r.Next(-10,2));
            Console.WriteLine("\nИсходный список чисел:");
            foreach (int i in list)
                Console.Write(i + ", ");
            Console.WriteLine("\b\b.");
            double result = Positive_Average(list);
            if (result != -1)
                Console.WriteLine("\nСреднее арифметическое всех положительных чисел в списке = " + result);

            // ------------ Задача 2 - Приложение для управления списком контактов -----------
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nЗадача 2 - Приложение для управления списком контактов.");
            Console.ForegroundColor = ConsoleColor.White;
            ContactManager contactManager = new ContactManager();
            // Заполнение книги контактов
            contactManager.AddContact("Вася", "+79638844750");
            contactManager.AddContact("Маша", "+79122084759");
            contactManager.AddContact("Петя", "+79222244773");
            contactManager.AddContact("Лера", "+79033044725");
            contactManager.AddContact("Вася", "+74993254879");
            contactManager.AddContact("Женя", "+73434421518");
            Console.WriteLine("\nИсходная книга контактов:");
            contactManager.Print();
            // Сортировка книги контактов по алфавитному порядку:
            Console.WriteLine("\nОтсортированная по алфавитному порядку имён книга контактов:");
            contactManager.Sort();
            contactManager.Print();
            // Добавление нового контакта в книгу контактов:
            Console.Write("\nВведите новый контакт:\nВведите имя -> ");
            string name = Console.ReadLine();
            Console.Write("Введите номер телефона -> ");
            string phone_number = Console.ReadLine();
            contactManager.AddContact(name, phone_number);
            Console.WriteLine("\nОтсортированная по алфавитному порядку имён обновлённая книга контактов:");
            contactManager.Sort();
            contactManager.Print();
            // Удаление контакта
            Console.Write("\nВыберите порядковый номер контакта, который Вы хотите удалить -> ");
            contactManager.Delete_Contact(Exc(Console.ReadLine(), contactManager.Size()));
            Console.WriteLine("\nОтсортированная по алфавитному порядку имён обновлённая книга контактов:");
            contactManager.Sort();
            contactManager.Print();
            // Поск контактов по имени
            Console.Write("\nВведите имя для поиска контактов -> ");
            name = Console.ReadLine();
            List<Contact> contacts = contactManager.FindContactByName(name);
            if (contacts.Count == 0)
                Console.WriteLine($"\nКонтактов с именем {name} не обнаружено");
            else
            {
                Console.WriteLine($"Результаты поиска по имени {name}:");
                int counter = 0;
                foreach (Contact el in contacts)
                {
                    Console.WriteLine($"{counter + 1}. Имя: {el.Name}, номер телефона: {el.Phone_Number}");
                    counter++;
                }
            }
        }
        static double Positive_Average(List<int> list) // Метод расчёта среднеарифметического положительных чисел в списке (для задачи 1)
        {            
            var result = from el in list
                         where el > 0         
                         select el;
            try
            {
                if (result.Count() == 0)
                    throw new NoPositiveNumbersException("Нет положительных чисел в списке!");
            }
            catch (NoPositiveNumbersException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nОшибка: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
                return -1;
            }
            return result.Average();
        }
        static int Exc(string message, int max) // Метод обработки введённого пользователем значения (для задачи 2)
        {
            int number = 0;
            // Если введённое значение можно преобразовать в int, то записываем его в number
            if (int.TryParse(message, out number)) { }
            if (number < 1 || number > max) // если введено не положительное целочисленное число, то 
            {
                while (!int.TryParse(message, out int value) || number < 1 || number > max)
                {
                    Console.Write("Введённое некорректное значение! Введите целое число от 1 до " + max + " -> ");
                    message = Console.ReadLine();
                    if (int.TryParse(message, out number)) { }
                }
            }
            return number;
        }
    }
}