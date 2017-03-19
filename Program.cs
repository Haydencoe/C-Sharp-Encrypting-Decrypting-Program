//309219
//Hayden Coe
//Assessment 1 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace caeserCipher
{
    class userInterface
    {
        static void Main(string[] args)//Main method contains the user interface.
        {

            int mainMenu = 1;
            while (mainMenu <= 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                string gretting = "Morning";
                int firstChoice = 0;
                int secondChoice = 0;
                int thirdChoice = 0;
                int forthChoice = 0;
                int fifthChoice = 0;

                if (DateTime.Now.ToString("tt") == "PM")//Checks to see if it is the afternoon or not. 
                    gretting = "Afternoon";

                while (firstChoice >= 0)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n*****MAIN MENU*******");
                        Console.ForegroundColor = ConsoleColor.Green;



                        Console.WriteLine("\nGood {0}, please choose an option:(or press q to quit the program.) \n1. Decrypt a message. \n2. Encrypt a message.", gretting);///Gets the user to enter an option.

                        string temp = Console.ReadLine();

                        if (temp == "q")
                        {
                            mainMenu = 2;
                            break;
                        }

                        int.TryParse(temp, out firstChoice);

                        if (firstChoice >= 1 && firstChoice <= 2)//Checks if a valid option has been entered (1/2)
                            break;//Breaks out of while loop if conditions are met.
                        else
                            throw new FormatException();
                    }//End of try statement.

                    catch (FormatException)//Catches the errors.
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nSorry that wasn't a valid option.");//Displays a red warning if an invalid entry is made.
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;


                    }//End of catch statement.
                }//End of while loop. 



                switch (firstChoice)//Encrypt or Decrypt option.
                {
                    case 1://Decrypt a message option.
                        while (secondChoice >= 0)
                        {
                            try
                            {
                                Console.WriteLine("Please choose an option to Decrypt your message (or type 'm' to go back to the main menu) :\n1. Ceaser Cipher Table.  \n2. Frequency Analysis.");
                                string temp = Console.ReadLine();

                                if (temp == "m") break;
                                int.TryParse(temp, out secondChoice);

                                if (secondChoice >= 1 && secondChoice <= 2)
                                    break;
                                else
                                    throw new FormatException();
                            }

                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Beep();
                                Console.WriteLine("\nSorry that wasn't a valid option.");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }

                        break;//Break of case 1

                    case 2://Encrypt a message option.


                        while (thirdChoice >= 0)
                        {
                            try
                            {
                                Console.WriteLine("Please choose an option:(or type 'm' to go back to the main menu) \n1. Encrypt your own message \n2. The message in a .txt file");

                                string temp = Console.ReadLine();

                                if (temp == "m") break;

                                int.TryParse(temp, out thirdChoice);


                                if (thirdChoice >= 1 && thirdChoice <= 2)
                                    break;
                                else
                                    throw new FormatException();
                            }

                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nSorry that wasn't a valid option.");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }//End of while loop.
                        break;//Break for end of case 2

                }//End of switch statement.





                switch (secondChoice)//Decrypt using Caeser cipher table/ frequency analysis.
                {
                    case 1://Decrypt using the Caeser cipher table option.

                        while (forthChoice >= 0)
                        {
                            try
                            {
                                Console.WriteLine("Please choose what you would like to Decrypt using the Caeser Cipher Table:(or type 'm' to go back to the main menu) \n1. The caesarShiftEncoded.txt file \n2. Your own message.");
                                string temp = Console.ReadLine();

                                if (temp == "m") break;

                                int.TryParse(temp, out forthChoice);

                                if (forthChoice >= 1 && forthChoice <= 2)
                                    break;
                                else
                                    throw new FormatException();
                            }

                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nSorry that wasn't a valid option.");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }//End of while loop.

                        break;//Break for end of case 1

                    case 2://Decrypt using the Ceaser Cipher frequency analysis option.

                        while (fifthChoice >= 0)
                        {
                            try
                            {
                                Console.WriteLine("Please choose what you would like to preform frequency analysis on:(or type 'm' to go back to the main menu) \n1. The caesarShiftEncoded.txt file \n2. Your own message.");
                                string temp = Console.ReadLine();

                                if (temp == "m") break;

                                int.TryParse(temp, out fifthChoice);


                                if (fifthChoice >= 1 && fifthChoice <= 2)
                                    break;
                                else
                                    throw new FormatException();
                            }

                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nSorry that wasn't a valid option.");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                            }

                        }//End of while loop.
                        break;//Break that ends case 2
                }

                switch (thirdChoice)//Encrypt own message or .txt file. 
                {
                    case 1://Own message option.
                        {
                            encryptDecrypt c = new encryptDecrypt();//Makes an instance of the encryptDecrypt class.
                            Console.WriteLine("Please enter the message you would like to encrypt with the Caeser cipher encoding.");//Gets the user to enter their message for encryption.
                            string messageToEncrypt = Console.ReadLine();//Gets the users message

                            string messageToEncryptUpper = messageToEncrypt.ToUpper();//Converts the message to all upper case.
                            messageToEncryptUpper = messageToEncryptUpper.Replace(" ", string.Empty);//Removes all the spaces out of the string.
                            Console.WriteLine("Please enter the key shift you want to apply to your message.");//Gets the user to enter a key shift to apply to their message.
                            int keyShift = int.Parse(Console.ReadLine());//Gets the key shift value.
                            string saveFile = c.letterShift(messageToEncryptUpper, keyShift);//Calls the letterShift method and parses the user's message with their intended keyShift.
                            Console.WriteLine("Your now encrypted message with a keyshift of " + keyShift + " applied:");//Displays a message with the useres inputed keyshift value.
                            Console.WriteLine("\n" + yellowLine(saveFile));//Displays the new encrypted message with a differnt colour.
                            Console.ForegroundColor = ConsoleColor.Green;//Changes the console colour back to green.
                            Console.WriteLine("Press any key to return to main menu");
                            Console.ReadLine();

                        }//End of case 1

                        break;//break of switch case 1.


                    case 2://.txt file option.TODO
                        {

                            int start = 0;
                            //string newPath = "";
                            Console.WriteLine("Please enter the full file name you want to load to apply a ceaser cipher encoding to.");
                            string newPath = Console.ReadLine();




                            while (start >= 0)
                            {
                                try
                                {
                                    Console.WriteLine("\nLoading....");
                                    string lines = File.ReadAllText(newPath);
                                    Console.WriteLine("Load succseful!");
                                    encryptDecrypt c = new encryptDecrypt();

                                    string messageToEncryptUpper = lines.ToUpper();//Converts the message to all upper case.
                                    messageToEncryptUpper = messageToEncryptUpper.Replace(" ", string.Empty);//Removes all the spaces out of the string.
                                    Console.WriteLine("Please enter the key shift you want to apply to your message.");//Gets the user to enter a key shift to apply to their message.
                                    int keyShift = int.Parse(Console.ReadLine());//Gets the key shift value.
                                    string saveFile = c.letterShift(messageToEncryptUpper, keyShift);//Calls the letterShift method and parses the user's message with their intended keyShift.
                                    Console.WriteLine("\nYour now encrypted message with a keyshift of " + keyShift + " applied:");//Displays a message with the useres inputed keyshift value.

                                    Console.WriteLine("\n" + yellowLine(saveFile));//Displays the new encrypted message with a differnt colour.
                                    Console.ForegroundColor = ConsoleColor.Green;//Changes the console colour back to green.
                                    Console.WriteLine("Presss any key to return to main menu");
                                    Console.ReadLine();
                                    break;
                                }

                                catch
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nSorry file could not be Loaded!");
                                    Console.ForegroundColor = ConsoleColor.Green;

                                    Console.WriteLine("\nPlease enter a new path to load from or press m to go to main menu.\n\n");//Gets the user to enter a new location for the save.
                                    newPath = Console.ReadLine();//Gets the user's new file location to save to.
                                    if (newPath == "m")//option to quit to main menu. 
                                        break;
                                }//End of catch

                            }//End of while

                        }//End of case 1
                        break;

                }//End of switch thirdChoice

                switch (forthChoice)
                {
                    case 1:

                        //Descrypts using caeser cipher table on "caeserShiftEncodedText.txt" file
                        string lines = "";
                        try
                        {
                            lines = File.ReadAllText(@"\\srv124\students$\309219\my documents\visual studio 2010\Projects\ConsoleApplication126\ConsoleApplication126\TextFile1.txt");
                                //@"z:\\C# programs\\Assessment 1\\caesarShiftEncodedText.txt");//Reads in the encrypted message.
                        }

                        catch//(FileNotFoundException)
                        {
                            Console.WriteLine("Sorry file could not be found");
                            break;
                        }


                        encryptDecrypt c = new encryptDecrypt();//Makes an instance of the encryptDecrypt class.
                        Console.WriteLine("\nThe decrypted message:");
                        string saveFile = c.ceaserShiftTable(lines);//Defines saveFile as the return of the caeaserShiftTable method
                        Console.WriteLine("\nYour decoded message:\n");
                        Console.WriteLine(yellowLine(saveFile));//Displays the decrypted message.
                        Console.ForegroundColor = ConsoleColor.Green;//Changes the console foreground colour back to green.

                        string newPath = "z:\\C# programs\\Assessment 1\\HaydensCaesarShiftDecodedText.txt";

                        int start = 0;

                        while (start >= 0)//while loop to repeat codeonce a new location has been entered. 
                        {
                            try
                            {
                                File.WriteAllText(newPath, saveFile);//Saves decrypted message to a .txt file. 
                                Console.WriteLine("\n**Decrypted message file saved!**");
                                Console.WriteLine("\nPress any key to return to main menu.");
                                Console.ReadLine();
                                break;
                            }

                            catch//If the file to save to can't be found the error is caught.
                            {

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nSorry file could not be Saved!");
                                Console.ForegroundColor = ConsoleColor.Green;

                                Console.WriteLine("\nPlease enter a new path to save to or press m to go to main menu.\n\n");//Gets the user to enter a new location for the save.
                                newPath = Console.ReadLine();//Gets the user's new file location to save to.
                                if (newPath == "m")//option to quit to main menu. 
                                    break;
                            }

                        }

                        break;//Break for case 1.

                    case 2:
                        //Decrypts using caeser cipher table on own message option.
                        Console.WriteLine("Please enter your message.");//Gets the user to  enter their message to be decrypted.
                        string lower = Console.ReadLine();//Gets the user's encrypted message.
                        string myLines = lower.ToUpper();//Changes all inputed text to uppercase.
                        encryptDecrypt b = new encryptDecrypt();//Makes an instance of the encrypDecrypt class.
                        string newSaveFile = b.ceaserShiftTable(myLines);//Calls the caeserShiftTable method parses the message then defines the newSaveFile as the return.
                        Console.WriteLine("\nYour decoded message:\n");
                        Console.WriteLine(yellowLine(newSaveFile));//Calls the different colour method.
                        Console.ForegroundColor = ConsoleColor.Green;//Changes the console colour back to green.
                        break;
                }

                switch (fifthChoice)
                {

                    case 1://Calls frequency analysis on caserShiftEncoded.txt

                        Console.WriteLine("Encrypted message:\n\n");
                        string lowerCase = System.IO.File.ReadAllText(@"z:\\C# programs\\Assessment 1\\caesarShiftEncodedText.txt");


                        string lines = lowerCase.ToUpper();
                        Console.WriteLine(lines);//Displays the encrypted message.
                        lines = lines.Replace(" ", string.Empty);//Removes all the spaces out of the string.
                        lines = lines.Replace("\r", string.Empty);//Removes all the carridge returns out of the string
                        lines = lines.Replace("\n", string.Empty);//Removes all the new lines out of the string
                        encryptDecrypt b = new encryptDecrypt();//Makes an instance of the encryptDecrypt class.
                        b.frequencyAnalysis(lines);
                        break;

                    case 2://Calls frequency analysis for own message.

                        Console.WriteLine("Please enter your message to preform a caeser shift frequency analysis on.");
                        string ownMessage = Console.ReadLine();
                        string ownMessageUpper = ownMessage.ToUpper();
                        ownMessageUpper = ownMessageUpper.Replace(" ", string.Empty);
                        encryptDecrypt c = new encryptDecrypt();
                        c.frequencyAnalysis(ownMessageUpper);
                        break;
                }
            }//End of switch statement.


        }//End of mainMenu while loop.
        //End of Main method.



        static public string yellowLine(string value)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Console.ResetColor();

            return value;
        }


    }//End of unserInterface ClassY


    class encryptDecrypt//Seperate class for the encryption decryption methods.
    {

        public string ceaserShiftTable(string lines)//Method for displaying the ceaser cipther table.
        {
            DateTime begin = DateTime.UtcNow;//Start of timer. 
            string saveFile = " ";//Defines saveFile string.

            int maxLength = 15;//Defines the max length of the first line.
            string textInput = lines.Substring(0, Math.Min(lines.Length, maxLength));//Defines the textInput as the maxLength of the input string so that only the first line is displayed in the table.

            encryptDecrypt c = new encryptDecrypt();//Makes an instance of the encryptDecrypt class. 

            Console.WriteLine("\nDecryption shift (left)\t\tCandidate plaintext:\n");//Table header

            for (int count = 1; count <= 26; count++)//Loops through each letter in the "letterArray" array
            {
                Console.WriteLine("\t" + count + "\t\t\t" + c.letterShift(textInput, count));
            }

            int shiftKey = 0;

            while (shiftKey >= 0)
            {//Start of While loop.

                Console.WriteLine("\nPlease enter the correct key shift or press q to quit.");//Gets the user to enter the correct key shift. 
                string temp = Console.ReadLine();



                if (temp == "q") break;//breaks out of the while loop if q is entered.
                int.TryParse(temp, out shiftKey);

                if (shiftKey >= 1 && shiftKey <= 26)
                //Checks to see if a correct key shift option has been choosen.
                {

                    Console.WriteLine("\nShift Key = {0}", shiftKey);//Displays user's choosen key shift.
                    string output = lines;
                    output = output.Replace(" ", string.Empty);//Removes all the spaces out of the string.
                    output = output.Replace("\n", string.Empty);//Removes all the new lines out the string.
                    output = output.Replace("\r", string.Empty);//Removes al the carridge returns out of the string
                    saveFile = c.letterShift(output, shiftKey);//Calls the letterShift and parses the message with the keyshift to be decryoted.



                    break;//Breaks out of the loop when a valid entry has been entered.

                }

                else
                //Displays this message if any input outside of 1-26 is entered.
                {
                    Console.WriteLine("Sorry that entry wasn't a valid Shift Key option.");

                }

            }//End of While loop.


            DateTime end = DateTime.UtcNow;//End of timer
            Console.WriteLine("\nMeasured time taken to decrpyt the message using shift key: " + (end - begin).TotalMilliseconds + " ms.");//Outputs the time taken to decrypt 
            return (saveFile);
        }


        public string letterShift(string message, int keyShift)//Cipher letter shift method.
        {
            char[] letterArray = message.ToCharArray(); //Changes the input string to be letter shifted "message" into a Char array "letterArray".  

            for (int count = 0; count < letterArray.Length; count++)//Loops through each letter in the "letterArray" array.
            {
                // eachLetter assigned as the each part of the letterArray.
                char eachLetter = letterArray[count];

                if (eachLetter >= 'A' && eachLetter <= 'Z')
                //if statement allows the shift to only apply to the char letters A - Z.
                //all other chars are ignored. 
                {
                    // Adds the keyShift to all the letters so that eachLetter now becomes the new key shifted letter  .
                    eachLetter = (char)(eachLetter + keyShift);

                    if (eachLetter > 'Z')
                    // If the shift goes past Z subtract 26 on the char value so it returns back to A 
                    //instead of going through the rest of the ASCII table.                    
                    {
                        eachLetter = (char)(eachLetter - 26);
                    }

                    else if (eachLetter < 'A')
                    //If the shift goes back past A add 26 on the char value so it returns back to Z 
                    {
                        eachLetter = (char)(eachLetter + 26);
                    }
                    // Store the new "letterArray" with the new keyShifted eachLetter.
                    letterArray[count] = eachLetter;

                }//End of if statement.

            }
            return new string(letterArray);//Returns the new "letterArray" with the shift.


        }//End of letterShift method.


        public string frequencyAnalysis(string message)
        {


            DateTime begin = DateTime.UtcNow;//Start of timer. 

            //Start of code for finding the most common letter.
            int commonCharNumber = 0;
            char commonChar = ' ';

            foreach (char findChar in message)
            {//Start of code to find the most commonn letter.
                int charCount = 0;

                foreach (char matchingChars in message)
                {
                    if (findChar == matchingChars)
                        charCount++;
                }

                if (commonCharNumber < charCount)
                {
                    commonChar = findChar;
                    commonCharNumber = charCount;
                }

            }//End of code to find the most common letter.


            Console.WriteLine("\n\nMost occuring letter = " + commonChar + "/" + ((char)commonChar - 0) + "\n\n");//Displays the most occuring letter and its char value


            int keyShift = (69 - (char)(commonChar));//Key shift negative value is calculated by taking the char value of E (69) then minusing the most occurring Char


            Console.WriteLine("Key shift =  +" + (26 + keyShift) + " or " + keyShift + "\n\n");//Displays the positive value key shift and the negative value of the key shift.



            encryptDecrypt c = new encryptDecrypt();//Makes an instance of the encryptDecrypt class.


            string newMessage = c.letterShift(message, keyShift);//Calls the letterShift method and parses the encrypted message plus the keyShift.


            Console.WriteLine(userInterface.yellowLine(newMessage));//Displays the Decrypted message.
            Console.ForegroundColor = ConsoleColor.Green;

            DateTime end = DateTime.UtcNow;//End of timer
            Console.WriteLine("Measured time taken to decrpyt the message using shift key: " + (end - begin).TotalMilliseconds + " ms.");//Outputs the time taken to decrypt 

            return message;

        }





    }//End of encrypt/Decrypt class 

}// End of namespace





