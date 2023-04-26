/*using System.Linq;

string[] s = new string[2] { "1", "2" };


 
const string[] word = s;


User1 user = new User1();

user.Name = "Test";
user.Id = 1;

// ==================================================================== //


Struct struct2 = new Struct();
struct2.Name = "asad";
struct2.Id = 2;


*//*
struct2.Id = 2;
struct2.Name = "Test";
*//*



class User1
{
    public int Id { get; set; }
    public string Name { get; set; }

    *//*   public int Id;
       public string Name;
   *//*
    public User1(int id, string name)
    {
        Id = id;
        Name = name;
    }
}



struct Struct
{
    public int Id;
    public readonly  string Name = "salom";

    public Struct(int id, string name)
    {
        Id = id;
        Name = name;
    }

    *//*  public int Id { get; set; }
      public string Name { get; set; }*//*
}
*/

using System.Threading.Tasks;

Console.WriteLine("Nimadur O'zgardi!");
string[] strArr = { "qwer", "Alaska", "Dad", "Peace" };

var list = new List<string>();

Solution solution = new Solution();

foreach (var item in solution.Keyboard(strArr))
{
    list.Add(item);
}


foreach (var item in list)
{
    Console.WriteLine(item);
}


class Solution
{
    public string[] Keyboard(string[] str)
    {
        char[] line1 = { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
        char[] line2 = { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' };
        char[] line3 = { 'z', 'x', 'c', 'v', 'b', 'n', 'm' };

        var list = new List<string>();

        for (int i = 0; i < str.Length; i++)
        {
            var str1 = str[i];

            int line11 = 0;
            int line22 = 0;
            int line33 = 0;

            for (int j = 0; j < str1.Length; j++)
            {
                if (HasCharValue(line1, char.ToLower(str1[j])))
                    line11++;

                if (HasCharValue(line2, char.ToLower(str1[j])))
                    line22++;

                if (HasCharValue(line3, char.ToLower(str1[j])))
                    line33++;
            }

            if (line11 == str1.Length)
                list.Add(str1);

            if (line22 == str1.Length)
                list.Add(str1);

            if (line33 == str1.Length)
                list.Add(str1);
        }

        string[] finalArr = new string[list.Count];

        for (int i = 0; i < list.Count; i++)
        {
            finalArr[i] = list[i];
        }

        return finalArr;
    }

    public bool HasCharValue(char[] chars, char target)
    {
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] == target)
                return true;
        }
        return false;
    }
}