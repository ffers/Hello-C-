// Допит
Console.Write(" Ваше ім'я?: ");
var name = Console.ReadLine();
Console.Write(" Ваше Призвіще?: ");
var firstname = Console.ReadLine();
Console.Write(" Ваш рік народження?: ");
var year = Console.ReadLine();


Console.Write(" Скільки ти витратив вчора?: ");
double yesturdaypay = Convert.ToDouble(Console.ReadLine());
Console.Write(" Скільки ти витратив сьогодні?: ");
double todaypay = Convert.ToDouble(Console.ReadLine());
Console.Clear(); 

// Вивід анкети:
Console.WriteLine($" {name} {firstname}");

// перевірка повнолітності:
DateTime useryear = new DateTime(int.Parse(year), 1, 1);
if (DateTime.Today.AddYears(-18) > useryear)
    Console.WriteLine (" Повнолітній");
else
    Console.WriteLine (" Неповнолітній");

// Рахуємо суму витрат:
double allpay = yesturdaypay + todaypay; 
Console.WriteLine($" Сума витрат за два дні: {allpay}.");





