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
        }

        static List<Question> questions = new List<Question>
        {
            new Question
            {
                Ask = "What index does an array start at in C#?",
                Options = new string[]
                {
                    "0",    //0
                    "1",    //1
                    "0.5",  //2
                    "-0"    //3
                },
                CorrectAnswer = 0
            },  //QuestionOne

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
                 CorrectAnswer = 3
             },  //QuestionTwo

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
                 CorrectAnswer = 2
             }, //QuestionThree
        };

        static int correctCount = 0;
        static string playerName = ""; //empty place holder

        static void Main()
        {
            AskPlayerName();
            PrintQuestions();
        }

        static void AskPlayerName()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter your name: ");
                string playerInput = Console.ReadLine();
                //playerName = Console.ReadLine(); //players name = player input
                
                //is it empty?
                if (string.IsNullOrWhiteSpace(playerInput))
                {
                    Console.WriteLine("Name can not be empty");
                    Console.ReadKey();
                    continue;
                }
                // is it three characters long?
                if (playerInput.Length < 3)
                {
                    Console.WriteLine("name must have at least three characters.");
                    Console.ReadKey();
                    continue;
                }
                //check if they are numbers
                bool isNumber = false;
                foreach (char ABC in playerInput)
                {
                    //abc = each input the player entered
                    if (char.IsDigit(ABC)) //if ABC equals a digit then ....
                    {
                        isNumber = true;
                        break;
                    }
                }
                //if they have numbers then...
                if (isNumber)
                {
                    Console.WriteLine("Name can't contain numbers.");
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
                    //Print Ask              
                    Console.WriteLine(q.Ask);

                    //get length of Options string
                    for (int Op = 0; Op < q.Options.Length; Op++)
                    {
                        //Print Options
                        Console.WriteLine($"{Op + 1}. {q.Options[Op]}");
                    }

                    //get player input
                    Console.Write("Your answer 1, 2, 3 or 4: ");
                    string input = Console.ReadLine(); //player enters answer of 1 2 3 or 4
                    Console.Clear();

                    //try parse: turn input to coice and check choice is equal to the correct answer
                    if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 4)
                    {
                        //if correct
                        if (choice - 1 == q.CorrectAnswer)
                        {
                            correctCount++;
                            Console.WriteLine("Correct!");
                            AnswerResult();
                        }
                        //if not correct
                        else
                        {
                            Console.WriteLine($"Wrong!");
                            AnswerResult();
                        }
                        Console.ReadKey();
                        Console.Clear(); //remove last qestion
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid answer.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            //THE END/FINAL SCORE
            FinalScore();
        }

        static void AnswerResult()
        {
            double scorePercent = ((double)correctCount / questions.Count) * 100;
            Console.WriteLine($"{correctCount} Correct / {questions.Count} Questions.You got {Math.Round(scorePercent)}% Correct");
            Console.WriteLine("Press Any Key for the Next Question!");
        }

        static void FinalScore()
        {
            Console.Clear();
            double finalPercent = ((double)correctCount / questions.Count) * 100;
            Console.WriteLine($"{playerName}'s Score is: ");
            Console.WriteLine($"{correctCount} correct / {questions.Count} Questions");
            Console.WriteLine($"{playerName} got {Math.Round(finalPercent)}% Right"); //Round = rounding to the nearest percent
            Console.WriteLine("Press Any Key To Exit...");
            Console.ReadKey();
        }
    }
}
