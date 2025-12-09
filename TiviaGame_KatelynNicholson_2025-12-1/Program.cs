using System;
using System.Collections.Generic;

namespace TiviaGame_KatelynNicholson_2025_12_1
{
    internal class Program
    {
        //prompt to enter name
        //answer 10 questions
        //answer by 1, 2, 3 or 4. must be 4 choices for every question
        //any other keys not 1, 2, 3, 4 promt choose a proper answer
        //after answering all questions at the end prompt show score 
        //with a message based on performance
        //after final score user is prompt, play again or quit (Y or N)
        //Hud, playerName, current question #, amount guessed right /out of amount answered as a %
        //make it easy to add and remove questions, no hardcoding.
        //loops data structures arrays and lists
        //is your solution scalable
        //no magic numbers
        //methods for common functionality, no duplicated code (if code needs to be written twice stick it in a method
        //EXTRA
        //COLOURS, ASCII art, formatting make it look good
        //add an easter egg? a hidden secret? (include note when submitting if you added an easter egg
       

        //Question Index
        enum QuestionID
        {
            QuestionOne,
            QuestionTwo, 
            QuestionThree, 
            QuestionFour, 
            QuestionFive, 
            QuestionSix, 
            QuestionSeven,
            QuestionEight,
            QuestionNine,
            QuestionTen,
        }

        //blueprint "class"
        class Question
        {
            public string Ask;    //Question
            public string[] Options;  //multiple choice
            public int CorrectAnswer; //where the right answer is stored
            public QuestionID ID; //store the enum number
        }

        static List<Question> questions = new List<Question>
        {
            new Question
            {
                Ask = "What index does an array start at in C#?",
                Options = new string[]
                {
                    "0", //0
                    "1", //1
                    "0.5", //2
                    "-0"  //3
                },
                CorrectAnswer = 0,
                ID = QuestionID.QuestionOne,
            },

             new Question
             {
                 Ask = "what operator checks two conditions at the same time?",
                 Options = new string[]
                 {
                     "||", //0
                     "<=", //1
                     "==", //2
                     "&&" //3
                 },
                 CorrectAnswer = 3,
                 ID = QuestionID.QuestionTwo,
             },  

             new Question
             {
                 Ask = "What does Mathf.Abs do?",
                 Options = new string[]
                 {
                     "Stops a value from going below or above a set value.", //0
                     "Gives you Math tools.", //1
                     "Ditects how far a number is from zero, no matter the direction.", //2
                     "Checks the distance between two values" //3
                 },
                 CorrectAnswer = 2,
                 ID = QuestionID.QuestionThree,
             }, 

             new Question
             {
                 Ask = "Your score shows 33.3333333333333%. Which method would you use to fix this?", //this was a problem i came across too lol 
                 Options = new string[]
                 {
                     "Ceil", //0
                     "Round", //1
                     "Lerp", //3
                     "Floor" //4
                 },
                 CorrectAnswer = 1,
                 ID = QuestionID.QuestionFour,
             },
             
             new Question
             {
                 Ask = "What does Console.Clear() do?",
                 Options = new string[]
                 {
                     "Clears the console screen", //0
                     "Closes the program", //1
                     "Resets variables", //3
                     "Empties your trash bin" //4
                 },
                 CorrectAnswer = 0,
                 ID = QuestionID.QuestionFive,
             },

             new Question
             {
                 Ask = "What is the default value of a bool in C#?",
                 Options = new string[]
                 {
                     "null", //0
                     "true", //1
                     "0", //2
                     "false" //3
                 },
                 CorrectAnswer = 3,
                 ID = QuestionID.QuestionSix,
             },

             new Question
             {
                 Ask = "Where in this line of code would you put Debug.Log?: int score = 10 + 3;",
                 Options = new string[]
                 {
                     "Before the equals sign", //0
                     "You can't put Debug.Log here in a normal C# console program, it's Unity specific.", //1
                     "After the semicolon", //2
                     "Captains.Log(855); //They have all officially lost their minds" //3
                 },
                 CorrectAnswer = 1, //and Captains.Log(855);
                 ID = QuestionID.QuestionSeven,
             },

             new Question
             {

             }
        };

        static int correctCount = 0;
        static string playerName = ""; //empty place holder

        static void Main()
        {
            bool playAgain = true;
            while (playAgain)
            {
                AskPlayerName();
                PrintQuestions();

                playAgain = PlayAgain();
            }
        }

        static void AskPlayerName()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("╔════════════════════════════╗");
                Console.WriteLine("      Enter your name: ");
                Console.WriteLine("╚════════════════════════════╝");
                Console.ResetColor();
                string playerInput = Console.ReadLine();
                Console.Clear();
                //playerName = Console.ReadLine(); //players name = player input
                
