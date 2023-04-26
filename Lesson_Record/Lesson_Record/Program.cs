
// Anonymous Class

var user = new { Id = 5, Name = "Ali" };

user = user with { Name = "Vali" };   // Valuesini O'zgartirish


Console.WriteLine( );


// Anonymous Methods

Action<int,int> method1 = (int x, int y) => { Console.WriteLine(x + y); };

Func<string> method2 = () => { return "son"; };  

Func<int, int> method3 = son => { return son; }; // Parametr bitta bo'lsa qavs shart emas

Func<int, string, int> method4 = (son, word) => { return son; };



