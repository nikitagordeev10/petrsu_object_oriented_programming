namespace Pluralize
{
    public static class PluralizeTask
    {
        public static string PluralizeRubles(int count)
        {
            // Напишите функцию склонения слова "рублей" в зависимости от предшествующего числительного count.
            if (count < 10 || count > 20 && count < 100)
            {
                return Answer(count);
            }
            else
            {
                while (true)
                {
                    count %= 100;
                    if (count < 100) break;
                }
                if (count < 10 || count > 20 && count < 100)
                {
                    return Answer(count);
                }
                else
                    return "рублей";
            }
        }

        private static string Answer(int count)
        {
            int remains = count % 10;
            return (remains > 1 && remains < 5) ? "рубля" : ((remains > 4 || remains == 0) ? "рублей" : "рубль");
        }
    }
}