                //is it empty?
                if (string.IsNullOrWhiteSpace(playerInput))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("╔═══════════════════════════╗");
                    Console.WriteLine("   Name can not be empty");
                    Console.WriteLine("╚═══════════════════════════╝");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }
                // is it three characters long?
                if (playerInput.Length < 3)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("╔════════════════════════════════════════════╗");
                    Console.WriteLine("  name must have at least three characters.");
                    Console.WriteLine("╚════════════════════════════════════════════╝");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }
                //check if they are 
                bool isLetter = false;
                foreach (char ABC in playerInput)
                {
                    //abc = each input the player entered
                    if (!char.IsLetter(ABC)) //if ABC doesnt equal Letter then .... //isDigit didnt stop things like: .,"/({
                    {
                        isLetter = true;
                        break;
                    }
                }
                //if they dont have letters then...
                if (isLetter)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("╔═════════════════════════════╗");
                    Console.WriteLine("  Name can't contain numbers.");
                    Console.WriteLine("╚═════════════════════════════╝");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue; 
                }

                playerName = playerInput;
                break;
            }
        }

        static void PrintQuestions()
        {
            //get length of questions
            for (int Qu = 0; Qu < questions.Count; Qu++)
            {
                Question q = questions[Qu];

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════╗");
                    //Print Ask              
                    Console.WriteLine($"  {(int)q.ID + 1}. {q.Ask}");
                    Console.WriteLine();//add space between questions and answere

                    //get length of Options string
                    for (int Op = 0; Op < q.Options.Length; Op++)
                    {
                        //Print Options
                        Console.WriteLine($"  {Op + 1}. {q.Options[Op]}");
                    }
                    Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════╝");
                    Console.ResetColor();

                    //get player input
                    Console.Write("Your answer 1, 2, 3 or 4: ");
                    string input = Console.ReadLine(); //player enters answer of 1 2 3 or 4
                    Console.Clear();

                    //try parse: turn input to coice and check choice is equal to the correct answer
                    if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 4) // >= 1 && <=4 means the answer needs to be 1,2,3 or 4
                    {
                        //if correct
                        if (choice - 1 == q.CorrectAnswer)
                        {
                            correctCount++;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Correct!");
                            Console.ResetColor();
                            AnswerResult(q.ID);
                        }
                        //if not correct
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Wrong!");
                            Console.ResetColor();
                            AnswerResult(q.ID);
                        }
                        Console.ReadKey();
                        Console.Clear(); //remove last qestion
                        break;
                    }
                    else //if anything other than 1,2,3 or 4 is entered
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("╔═════════════════════════════╗");
                        Console.WriteLine("  Please enter a valid answer.");
                        Console.WriteLine("╚═════════════════════════════╝");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            //THE END/FINAL SCORE
            FinalScore();
        }

        static string PerformanceMessage(double percent)
        {
            if (percent == 100) return "Look at you, all smart and stuff!";
            else if (percent >= 80) return "Amazing, You did so well!";
            else if (percent >= 50) return "Not bad! keep practicing!";
            else return "Better Luck Next time! Keep Trying.";
        }

        static void AnswerResult(QuestionID id)
        {
            double scorePercent = ((double)correctCount / questions.Count) * 100; 
            Console.WriteLine($"Current Question #: {(int)id + 1}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("╔═════════════════════════════════════════════╗");
            Console.WriteLine($"  {correctCount} Correct / {questions.Count} Questions.You got {Math.Round(scorePercent)}% Correct");
            Console.WriteLine($"  {PerformanceMessage(scorePercent)}");
            Console.WriteLine("╚═════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine("  Press Any Key for the Next Question!");

        }

        //"HUD"
        static void FinalScore()
        {
            Console.Clear();
            double finalPercent = ((double)correctCount / questions.Count) * 100;
            Console.WriteLine($"  {playerName}'s your Score is: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("╔═════════════════════════════════════════════════╗");
            Console.WriteLine($"  {correctCount} correct / {questions.Count} Questions");
            Console.WriteLine($"  {playerName} you got {Math.Round(finalPercent)}% Right!"); //Round = rounding to the nearest percent
            Console.WriteLine($"  {PerformanceMessage(finalPercent)}");
            Console.WriteLine("╚═════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine("  Press Any Key To Continue...");
            Console.ReadKey();
        }

        static bool PlayAgain()
        {
            while (true)
            {
                Console.ForegroundColor= ConsoleColor.Blue;
                Console.WriteLine("╔════════════════════╗");
                Console.WriteLine("  PlayAgain? Y/N: ");
                Console.WriteLine("╚════════════════════╝");
                Console.ResetColor();
                string input = Console.ReadLine()?.Trim().ToUpper(); //player input

                if(input == "Y")
                {
                    correctCount = 0; //reset score
                    return true; //restart game
                }
                else if (input == "N")
                {
                    return false; //exit game
                }
                else
                {
                    Console.ReadKey();
                }
            }
        }
    }
}
