using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace HomeWork_9
{
    public class ContactManager
    {
        private List<Contact> contacts_ = new List<Contact>() { }; // Список контактов
        public Contact this[int index] // Перегруженный индексатор списка контактов
        {
            get
            {
                if (index >= 0 && index < contacts_.Count()) { return contacts_[index]; }
                throw new IndexOutOfRangeException(); // Исключение при выходе за пределы диапазона книги контактов
            }            
            set { contacts_[index] = value; }
        }
        public void AddContact(string name, string phone_number) // Метод добавления нового контакта (по условию задачи)
        {
            try
            {
                if (name == null || name == "" || phone_number == null || phone_number == "") 
                    throw new InvalidContactException("Не хватает данных в контакте!");
            }
            catch (InvalidContactException ex) // Обработка некорректно вввведёного контакта
            {
                while (name == null || name == "" || phone_number == null || phone_number == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nОшибка: {ex.Message}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Введите данные ещё раз.\nВведите имя -> ");
                    name = Console.ReadLine();
                    Console.Write("Введите номер телефона -> ");
                    phone_number = Console.ReadLine();
                }                
            }
            contacts_.Add(new Contact(name, phone_number));
        }
        public List<Contact> FindContactByName(string name) // Метод формирования списка контактов с именем name (по условию задачи)
        {      
            return contacts_.Where(el => el.Name == name).ToList();
        }
        public void Sort() // Метод сортиртировки книги контактов по алфавитному порядку имён
        {
            contacts_.Sort((left, right) => left.Name.CompareTo(right.Name));
        }
        public void Print() // Метод вывода в консоль телефонной книги
        {
            int counter = 0;
            foreach (Contact el in contacts_)
            {
                Console.WriteLine($"{counter + 1}. Имя: {el.Name}, номер телефона: {el.Phone_Number}");
                counter++;
            }
        }
        public void Delete_Contact(int index)
        {
            contacts_.RemoveAt(index - 1);
        }
        public int Size() { return contacts_.Count; }
    }
}
