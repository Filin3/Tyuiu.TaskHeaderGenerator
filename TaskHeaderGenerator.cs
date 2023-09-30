using System;
using System.Collections.Generic;
using System.Linq;

namespace taskNameGenerator
{
    class TaskHeaderGenerator
    {
        private int sprintNumber;
        private string author;
        private string group;
        private string theme;
        private int taskNumber;
        private int version;
        private string condition;

        private int maxLineLenght = 75;
        private string lineStart = "* ";
        private string lineEnd = " *";

        public TaskHeaderGenerator(
            int sprintNumber,
            string author,
            string group,
            string theme,
            int taskNumber,
            int version,
            string condition
            )
        {
            this.sprintNumber = sprintNumber;
            this.author = author;
            this.group = group;
            this.theme = theme;
            this.taskNumber = taskNumber;
            this.version = version;
            this.condition = condition;
        }

        public void printHeader()
        {
            Console.Title = $"Спринт #{sprintNumber} | Выполнил: {author} | {group}";
            Console.WriteLine($"" +
                $"{getFulledSeparator()}\n" +
                $"{addDecoration($"Спринт #{sprintNumber}")}\n" +
                $"{addDecoration($"Тема: {theme}")}\n" +
                $"{addDecoration($"Задание #{taskNumber}")}\n" +
                $"{addDecoration($"Вариант #{version}")}\n" +
                $"{addDecoration($"Выполнил {author} | {group}")}\n" +
                $"{getFulledSeparator()}\n" +
                $"{addDecoration("УСЛОВИЕ:")}\n" +
                $"{addDecoration(condition)}\n" +
                $"{getEmptySeparator()}\n" +
                $"{getFulledSeparator()}\n" +
                $"{addDecoration("ИСХОДНЫЕ ДАННЫЕ:")}\n" +
                $"{getFulledSeparator()}"
                );
        }

        public void printFooter()
        {
            Console.WriteLine(
                $"{getFulledSeparator()}\n" +
                $"{addDecoration("РЕЗУЛЬТАТ:")}\n" +
                $"{getFulledSeparator()}"
                );
        }

        private string addDecoration(string line)
        {
            string result;

            if (calculateLineLength(line) <= maxLineLenght)
            {
                result = decorateLine(line);
            } else
            {
                List<string> words = line.Split(' ').ToList();
                List<string> resultList = new List<string>();

                while (words.Count > 0)
                {
                    string currentLine = "";

                    foreach (string word in words.ToList())
                    {
                        string tempLine = currentLine != "" ? $"{currentLine} {word}" : word;
                        if (calculateLineLength(tempLine) <= maxLineLenght)
                        {
                            currentLine = tempLine;
                            words.RemoveAt(0);
                        } else
                        {
                            break;
                        }
                    }

                    resultList.Add(decorateLine(currentLine));
                }

                result = String.Join("\n", resultList);
            }

            return result;
        }

        private string decorateLine(string line)
        {
            string extendString = new String(' ', maxLineLenght - calculateLineLength(line));
            return lineStart + line + extendString + lineEnd;
        }

        private int calculateLineLength(string line)
        {
            return lineStart.Length + line.Length + lineEnd.Length;
        }

        private string getFulledSeparator()
        {
            return new String('*', maxLineLenght);
        }

        private string getEmptySeparator()
        {
            return addDecoration(" ");
        }
    }
}
