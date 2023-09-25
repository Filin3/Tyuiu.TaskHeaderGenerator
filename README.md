# Tyuiu.TaskHeaderGenerator
Автоматический генератор заголовков для заданий Тиу. С автоматическим переносом строк при достижении максимальной длины строки.
<!-- КАК ИСПОЛЬЗОВАТЬ -->
### Как использовать
1. Берём класс из файла TaskHeaderGenerator.cs
2. Создаём его экземпляр и передаём аргументы в конструктор класса
   ```csharp
   TaskHeaderGenerator task = new askHeaderGenerator(
            int sprintNumber, // Номер спринта
            string author, // ФИО
            string group, // Группа
            string theme, // Тема
            int taskNumber, // Номер задания
            int version, // Вариант
            string condition // Условие задания
            )
   ```
3. Для вывода заголовка:
```csharp
task.printHeader();
```
4. Для вывода заголовка с "РЕЗУЛЬТАТ:"
```csharp
task.printHeader();
```
