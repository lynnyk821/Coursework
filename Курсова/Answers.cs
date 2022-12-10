using System;
using System.Text;

namespace Курсова
{
    public class Answers
    {
        public string[] TrueAnswers { get; private set; }
        public string[] FalseAnswers { get; private set; }
        public Answers(int TLen, int FLen)
        {
            TrueAnswers = ConcatAnswersWithLen(TCountry, TCapital, TLen);
            FalseAnswers = ConcatAnswersWithLen(FCountry, FCapital, FLen);
        }
        public string[] ConcatAnswersWithLen(string[] country, string[] capital, int len)
        {
            country = RandomOrder(country); capital = RandomOrder(capital);

            if (len > country.Length + capital.Length)
                throw new Exception("exception");
            
            StringBuilder stringBuilder = new StringBuilder();
            for(int i = 0, indexOfCountry = 0, indexOfCapital = 0; i < len; i++)
            {
                if (indexOfCountry != country.Length && indexOfCapital != capital.Length)
                    stringBuilder.Append(i % 2 == 0 ? country[indexOfCountry++] 
                        : capital[indexOfCapital++]).Append(' ');
                
                if(indexOfCapital == capital.Length && indexOfCountry != country.Length)
                    stringBuilder.Append(country[indexOfCountry++]).Append(' ');
                
                if(indexOfCountry == country.Length && indexOfCapital != capital.Length)
                    stringBuilder.Append(capital[indexOfCapital++]).Append(' ');
            }
            
            return stringBuilder.ToString().Split(' '); 
        }
        // ~
        // Я хочу, щоб мої питання висвічувались З КОЖНИМ РАЗОМ в хаотичному порядку, тому напишу для цього функцію.
        // RandomOrder - функція, що буде вертати массив стрінгів в хаотичниму порядку. - Чому стрінгів, а не питань... Тому що саме так,... 
        //
        private string[] RandomOrder(string[] data)
        {
            UniqueNumbers uniqueNumbers = new UniqueNumbers(0, data.Length, data.Length);
             
            string[] result = new string[data.Length];
            for(int i = 0; i < result.Length; i++) result[i] = data[uniqueNumbers[i]];
            
            return result;
        }
        // ~
        // Чому не відразу закинути все в один (True/False)Answers?
        // Тому що потрібна логіка, ми не можемо до свиней додати людей.
        //
        // Для чого потрібна логіка, логіку можна придумати будь-яку?
        // Логіка впорядкування тут така, що країни встановлюються за парними індексами, а столиці за непарними.
        //
        // ~
        // Запишемо правильні відповіді країн в масив стрінгів - TCountry.
        //
        public string[] TCountry = new string[]
        {
            "Україна", "Франція", "Німеччина", "Італія", "Польша",
            "Іспанія", "Англія", "Португалія", "Австрія", "Угорщина"
        };
        // ~
        // Запишемо неправильні відповіді країн в масив стрінгів - FCountry.
        //
        public string[] FCountry = new string[]
        {
            "Алжир", "Канада", "Ефіопія", "Ватикан", "Люксембург",
            "Австралія", "Індія", "Китай", "Данія", "Мексика",
            "Пакистан", "Естонія","Аргентина", "Андорра", "Бразилія"
        };
        // ~
        // Запишемо правильні відповіді столиць в масив стрінгів - TCapital.
        //
        public string[] TCapital = new string[]
        {
            "Сантьяго", "Дублін", "Осло", "Єреван", "Брюссель",
            "Бухарест", "Доха", "Астана", "Токіо", "Афіни"
        };
        // ~
        // Запишемо неправильні відповіді країн в масив стрінгів - FCapital.
        //
        public string[] FCapital = new string[]
        {
            "Анкара", "Берн", "Рига", "Вільнюс", "Тбілісі",
            "Каїр", "Бейрут", "Черкаси", "Ріо", "Гамбург",
            "Дамаск", "Антананариву", "Маніла", "Тайбей", "Сеул"
        };
    }
}
