using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealing
{
    public static class Game
    {
        //player name
        public static string playerName;




        //print out title and intro
        public static void StartGame()
        {
            Console.WriteLine("Welcome to 'Dealing' the Text Adventure!");
            Console.ReadLine();
            Console.Clear();
        }

        //ask player for name and save it
        public static void NameCharacter()
        {
            Console.WriteLine("Please enter your name: ");
            playerName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("So " + playerName + ", today is a very important day, because today is your first day at university.\n" +
                "Your first day is the easiest time to make new friends, but most importantly... To get customers!");
            Console.ReadLine();
        }
        //dialog text changes
        public static void Dialog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(message);
            Console.ResetColor();
        }

    }

    class ChanceRoll
    {
        public int RollChance(Random playerRnd)
        {
            int roll = playerRnd.Next(1, 10);
            return roll;
        }
    }

    public static class Scenes
    {
        //drug list
        static int weed = 3;
        static int hash = 0;
        static int mushrooms = 0;
        static int speed = 0;
        static int MDMA = 0;
        static int Acid = 0;
        static int Ketamine = 0;
        static int Cocaine = 0;
        static int Heroin = 0;
        public static Random rnd = new Random();

        //Phone Numbers
        static bool James = true;
        static bool Shelly = false;
        static bool Dan = false;
        static bool Dave = false;

        //cash
        static float cash = 250;

        static string state;
        static int sold = 0;

        static bool calm = false;
        static bool run = false;
        static bool confess = false;

        //Scenes
        public static void S01()
        {
            string input = "";
            bool option = true;
            while (option)
            {
                option = false;
                Console.WriteLine("Inventory\nWeed:" + weed);
                Console.WriteLine("\n");
                Console.WriteLine("As you're on your way to your university introduction talk, you see a first-year girl.\n" +
                    "She looks lost and confused, what do you do?\n\nA) Approach Her \tB) Keep Walking");
                input = Console.ReadLine().ToUpper();
                Console.Clear();

                if (input == "A")
                {
                    bool option2 = true;
                    while (option2)
                    {
                        option2 = false;
                        Console.WriteLine("You slow down as you approach her, clearing your throat to get her attention you say:\n" +
                        "A) Hi, are you looking for the introduction talk?\nB) Hey, wanna buy some drugs?");
                        input = Console.ReadLine().ToUpper();

                        if (input == "A")
                        {
                            Console.WriteLine("Girl: ");
                            Game.Dialog("Hello, yes I am, but I'm a bit lost...\n");
                            Console.WriteLine("You offer to let her come with you as you know the way\n" +
                                "You walk together to the introduction talk.");
                            Console.ReadKey();
                            Console.Clear();
                            goto end;

                        }
                        if (input == "B")
                        {
                            ChanceRoll option2Chance = new ChanceRoll();
                            int roll = option2Chance.RollChance(rnd);
                            if (roll >= 6)
                            {
                                Game.Dialog("Erm, well I only smoke weed.. And I'm new to town so a dealer would be good\n");
                                Console.WriteLine("She gives you her phone number and says her name is Shelly");
                                Console.WriteLine("She passes you a £10 note and you hand over a slightly less than 1 gram baggie of weed");
                                Shelly = true;
                                weed--;
                                cash += 10;
                                goto end;

                            }
                            if (roll <= 5)
                            {
                                Game.Dialog("What? Hell no! I'm a good girl, my parents told me \"Drugs are bad, mkay\"\n");
                                goto end;
                            }

                            goto end;
                        }
                        else
                        {
                            Console.WriteLine("Please choose either A or B\n");
                            option2 = true;
                            Console.Clear();
                        }
                    }
                }
                if (input == "B")
                {
                    Console.WriteLine("You ignore her and keep walking");
                    break;
                }
                else
                {
                    Console.WriteLine("Please choose either A or B\n");
                    option = true;
                    Console.Clear();

                }
            end:
                Console.WriteLine("You receive a text message reminding you that your rent of £90 is due in 3 days");
                Console.WriteLine("As you are walking you quickly check your stash:");
                Console.WriteLine("Inventory\nWeed:" + weed);
                break;

            }

        }
        public static void S02()
        {
            string input = "";
            bool option = true;
            while (option)
            {
                option = false;

                Console.WriteLine("You make it to the introduction talk and sit next to you next to James, your dealer-friend\n" +
                    "The introduction talk is very boring and you soon start talking to James about drugs, he says he's carrying");
                Console.WriteLine("Do you want to buy anything?\nA) Yes\tB)No");
                input = Console.ReadLine().ToUpper();
                if (input == "A")
                {
                    int dealerWeed = 8;
                    int dealerMush = 3;
                    int dealerMDMA = 2;
                    bool option2 = true;
                    while (option2)
                    {
                        option2 = false;
                        int drugInput;




                        Game.Dialog("Nice one. This is what I've got:\n");
                        Console.WriteLine("You have: £" + cash);
                        Console.WriteLine("A) Weed: {0} grams: £7 p/gram\nB) Mushrooms: {1} grams: £2 p/gram\nC) MDMA: {2} grams: £40p/gram\nD) Exit\n", dealerWeed, dealerMush, dealerMDMA);
                        input = Console.ReadLine().ToUpper();

                        switch (input)
                        {
                            case "A":
                                Console.WriteLine("How Much?");
                                drugInput = int.Parse(Console.ReadLine());
                                int check1 = dealerWeed - drugInput;

                                if (check1 < 0)
                                {
                                    Game.Dialog("Sorry mate, I don't have that much");
                                    break;
                                }

                                weed += drugInput;
                                float total1 = drugInput * 7;
                                cash -= total1;
                                dealerWeed -= drugInput;

                                Console.WriteLine("You now have " + weed + "grams of weed");
                                Console.WriteLine("£" + cash);
                                break;

                            case "B":
                                Console.WriteLine("How Much?");
                                drugInput = int.Parse(Console.ReadLine());
                                int check2 = dealerMush - drugInput;

                                if (check2 < 0)
                                {
                                    Game.Dialog("Sorry mate, I don't have that much");
                                    break;
                                }

                                mushrooms += drugInput;
                                float total2 = drugInput * 2;
                                cash -= total2;
                                dealerMush -= drugInput;

                                Console.WriteLine("You now have " + mushrooms + "grams of mushrooms");
                                Console.WriteLine("£" + cash);
                                break;

                            case "C":
                                Console.WriteLine("How Much?");
                                drugInput = int.Parse(Console.ReadLine());
                                int check3 = dealerMDMA - drugInput;

                                if (check3 < 0)
                                {
                                    Game.Dialog("Sorry mate, I don't have that much");
                                    break;
                                }

                                MDMA += drugInput;
                                float total3 = drugInput * 40;
                                cash -= total3;
                                dealerMDMA -= drugInput;

                                Console.WriteLine("You now have " + MDMA + "grams of MDMA");
                                Console.WriteLine("£" + cash);
                                break;

                            case "D":
                                Game.Dialog("A'ight pal, see ya later, call if you need me");
                                break;
                            default:
                                Console.WriteLine("Please choose A, B, C or D");
                                break;

                        }
                        Game.Dialog("Want to buy more?\n");
                        Console.WriteLine("A) Yes!\tB)Nope");
                        input = Console.ReadLine().ToUpper();
                        switch (input)
                        {
                            case "A":
                                option2 = true;
                                break;
                            case "B":
                                break;
                            default:
                                Console.WriteLine("Please choose A or B");
                                break;
                        }
                    }
                }
                if (input == "B")
                {
                    Game.Dialog("ring if ya want more\n");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Please choose either A or B\n");
                    option = true;
                    Console.Clear();
                }
            }
            
        }
        public static void S03()
        {
            string input = "";
            bool option = true;
            while (option)
            {
                option = false;
                {
                    Console.Write("L"); System.Threading.Thread.Sleep(500);
                    Console.Write("A"); System.Threading.Thread.Sleep(500);
                    Console.Write("T"); System.Threading.Thread.Sleep(500);
                    Console.Write("E"); System.Threading.Thread.Sleep(500);
                    Console.Write("R"); System.Threading.Thread.Sleep(500);
                    Console.Write("."); System.Threading.Thread.Sleep(500);
                    Console.Write("."); System.Threading.Thread.Sleep(500);
                    Console.Write("."); System.Threading.Thread.Sleep(1000);
                    Console.Clear();

                    Console.WriteLine("You find yourself in a student club, the music is deafeningly loud, the smell of alcohol sticks in your nose and everyone is drunkenly dancing and stumbling around. You are talking to an extreamly drunk guy. He's talking about MDMA, he slurs the words out:");
                    Game.Dialog("Y'know whut mate.. I'd bloody kill for some fuckin Mandy!\n");
                    Console.WriteLine("~~That's MDMA if you did not know.. You idoit~~");
                    Console.WriteLine("You reply:");
                    if (MDMA > 0)
                    {
                        Console.WriteLine("A) I've got some, £60 and it's yours \tB) I think you're too drunk for MDMA \tC)Shame I don't have any");
                        input = Console.ReadLine().ToUpper();
                        switch (input)
                        {
                            case "A":
                                Game.Dialog("OMG!!1!, yes please!\n");
                                Console.WriteLine("You make the deal and he gives you his number, his name is Dan");
                                Console.WriteLine("You watch him stumble to the bathroom, presumbly to take his MDMA.");
                                Dan = true;
                                sold = 1;
                                MDMA--;
                                cash += 60;
                                Console.WriteLine("Total £" + cash);
                                break;
                            case "B":
                                Game.Dialog("Wha.. Nah, you are NEVER too drunk for MDMA\n");
                                Console.WriteLine("He says, as he stumbles and almost falls over, catching himself at the last moment");
                                break;
                            case "C":
                                Game.Dialog("Tha*HIC* that is a shame...\n");
                                Console.WriteLine("You awkwardly shuffle away ");
                                break;
                            default:
                                Console.WriteLine("Please choose A, B or C");
                                break;
                        }
                    }


                    else
                    {
                        Console.WriteLine("A) If I had some I'd sell it to you \tB) I think you're too drunk for MDMA");
                        input = Console.ReadLine().ToUpper();
                        switch (input)
                        {
                            case "A":
                                Game.Dialog("That's sad, if you get some in the future, call me\n");
                                Console.WriteLine("He gives you his number and his name is Dan");
                                Dan = true;

                                break;
                            case "B":
                                Game.Dialog("Wha.. Nah, you are NEVER too drunk for MDMA\n");
                                Console.WriteLine("He says, as he stumbles and almost falls over, catching himself at the last moment");
                                break;

                            default:
                                Console.WriteLine("Please choose A, B or C");
                                break;
                        }

                    }
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("It's 12:32AM, and you've got a 9AM Lecture tommorrow, what do you do now?");
                    Console.WriteLine("A) Go home and sleep \tB) Keep drinking \tC) Keep drinking and buy a Maccy's ");
                    input = Console.ReadLine().ToUpper();
                    switch (input)
                    {
                        case "A":
                            Console.WriteLine("You walk home and get a good nights rest");
                            break;

                        case "B":
                            Console.WriteLine("You get quite drunk, get home around 3 or 4AM, and spent £40");
                            cash -= 40;
                            break;
                        case "C":
                            Console.WriteLine("You get quite drunk, get home around 4 or 5AM, and spent £50");
                            cash -= 50;
                            break;

                        default:
                            Console.WriteLine("Please choose A, B or C");
                            break;
                    }
                    if (input == "A")
                    {
                        state = "well rested";
                    }
                    if (input == "B")
                    {
                        state = "hungover";
                    }
                    if (input == "C")
                    {
                        state = "hungover";
                    }
                }
            }
        }
        public static void S04()
        {
            string input = "";
            bool option = true;
            while (option)
            {
                option = false;
                cash -= 90;
                Console.WriteLine("You wake up feeling {0}", state);
                Console.WriteLine("You check your inventory");
                Console.WriteLine("Cash £" + cash);
                Console.WriteLine("Weed: {0}\nMushrooms: {1}\nMDMA: {2}\n", weed, mushrooms, MDMA);
                Console.WriteLine("What do you do:");
                Console.WriteLine("A) Go back to bed B) Check your phone C) Go to lecture");
                input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "A":
                        Console.WriteLine("You roll over and fall asleep");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("You wake up 1 hour later, it's 9:45AM, you've missed half your lecture, get go anyway because you need to sign the register.");
                        if (sold == 1)
                        {
                            ChanceRoll option2Chance = new ChanceRoll();
                            int roll2 = option2Chance.RollChance(rnd);
                            if (roll2 >= 1)
                            {
                                goto arrest;
                            }
                        }
                        
                        goto lectureDeal;

                    case "B":
                        Console.WriteLine("You see some notifcations, check them?\nA) Yes\tB) No");
                        input = Console.ReadLine().ToUpper();
                        ///
                        switch (input)
                        {
                            case "A":
                                Console.WriteLine("You read the first notification, it says that £90 direct debit was paid for rent\n Cash = £" + cash);
                                if (sold == 1)
                                {
                                    ChanceRoll option2Chance = new ChanceRoll();
                                    int roll2 = option2Chance.RollChance(rnd);
                                    if (roll2 >= 1)
                                    {
                                        Console.WriteLine("You read the second notification, it's breaking news!\nIt reads:");
                                        Console.WriteLine("Last night a young university student was found dead by the side of the road.\nIt appears that the student likely died from MDMA and alcohol abuse,\n our prayers go out to the students friends \nand family\nOfficals have now released the students name. His name was Daniel, more known by as Dan.\nIf anyone has any information about his death please contact us\n");

                                        Console.WriteLine("You feel sick with guilt and slowly walk to your lecture, hanging your head low");
                                        Console.ReadKey();
                                        Console.Clear();

                                        Console.WriteLine("As you enter the university building, you're stopped by a security member, and he radios to someone else");
                                        Game.Dialog("Hold up lad, we'd like to ask you some questions\n");
                                        Console.WriteLine("Standing in the university lobby, you watch as 3 police officers and university security make their way to you menacingly. One of the officers says:");
                                        Game.Dialog("Right then boy, your coming with us to the station, we have some questions we think you can answer\n");
                                        Console.WriteLine("What do you do?\nA) Go calmly\tB) Make a run for it \tC) Break down and confess");
                                        input = Console.ReadLine().ToUpper();
                                        switch (input)
                                        {
                                            case "A":
                                                Console.WriteLine("You calmly walk with the officers to their vehicle and drive to the station");
                                                calm = true;
                                                Scenes.S05();
                                                break;
                                            case "B":
                                                Console.WriteLine("You stand there for a second, before suddenly bolting through the doors and outside, hoping to escape. The officers don't take long to follow suit and before you know it your on the ground convulsing as waves of electricity shoot though your body, temporally disabling you. As you lay on the floor in agony you are cuffed and dragged to the police vehicle");
                                                run = true;
                                                Scenes.S05();
                                                break;
                                            case "C":
                                                Console.WriteLine("You start crying hystarically and confess that you are responsible for Dan's death, the officers quickly cuff you and drag you away, leaving a trail of tears");
                                                confess = true;
                                                Scenes.S05();
                                                break;
                                            default:
                                                Console.WriteLine("Choose A, B or C");

                                                break;

                                        }
                                    }
                                }
                                break;
                            case "B":
                                Console.WriteLine("You ignore them and make your to your lecture, just on time");
                                if (sold == 1)
                                {
                                    ChanceRoll option2Chance = new ChanceRoll();
                                    int roll2 = option2Chance.RollChance(rnd);
                                    if (roll2 >= 1)
                                    {
                                        goto arrest;
                                    }
                                }
                                break;


                            default:
                                Console.WriteLine("Choose A or B");
                                break;

                        }
                        ///
                        break;
                    case "C":
                        Console.WriteLine("You quickly get dressed and head off to your 9AM lecture, eating toast on the way to save time");
                        if (sold == 1)
                        {
                            ChanceRoll option2Chance = new ChanceRoll();
                            int roll2 = option2Chance.RollChance(rnd);
                            if (roll2 >= 1)
                            {
                                goto arrest;
                            }
                        }
                        goto lectureDeal;

                }
            arrest:

                Console.WriteLine("As you enter the university building, you're stopped by a security member, and he radios to someone else");
                Game.Dialog("Hold up lad, we'd like to ask you some questions\n");
                Console.WriteLine("Standing in the university lobby, you watch as 3 police officers and university security make their way to you menacingly. One of the officers says:");
                Game.Dialog("Right then boy, your coming with us to the station, we have some questions we think you can answer\n");
                Console.WriteLine("What do you do?\nA) Go calmly\tB) Make a run for it \tC) Break down and confess");
                input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "A":
                        Console.WriteLine("You calmly walk with the officers to their vehicle and drive to the station");
                        calm = true;
                        Scenes.S05();
                        break;
                    case "B":
                        Console.WriteLine("You stand there for a second, before suddenly bolting through the doors and outside, hoping to escape. The officers don't take long to follow suit and before you know it your on the ground convulsing as waves of electricity shoot though your body, temporally disabling you. As you lay on the floor in agony you are cuffed and dragged to the police vehicle");
                        run = true;
                        Scenes.S05();
                        break;
                    case "C":
                        Console.WriteLine("You start crying hystarically and confess that you are responsible for Dan's death, the officers quickly cuff you and drag you away, leaving a trail of tears");
                        confess = true;
                        Scenes.S05();
                        break;
                    default:
                        Console.WriteLine("Choose A, B or C");

                        
                        break;
                }
            lectureDeal:
                Console.WriteLine("You get to your lecture and sit through the damn thing, bored to tears.\n As the lecture ends the lecturer asks you to stay behind to talk");
                Console.WriteLine("You walk up to Dave the lecturer once everyone has left and ask what he wants");
                Game.Dialog("Hello, I've heard rumours you are selling drugs.. Don't worry I won't tell anyone. I just, erm, need some weed...\n");
                Console.WriteLine("What do you do?:\nA) Laugh and walk away\tB) Tell him it's £15 p/gram for added risk");
                input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "A":
                        Console.WriteLine("You laugh out loud, turn and walk away, as your leaving you see him hang his head low, he's obviously not very happy");
                        break;
                    case "B":
                        Console.WriteLine("He sighs and says:");
                        Game.Dialog("Alright deal, I'll take as much as you can sell, heres my number too\n");
                        Console.WriteLine("You hand over {0} grams of weed", weed);
                        Dave = true;
                        int total = weed * 15;
                        Console.WriteLine("He hands over £" + total);
                        cash += total;
                        weed = 0;
                        Console.WriteLine("As you leave you check what you have left:\n Cash: {0} \nWeed: {1}\nMushrooms: {2}\nMDMA: {3}", cash, weed, mushrooms, MDMA);

                        break;
                    default:
                        Console.WriteLine("Choose A or B");
                        break;
                }




            }


        }
        public static void S05()
        {
            Console.Clear();
            Console.WriteLine("You find yourself in a police questioning room, the table is cold, the paint on the walls is chipped and looks to be many years old, the police officer in front of you is asking questions.. You got to see if you can get out of this");
            Console.ReadKey();
            string input = "";
            bool option = true;
            while (option)
            {
                option = false;
                Console.WriteLine("The officer searches you and finds: \n£{0} \nWeed: {1} \nMushrooms: {2} \nMDMA: {3}", cash, weed, mushrooms, MDMA);

                //Questions
                if (run)
                {
                    Game.Dialog("Why did you run from us?\n");
                    Console.WriteLine("A) Because I was scared\tB) Because I had drugs");
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "A":
                            Game.Dialog("And why was you scared?\n");
                            Console.WriteLine("A) My Dad was cop, he used to beat me\tB) Cops just scare me..");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "A":
                                    Game.Dialog("Oh, okay..\n");
                                    break;
                                case "B":
                                    Game.Dialog("I don't believe you, you were running because you sell drugs\n");
                                    break;
                                default:
                                    Console.WriteLine("Choose A or B");
                                    break;
                            }
                            break;
                        case "B":
                            Game.Dialog("And you sell those drugs?");
                            Console.WriteLine("A) Yes, I sell them \t B) No, it's for personal use");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "A":
                                    Game.Dialog("Did you sell MDMA to Daniel last night?\n");
                                    break;
                                case "B":
                                    

                                    Game.Dialog("Really? Cause we have a witness who says you passed Daniel a bag of something white last night in the club\n");
                                    break;
                                default:
                                    Console.WriteLine("Choose A or B");
                                    break;
                            }
                            break;
                            
                        default:
                            Console.WriteLine("Choose A or B");
                            break;
                    }
                }
            }

        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            Game.StartGame();
            Game.NameCharacter();

            Scenes.S01();
            Scenes.S02();
            Scenes.S03();
            Scenes.S04();


            Console.ReadKey();
        }
    }
}

