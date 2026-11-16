1) 
а) Name, Score-только публичные и свойство 
б) [JsonInclude]
private int secretCode = 42;

г) тк IsAlive - поле
  1)public bool IsAlive { get; set; } 
  2) var options = new JsonSerializerOptions { IncludeFields = true };
     string json = JsonSerializer.Serialize(p, options);


2)
а)public class Game
{
    public string Title {get; set;}
    public int Year {get; set;}
    public double Rating {get; set;}
    public string[] Genres {get; set; } 
    public bool IsMultiplayer {get; set;}
}
б) Важен регистр букв а предложение var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };


в) да, object[], List<object>

3)
a) 
  1)File - Файл небольшой загрузить его целиком в память будет быстрее и потребует меньше кода
  2)File - Сохранение игры перезаписывает весь предыдущий файл нужна быстрая перезагрузка
  3)FileStream - позволит открыть файл в режиме Append и дописывать строки порциями не нодо загружать всё
  4)File - предоставляет статические методы выполнения этой задачи в две строчки
  5)FileStream - Позволяет переместить указатель внутри файла не загружая и не перезаписывая весь огромны файл


