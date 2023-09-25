# Tyuiu.TaskHeaderGenerator
<!-- КАК ИСПОЛЬЗОВАТЬ -->
### Как использовать
1. Берём класс из файла TaskHeaderGenerator.cs
2. Создаём его экземпляр и передаём аргументы в конструктор класса
   ```csharp
   TaskHeaderGenerator task = new askHeaderGenerator(
            int sprintNumber,
            string author,
            string group,
            string theme,
            int taskNumber,
            int version,
            string condition
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
