// See https://aka.ms/new-console-template for more information

namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true;

            Console.WriteLine("Введите Ваше имя:");
            string name = Console.ReadLine();


            while (keepRunning)
            {

                int questionsCount = 5;

                // Вопросы
                string[] questions = GetQuestions(questionsCount);
                int[] answers = GetAnswers(questionsCount);


                int correctAnswersCount = 0;

                var usedIndices = new HashSet<int>(); // создаем пустой объект Hashset  для хранения значения индекса

                Random random = new Random(); // Создаем объект для генерации случайных чисел


                for (int i = 0; i < questionsCount; i++)
                {

                    int randomQuestionIndex;
                    do // вначале выполняем то что внутри
                    {
                        randomQuestionIndex = random.Next(0, questionsCount);

                    } while (!usedIndices.Add(randomQuestionIndex)); // проверяем условие

                    // Add вернёт false, если индекс уже был — тогда цикл повторится



                    Console.WriteLine($"Вопрос №{i + 1}");

                    //  int randomQuestionIndex = random.Next(0, questionsCount);
                    Console.WriteLine(questions[randomQuestionIndex]);

                    Console.Write("Ваш ответ: ");
                    int userAnswer = int.Parse(Console.ReadLine());

                    if (userAnswer == answers[randomQuestionIndex])
                    {
                        correctAnswersCount++;
                    }
                }

                Console.WriteLine($"Количество правильных ответов: {correctAnswersCount}");
                Console.Write(name+", ");
                GetDiagnosis(correctAnswersCount);
                Console.WriteLine($"{name},хотите пройти тест еще раз? да/нет");
                string answer = Console.ReadLine()?.Trim().ToLower();

                if (answer != "да" && answer != "д")
                {
                    keepRunning = false; // выходим из цикла, программа завершится
                }
            }
        }

        static string[] GetQuestions(int questionsCount) // вопросы
        {
            string[] questions = new string[questionsCount];
            questions[0] = "Сколько будет 2 плюс 2, умноженное на 2?";
            questions[1] = "Бревно нужно распилить на 10 частей. Сколько надо сделать распилов?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса. Сколько нужно минут для трех уколов?";
            questions[4] = "5 свечей горело, 2 потухли. Сколько свечей осталось?";

            return questions;
        }

        static int[] GetAnswers(int questionsCount) // ответы
        {

            int[] answers = new int[questionsCount];
            answers[0] = 6;   // Для первого вопроса
            answers[1] = 9;   // Для второго
            answers[2] = 25;  // Для третьего
            answers[3] = 60;  // Для четвертого
            answers[4] = 2;   // Для пятого


            return answers;

        }

        static void GetDiagnosis(int correctAnswersCount)
        {

            string[] diagnoses =
          [
              "Идиот",    // индекс 0
                "Кретин",   // индекс 1  
                "Дурак",    // индекс 2
                "Нормальный", // индекс 3
                "Талант",   // индекс 4
                "Гений"     // индекс 5
          ];

            // Получаем диагноз по индексу, равному количеству правильных ответов
            string diagnosis = diagnoses[correctAnswersCount];
            Console.WriteLine($"Ваш диагноз: {diagnosis}");

        }

    }
}