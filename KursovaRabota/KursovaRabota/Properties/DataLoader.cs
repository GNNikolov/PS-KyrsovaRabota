using System;
using System.Collections.Generic;

namespace KursovaRabota.Properties
{
    class DataLoader
    {
        public List<TestQuestion> items = new List<TestQuestion>();

        public DataLoader()
        {
            TestQuestion t0 = new TestQuestion();
            t0.QuestionNumber = "Въпрос 0";
            t0.Question = "Коя от посочените формули изразява първия принцип на термодинамиката при изотермен процес?";
            t0.RightAnswer = "dU = Q;";
            RandomAnswerArrange(new List<string> { "U=const;", "A + Q = 0, dU = 0;"
                , "dU = A + Q;", "dU = Q;"}, t0);
            items.Add(t0);

            TestQuestion t1 = new TestQuestion();
            t1.QuestionNumber = "Въпрос 1";
            t1.Question = "Хармоничното трептене:";
            t1.RightAnswer = "се извършва при постоянна сила;";
            RandomAnswerArrange(new List<string> { "възниква в точно определен момент;", "се извършва при сила F = -kx;"
                , "се извършва при сила, перпендикулярна на тялото;", "се извършва при постоянна сила;"}, t1);
            items.Add(t1);
            

            TestQuestion t2 = new TestQuestion();
            t2.QuestionNumber = "Въпрос 2";
            t2.Question = "Пружинно махало трепти хармонично. При отклонение от равновесното положение на 5см скоростта на тежестта е 8см/с, а при отклонение 4см  - 10см/с. Периодът на трептене е:";
            t2.RightAnswer = "2 s";
            RandomAnswerArrange(new List<string> { "3,14 s", "12,56 s", "0,5 s", "2 s" }, t2);
            items.Add(t2);


            TestQuestion t3 = new TestQuestion();
            t3.QuestionNumber = "Въпрос 3";
            t3.Question = "Определете напрежението меду електродите на кондензатор с капацитет 280 pF и заряд 28 nC.";
            t3.RightAnswer = "0,1 V";
            RandomAnswerArrange(new List<string> { "784 V", "100 V", "10 V", "0,1 V" }, t3);
            items.Add(t3);
            

            TestQuestion t4 = new TestQuestion();
            t4.QuestionNumber = "Въпрос 4";
            t4.Question = "Кои са основните токови носители в полупроводници с p-проводимост?";
            t4.RightAnswer = "дупки, електрони и йони";
            RandomAnswerArrange(new List<string> {"дупки", "електрони","дупки и електрони", "дупки, електрони и йони"}, t4);
            items.Add(t4);

            TestQuestion t5 = new TestQuestion();
            t5.QuestionNumber = "Въпрос 5";
            t5.Question = "Полупроводниковите диоди имат следните функции:";
            t5.RightAnswer = "превръщат електричната енергия в звукова;";
            RandomAnswerArrange(new List<string> { "усливат електрическите сигнали;", "изправят ел. ток;"
                , "превръщат електричната енергия в топлинна;", "превръщат електричната енергия в звукова;" }, t5);
            items.Add(t5);

            TestQuestion t6 = new TestQuestion();
            t6.QuestionNumber = "Въпрос 6";
            t6.Question = "Вълна с честота 82,5 Hz се разпространява със скорост 330 м/сек. Дължината на вълната е:";
            t6.RightAnswer = "2m";
            RandomAnswerArrange(new List<string> { "2m;", "4m;", "40 m;", "не може да се определи;" }, t6);
            items.Add(t6);

        }
        private static void RandomAnswerArrange(List<string> input, TestQuestion item)
        {
            Shuffle(input);
            item.AnswerA = input[0];
            item.AnswerB = input[1];
            item.AnswerC = input[2];
            item.AnswerD = input[3];
        }

        private static Random rng = new Random();

        public static void Shuffle(List<string> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
