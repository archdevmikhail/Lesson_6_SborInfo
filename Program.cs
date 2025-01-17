﻿namespace SborInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan; // Устанавливает цвет текста консоли. Красота спасёт Мир!)

            // Сбор информации от пользователя:

            Console.WriteLine("Как Вас зовут?"); // Запрашивает имя пользователя
            string? name = Console.ReadLine(); // Читает введённое имя и сохраняет его в переменной "name"

            Console.WriteLine("Сколько Вам лет?"); // Запрашивает возраст пользователя
            string? ageInput = Console.ReadLine(); // Читает введённый возраст и сохраняет его в переменной ageInput
            int age = 0; // Инициализирует переменную age значением 0      


            // Преобразование возраста с обработкой исключений:

            // Используется для обработки исключений (ошибок), которые могут возникнуть во время выполнения программы.
            // Если в блоке try возникает ошибка, управление передаётся в блок catch, где можно обработать это исключение.

            try
            {
                age = Convert.ToInt32(ageInput); // Пробует преобразовать введённый возраст в целое число

                if (age < 0) // Проверка: если возраст отрицательный
                {
                    Console.WriteLine("Некорректный ввод возраста. Установим возраст в 0."); // Уведомляет польз. о некорректном вводе
                    age = 0; // Устанавливает возраст в 0
                }
            }

            catch // Блок catch срабатывает, если было выброшено исключение
            {
                Console.WriteLine("Некорректный ввод возраста. Установим возраст в 0."); // Уведомляет пользователя о некорректном вводе                
            }


            Console.WriteLine("Есть ли ребёнок до 18 лет? (Да/Нет)"); // Запрашивает информацию о наличии детей до 18 лет
            string? hasChild = Console.ReadLine(); // Читает ответ пользователя (да или нет)
            string? childGender = string.Empty; // Инициализирует переменную childGender для хранения пола ребенка


            // Развилка для ответа на вопрос о ребенке:


            if (hasChild != null && hasChild.Equals("Да", StringComparison.OrdinalIgnoreCase)) // Проверяет, равен ли ответ "Да"        
            {
                Console.WriteLine("Мальчик или девочка?"); // Запрашивает пол ребенка
                childGender = Console.ReadLine(); // Читает введённый пол ребенка              
            }

            else if (hasChild != null && hasChild.Equals("Нет", StringComparison.OrdinalIgnoreCase)) // ну нет и нет))
            {
                Console.WriteLine("Понятно, детей нет."); // Уведомляет, если детей нет           
            }

            else
            {
                Console.WriteLine("Некорректный ввод. Ответ будет считаться как 'Нет'."); // Сообщает о некорректном вводе
                hasChild = "Нет"; // Устанавливает значение по умолчанию                                                                         
            }


            // Вывод собранных данных с дополнительными условиями

            Console.WriteLine("\nВаши ответы:"); // Заголовок для отображения ответа пользователя
            Console.WriteLine($"1. Как Вас зовут: {name}"); // Вывод имени пользователя
            Console.WriteLine($"2. Сколько Вам лет: {age}"); // Вывод возраста пользователя
            Console.WriteLine($"3. Есть ли ребёнок до 18 лет: {hasChild}"); // Вывод информации о детях


            if (hasChild != null && hasChild.Equals("Да", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Пол ребенка: {childGender}"); // Вывод пола ребенка, если он есть               
            }


            /*
            Условия для определения групп в зависимости от возраста

            Группа 1 до 17 лет (включительно)
            Группа 2 с 18 до 64 лет (включительно)
            Группа 3 с 65 до ∞ (до победного конца =) )
            
            */

            if (age < 18) // Проверяем, меньше ли возраст 18
            {
                Console.WriteLine("Вы в группе 1"); // Сообщает, что пользователь в группе 1
            }

            else if (age >= 18 && age < 65) // Проверяем, находится ли возраст от 18 до 64
            {
                Console.WriteLine("Вы в группе 2"); // Сообщает, что пользователь в группе 2
            }

            else // Если ни одно из предыдущих условий не выполнено, то...
            {
                Console.WriteLine("Вы в группе 3"); // Сообщает, что пользователь в группе 3
            }


            // Запись результатов в текстовый файл

            string filePath = "результаты_опроса.txt";
            // Определяет путь к файлу, в который будут записаны результаты
            // Тут по умолчанию сохраняет в папку с проектом
            // У меня путь такой: C:\Users\miche\source\repos\SborInfo\bin\Debug\net8.0

            string results = $"\nИмя: {name}\nВозраст: {age}\nЕсть ли ребёнок до 18 лет: {hasChild}"; // Формирует строку с результатами опроса

            if (hasChild != null && hasChild.Equals("Да", StringComparison.OrdinalIgnoreCase))
            {
                results += $"\nПол ребенка: {childGender}"; // Добавляет пол ребенка к результатам, если он указан
                Console.WriteLine("Вам положен подарок на Новый Год!"); // Уведомляет пользователя о подарке
            }

            results += "\n"; // Пустая строка для разделения записей. Ради красоты и удобства)

            File.AppendAllText(filePath, results); // Записывает результаты в указанный файл

            Console.WriteLine($"Результаты успешно сохранены в файл: {filePath}"); // Уведомляет пользователя об успешном сохранении результатов
            Console.ReadKey(); // Ждет нажатия клавиши (любой) для завершения программы
        }
    }
}
