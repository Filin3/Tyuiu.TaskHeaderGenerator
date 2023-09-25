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
            Console.Title = $"Спринт #{this.sprintNumber} | Выполнил: {this.author} | {this.group}";
            Console.WriteLine($"" +
                $"{this.getFulledSeparator()}\n" +
                $"{this.addDecoration($"Спринт #{this.sprintNumber}")}\n" +
                $"{this.addDecoration($"Тема: {this.theme}")}\n" +
                $"{this.addDecoration($"Задание #{this.taskNumber}")}\n" +
                $"{this.addDecoration($"Вариант #{this.version}")}\n" +
                $"{this.addDecoration($"Выполнил {this.author} | {this.group}")}\n" +
                $"{this.getFulledSeparator()}\n" +
                $"{this.addDecoration("УСЛОВИЕ:")}\n" +
                $"{this.addDecoration(this.condition)}\n" +
                $"{this.getEmptySeparator()}\n" +
                $"{this.getFulledSeparator()}\n" +
                $"{this.addDecoration("ИСХОДНЫЕ ДАННЫЕ:")}\n" +
                $"{this.getFulledSeparator()}"
                );
        }

        public void printFooter()
        {
            Console.WriteLine(
                $"{this.getFulledSeparator()}\n" +
                $"{this.addDecoration("РЕЗУЛЬТАТ:")}\n" +
                $"{this.getFulledSeparator()}"
                );
        }

        private string addDecoration(string line)
        {
            string lineStart = "* ";
            string lineEnd = " *";

            string result;

            if (calculateLineLength(line) <= this.maxLineLenght)
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
                        if (calculateLineLength(tempLine) <= this.maxLineLenght)
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

            string decorateLine(string line)
            {
                string extendString = new String(' ', this.maxLineLenght - calculateLineLength(line));
                return lineStart + line + extendString + lineEnd;
            }

            int calculateLineLength(string line)
            {
                return lineStart.Length + line.Length + lineEnd.Length;
            }
        }

        private string getFulledSeparator()
        {
            return new String('*', this.maxLineLenght);
        }

        private string getEmptySeparator()
        {
            return this.addDecoration(" ");
        }
    }
