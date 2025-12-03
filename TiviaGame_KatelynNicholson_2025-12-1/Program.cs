using System;
using System.Linq;
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
        };

        static int correctCount = 0;

        static void Main()
        {
            PrintQuestions();
        }

        static void PrintQuestions()
        {

            //get length of questions
            for (int Qu = 0; Qu < questions.Count; Qu++)
            {
                Question q = questions[Qu];

                //Print Ask              
                Console.WriteLine(q.Ask);

                //get length of Options string
                for (int Op = 0; Op < q.Options.Length; Op++)
                {
                    //Print Options
                    Console.WriteLine($"{Op + 1}. {q.Options[Op]}");
                }

                //get player input
                Console.Write("Your answer: ");
                string input = Console.ReadLine(); //player enters answer of 1 2 3 or 4

                double scorePercent = ((double)correctCount / questions.Count) * 100;

                //try parse: turn input to coice and check choice is equal to the correct answer
                if (int.TryParse(input, out int choice) && choice - 1 == q.CorrectAnswer)
                {
                    correctCount++;
                    Console.WriteLine("Correct!");
                    Console.WriteLine($"Answered Correctly: {scorePercent}%");
                }
                else
                {
                    Console.WriteLine($"Wrong!");
                    Console.WriteLine($"Answered Correctly: {scorePercent}%");
                }
            }

        }
    }
}
