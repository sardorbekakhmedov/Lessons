
string word = "salom men 1992 11 2199gs;rjfiuaehrbvihlrwbvhkjlhvubi6736826736827635hjffdtdftykggyfchv";


int num = word.IsDigitCount(word);

Console.WriteLine(num);


public static class StringExtensions
{
    public static int IsDigitCount(this string value1, string value)
    {
        int countNumber = 0;

        for (int i = 0; i < value.Length; i++)
        {
            if (char.IsDigit(value[i]))
                countNumber++;
        }

        return countNumber;
    }
}
