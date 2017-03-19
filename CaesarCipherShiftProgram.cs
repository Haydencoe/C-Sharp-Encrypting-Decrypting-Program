 //309219
//Hayden Coe
//Assessment 1 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CaeserCipher
{
    class UserInterface
    {
        //Main method contains the user interface.
        static void Main(string[] args)
        {
            int mainMenu = 0;
            //Enters the main menu while loop.
            while (mainMenu >= 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                string gretting = "Morning";
                int mainMenuChoice = 0;
                int decryptionChoice = 0;
                int encryptionChoice = 0;
                int caesarShiftEncodedChoice = 0;
                int ownMessageChoice = 0;

                //Checks to see if it is the afternoon or not. 
                if (DateTime.Now.ToString("tt") == "PM")
                    gretting = "Afternoon";

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("====================\n|| MAIN MENU  ||\n====================");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nGood {0}, please choose an option:(or press q to quit the program.) \n1. Decrypt a message. \n2. Encrypt a message.", gretting);///Gets the user to enter an option.

                int enteredChoice3 = 0;
                string temp3 = Console.ReadLine();
                if (temp3 == "q")
                    break;

                int.TryParse(temp3, out enteredChoice3);
                //Calls the choice number method to ensure a valid option has been made.
                mainMenuChoice = choiceNumber(enteredChoice3, 2);

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //FIRST SWITCH OPTION.
                
                //Encrypt or Decrypt option.
                switch (mainMenuChoice)
                {
                    //Decrypt a message option.
                    case 1:

                        Console.WriteLine("Please choose a file to decrypt. (or type 'm' to go back to the main menu) :\n1. caesarShiftEncoded.txt.  \n2. Own message. \n3. caesarShiftEnhancedEncoding.txt");
                        int enteredChoice = 0;
                        string temp = Console.ReadLine();
                        if (temp == "m") break;
                        int.TryParse(temp, out enteredChoice);
                        //Calls the choice number method to ensure a valid option has been made.
                        decryptionChoice = choiceNumber(enteredChoice, 3);
                        //Break of case 1
                        break;

                    //Encrypt a message option.
                    case 2:

                        Console.WriteLine("Please choose an option:(or type 'm' to go back to the main menu) \n1. Encrypt your own message \n2. The message in a .txt file");
                        int enteredChoice2 = 0;
                        string temp2 = Console.ReadLine();
                        if (temp2 == "m") break;
                        int.TryParse(temp2, out enteredChoice2);
                        //Calls the choice number method to ensure a valid option has been made.
                        encryptionChoice = choiceNumber(enteredChoice2, 2);
                        //Break for end of case 2
                        break;

                }//End of switch statement.

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //SECOND SWITCH OPTION.
                switch (decryptionChoice)//Decrypt using caesarShiftEncoded.txt/ own message/ caesarCiptherEnhancedEncoding.
                {
                    case 1://Decrypt the caesarShiftEncoded.txt file

                        Console.WriteLine("Please choose how you would like to decrypt the (caesarShiftEncoded.txt) file :(or type 'm' to go back to the main menu) \n1. The caesar cipher table. \n2. frequency analysis.");
                        int enteredChoice = 0;
                        string temp = Console.ReadLine();
                        if (temp == "m") break;
                        int.TryParse(temp, out enteredChoice);
                        //Calls the choice number method to ensure a valid option has been made.
                        caesarShiftEncodedChoice = choiceNumber(enteredChoice, 2);
                        //Break for end of case 1
                        break;

                    case 2://Decrypt your own typed message option.

                        Console.WriteLine("Please choose how you would like to decrypt your own typed message:(or type 'm' to go back to the main menu) \n1. The caesar cipher table \n2. Frequency analysis.");
                        int enteredChoice2 = 0;
                        string temp2 = Console.ReadLine();
                        if (temp2 == "m") break;
                        int.TryParse(temp2, out enteredChoice2);
                        //Calls the choice number method to ensure a valid option has been made.
                        ownMessageChoice = choiceNumber(enteredChoice2, 2);
                        //Break that ends case 2
                        break;

                    //Decrypt the Enhanced Encoding file with a Affine shift.
                    case 3:
                        {

                            string keyShift = "";
                            Console.WriteLine("\nThe caesarShiftEnhancedEncoding.txt is encoded with a Affine cipher shift. The message can be cracked using this equation: (x) = a-1 * (x-b) mod26 ");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadLine();

                            LoadSave ls = new LoadSave();
                            //Reads in the enhanced message.
                            string enhancedMessage = ls.loadCaesarEnhancedEncodedText();

                            Console.WriteLine("The encoded caesarShiftEnhancedEncoding.txt file: \n\n" + enhancedMessage);
                            enhancedMessage = enhancedMessage.Replace(" ", string.Empty);
                            enhancedMessage = enhancedMessage.Replace("\n", string.Empty);
                            enhancedMessage = enhancedMessage.Replace("\r", string.Empty);
                            //An instance of the class is created. 
                            EncryptDecrypt c = new EncryptDecrypt();
                            string decodedMessage = c.affineDecoder(enhancedMessage, ref keyShift);
                            Console.WriteLine("\nDecoded message:\n\n");
                            //Displays the decrypted message by calling the letterShift method.
                            Console.WriteLine(yellowLine(decodedMessage));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nPress any key to return to main menu.");
                            Console.ReadLine();
                            //Calls the saveCaesarShiftPlainText method to save the decrypted message to the caesarShiftPlainText.txt.
                            ls.saveCaesarShiftEnhancedPlainText(decodedMessage, keyShift);
                            //Calls the saveCaesarShiftPlainTextWeb method to save the decrypted message to the caesarShiftPlainTextWebPage.html.
                            ls.saveCaesarShiftEnhancedPlainTextWeb(decodedMessage, enhancedMessage, keyShift);


                        }
                        //Break that ends case 3.
                        break;
                }

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //THIRD SWITCH OPTION.
                //Encrypt own message or .txt file. 
                switch (encryptionChoice)
                {
                    //Own message option.
                    case 1:
                        {
                            //Makes an instance of the encryptDecrypt class.
                            EncryptDecrypt c = new EncryptDecrypt();
                            //Gets the user to enter their message for encryption.
                            Console.WriteLine("Please enter the message you would like to encrypt with the Caeser cipher encoding.");
                            //Gets the users message
                            string messageToEncrypt = Console.ReadLine();
                            //Converts the message to all upper case.
                            string messageToEncryptUpper = messageToEncrypt.ToUpper();
                            //Removes all the spaces out of the string.
                            messageToEncryptUpper = messageToEncryptUpper.Replace(" ", string.Empty);
                            //Gets the user to enter a key shift to apply to their message.
                            string saveFile = "";
                            int keyShift = 0;
                            int start = 0;
                            while (start >=  0)
                            {
                               Console.WriteLine("Please enter the key shift you want to apply to your message.");


                            string temp = Console.ReadLine();
                            int.TryParse(temp, out keyShift);                             
                                //Checks to see if a valid key entry has been made.
                            if (keyShift >= 1 && keyShift <= 26)
                            {
                                //Calls the letterShift method and parses the user's message with their intended keyShift.
                                saveFile = c.letterShift(messageToEncryptUpper, keyShift);
                                break;
                            }

                            else
                            //Displays this message if any input outside of 1-26 is entered.
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nSorry that entry wasn't a valid Key Shift option.\n");
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }
                            
                            //Displays a message with the useres inputed keyshift value.
                            Console.WriteLine("Your now encrypted message with a keyshift of " + keyShift + " applied:");
                            //Displays the new encrypted message with a differnt colour.
                            Console.WriteLine("\n" + yellowLine(saveFile));
                            //Changes the console colour back to green.
                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine("Would you like to save your encrypted file? y / n");

                            string saveDecision = Console.ReadLine();

                            LoadSave ls = new LoadSave();

                            if (saveDecision == "y")
                                ls.ownMessageCaesarCipherText(saveFile, keyShift);

                            else

                            Console.WriteLine("Press any key to return to main menu");
                            Console.ReadLine();




                        }//End of case 1

                        //break of switch case 1.
                        break;

                    //.txt file option.
                    case 2:
                        {
                            //Makes an instance of the LoadSave class. 
                            LoadSave ls = new LoadSave();
                            string lines = ls.loadOwnTextFile();
                            if (lines == "")
                                break;
                            EncryptDecrypt c = new EncryptDecrypt();
                            //Converts the message to all upper case.
                            string messageToEncryptUpper = lines.ToUpper();
                            //Removes all the spaces out of the string.
                            messageToEncryptUpper = messageToEncryptUpper.Replace(" ", string.Empty);
                            //Gets the user to enter a key shift to apply to their message.
                            Console.WriteLine("Please enter the key shift you want to apply to your message.");
                            //Gets the key shift value.
                            int keyShift = int.Parse(Console.ReadLine());
                            //Calls the letterShift method and parses the user's message with their intended keyShift.
                            string saveFile = c.letterShift(messageToEncryptUpper, keyShift);
                            //Displays a message with the users inputed keyshift value.
                            Console.WriteLine("\nYour now encrypted message with a keyshift of " + keyShift + " applied:");
                            //Displays the new encrypted message with a different colour.
                            Console.WriteLine("\n" + yellowLine(saveFile));
                            //Changes the console colour back to green.
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Presss any key to return to main menu");
                            Console.ReadLine();

                        }//End of case 2

                        break;//Break for case 2
                }//End of switch thirdChoice

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //FORTH SWITCH OPTION.
                //Decryption on caesarShiftEncodedText.txt file.
                switch (caesarShiftEncodedChoice)
                {
                    case 1: //Descrypts using caesar cipher table on "caesarShiftEncodedText.txt" file.
                        int keyShift = 0;
                        //Makes an instance of the LoadSave class.
                        LoadSave ls2 = new LoadSave();
                        //loads the caesarShiftEncodedText.txt file by calling the loadCaesarCipherEncodedText method.                        
                        string encryptedFile = ls2.loadCaesarCipherEncodedText();
                        //Checks to see if a file has been loaded.
                        if (encryptedFile == "")
                            break;//if a file has not been loaded then the loop is broken and returns to main menu.
                        //Makes an instance of the encryptDecrypt class.
                        EncryptDecrypt c = new EncryptDecrypt();
                        Console.WriteLine("\nThe decrypted message:");
                        //Defines saveFile as the return of the caesarShiftTable method.
                        string saveFile = c.caesarShiftTable(encryptedFile, ref keyShift);
                        Console.WriteLine("\nYour decoded message:\n");
                        //Displays the decrypted message.
                        Console.WriteLine(yellowLine(saveFile));
                        //Changes the console foreground colour back to green.        
                        Console.ForegroundColor = ConsoleColor.Green;
                        //Calls the saveCaesarShiftPlainText method to save the decrypted message to the caesarShiftPlainText.txt file.
                        ls2.saveCaesarShiftPlainText(saveFile, keyShift);
                        //Calls the saveCaesarShiftPlainTextWeb method to save the decrypted message to the caesarShiftPlainTextWebPage.html file.
                        ls2.saveCaesarShiftPlainTextWeb(saveFile,encryptedFile, keyShift);

                        break;//Break for case 1.

                    case 2://Decrypts using frequency analysis on the caesarCipherEncoded.txt file.
                        //Makes an instance of the loadSave class
                        LoadSave ls = new LoadSave();
                        //Calls the loadCaesarCipherEncodedText method and asigns lowerCase to the return of the method.
                        string lowerCase = ls.loadCaesarCipherEncodedText();
                        //Ensures all the text is upperCase ready for decryption. 
                        string frequencyLines = lowerCase.ToUpper();
                        //Displays the encrypted message.
                        Console.WriteLine("\nEncrypted message:\n\n" + frequencyLines);
                        //Removes all the spaces out of the string.
                        frequencyLines = frequencyLines.Replace(" ", string.Empty);
                        //Removes all the carridge returns out of the string
                        frequencyLines = frequencyLines.Replace("\r", string.Empty);
                        //Removes all the new lines out of the string
                        frequencyLines = frequencyLines.Replace("\n", string.Empty);
                        //Makes an instance of the encryptDecrypt class.
                        EncryptDecrypt b = new EncryptDecrypt();
                        //Calls the frequencyAnalysis method and sends the encrypted data to be decrypted.
                        b.frequencyAnalysis(frequencyLines);
                        Console.WriteLine("\nPress any key to return to main menu");
                        Console.ReadLine();
                        //Break for case 2.
                        break;

                }//End of switch statement caesarShiftEncodedChoice.


                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //FIFTH SWITCH OPTION.
                //Own message decryption.
                switch (ownMessageChoice)
                {

                    case 1://Decrypts using caesar cipher table on own message option.
                        int keyShift = 0;
                        //Gets the user to  enter their message to be decrypted.
                        Console.WriteLine("Please enter your message.");
                        //Gets the user's encrypted message.
                        string lower = Console.ReadLine();
                        //Converts all inputed text to uppercase.
                        string myLines = lower.ToUpper();
                        //Makes an instance of the encrypDecrypt class.
                        EncryptDecrypt b = new EncryptDecrypt();
                        //Calls the caesarShiftTable method parses the message then defines the newSaveFile as the return.
                        string newSaveFile = b.caesarShiftTable(myLines, ref keyShift);
                        Console.WriteLine("\nYour decoded message:\n");
                        //Calls the different colour method.
                        Console.WriteLine(yellowLine(newSaveFile));
                        //Changes the console colour back to green.
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Press any key to return to main menu");
                        Console.ReadLine();
                        break;//Break for case 1.

                    case 2://Calls frequency analysis for own message.

                        Console.WriteLine("Please enter your message to preform a caeser shift frequency analysis on.");
                        string ownMessage = Console.ReadLine();
                        string ownMessageUpper = ownMessage.ToUpper();
                        ownMessageUpper = ownMessageUpper.Replace(" ", string.Empty);
                        EncryptDecrypt c = new EncryptDecrypt();
                        c.frequencyAnalysis(ownMessageUpper);
                        Console.WriteLine("\nPress any key to return to main menu");
                        Console.ReadLine();
                        break;//Break for case 2.


                }//End of switch statement ownMessageChoice.
            }//End of mainMenu while loop.
        }//End of Main method.

        //Method for ensuring a correct entry has been entered.
        static public int choiceNumber(int yourChoice, int maxNumber)
        {
            int start = 0;

            while (start >= 0)
            {
                try
                {
                    //Checks if the entered option is in the boundries entered.
                    if (yourChoice >= 1 && yourChoice <= maxNumber)
                        break;//Breaks if a valid option is entered
                    else
                        //Throws to the catch if an invalid option has been made.
                        throw new FormatException();
                }

                    //Catches the errors of an entered choice option.
                catch (FormatException)
                {
                    //Changes the font to red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    //Sounds to alert to an error.
                    Console.Beep();
                    Console.WriteLine("\nSorry that wasn't a valid option.");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Please enter a valid option or press m to return to main menu");
                    string temp = Console.ReadLine();
                    //Breaks out of loop if return to main menu has been selected.
                    if (temp == "m") break;
                    int.TryParse(temp, out yourChoice);
                }//End of catch statement.
            }//End of while loop.


            return yourChoice;
        }//End of the choiceNumber method.



        static public string yellowLine(string value)
        {
            //changes the console colour to yellow. 
            Console.ForegroundColor = ConsoleColor.Yellow;

            return value;
        }


    }//End of unserInterface Class.

    //Seperate class for the encryption decryption methods.
    class EncryptDecrypt
    {
        //Method for displaying the ceaser cipther table.
        public string caesarShiftTable(string lines, ref int keyShift)
        {
            //Start of timer. 
            DateTime begin = DateTime.UtcNow;
            //Defines saveFile string.
            string saveFile = " ";
            //Defines the max length of the first line.
            int maxLength = 15;
            //Defines the textInput as the maxLength of the input string so that only the first line is displayed in the table.
            string textInput = lines.Substring(0, Math.Min(lines.Length, maxLength));
            //Makes an instance of the encryptDecrypt class. 
            EncryptDecrypt c = new EncryptDecrypt();
            //Table header
            Console.WriteLine("\nDecryption shift (left)\t\tCandidate plaintext:\n");
            //Loops through each letter in the "letterArray" array
            for (int count = 1; count <= 26; count++)
            {
                Console.WriteLine("\t" + count + "\t\t\t" + c.letterShift(textInput, count));
            }

            int shiftKey = 0;

            while (shiftKey >= 0)
            {//Start of While loop.
                //Gets the user to enter the correct key shift. 
                Console.WriteLine("\nPlease enter the correct key shift or press q to quit.");
                string temp = Console.ReadLine();

                //breaks out of the while loop if q is entered.
                if (temp == "q") break;
                int.TryParse(temp, out shiftKey);

                //Checks to see if a correct key shift option has been choosen.
                if (shiftKey >= 1 && shiftKey <= 26)
                
                {
                    //Displays user's choosen key shift.
                    Console.WriteLine("\nShift Key = {0}", shiftKey);
                    string output = lines;
                    //Removes all the spaces out of the string.
                    output = output.Replace(" ", string.Empty);
                    //Removes all the new lines out the string.
                    output = output.Replace("\n", string.Empty);
                    //Removes al the carridge returns out of the string
                    output = output.Replace("\r", string.Empty);
                    //Calls the letterShift and parses the message with the keyshift to be decryoted.
                    saveFile = c.letterShift(output, shiftKey);
                    //Defines the keyshift ref for the .txt and webpage output as the shift key used to decrypt
                    keyShift = shiftKey;
                    //Breaks out of the loop when a valid entry has been entered.

                    break;
                }

                else
                //Displays this message if any input outside of 1-26 is entered.
                {
                    Console.WriteLine("Sorry that entry wasn't a valid Shift Key option.");

                }

            }//End of While loop.

            //End of timer
            DateTime end = DateTime.UtcNow;
            Console.WriteLine("\nMeasured time taken to decrpyt the message using shift key: " + (end - begin).TotalMilliseconds + " ms.");//Outputs the time taken to decrypt 
            return (saveFile);
        }

        //Cipher letter shift method.
        public string letterShift(string message, int keyShift)
        {
            //Changes the input string to be letter shifted "message" into a Char array "letterArray".  
            char[] letterArray = message.ToCharArray(); 

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
            //Returns the new "letterArray" with the shift.
            return new string(letterArray);


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
                       //Char count counts up when matchingChars and findChar match 
                        charCount++;
                }

                if (commonCharNumber < charCount)
                {
                    commonChar = findChar;
                    commonCharNumber = charCount;
                }

            }//End of code to find the most common letter.


            Console.WriteLine("\n\nMost occuring letter = " + commonChar + "/" + ((char)commonChar - 0) + "\n\n");//Displays the most occuring letter and its char value

            //Key shift negative value is calculated by taking the char value of E (69) then minusing the most occurring Char.
            int keyShift = (69 - (char)(commonChar));

            //Displays the positive value key shift and the negative value of the key shift.
            Console.WriteLine("Key shift =  +" + (26 + keyShift) + " or " + keyShift + "\n\n");


            //Makes an instance of the encryptDecrypt class.
            EncryptDecrypt c = new EncryptDecrypt();

            //Calls the letterShift method and parses the encrypted message plus the keyShift.
            string newMessage = c.letterShift(message, keyShift);

            //Displays the Decrypted message.
            Console.WriteLine(UserInterface.yellowLine(newMessage));
            Console.ForegroundColor = ConsoleColor.Green;

            //End of timer
            DateTime end = DateTime.UtcNow;
            Console.WriteLine("Measured time taken to decrpyt the message using shift key: " + (end - begin).TotalMilliseconds + " ms.");//Outputs the time taken to decrypt 

            return message;

        }
        //Method for decoding an affine cipher.
        public string affineDecoder(string encryptedText, ref string keyshift)
        {
            keyshift = "a = 7, b = 3";

            //Number keys for decrypting an Affine cipher.
            string decryptedText = "";
            int a = 7;
            int b = 3;

            //Decryption of an affine cipher is calculated by (x) = a-1(x-b) mod 26
            EncryptDecrypt ed = new EncryptDecrypt();

            //Calls the inverserMethod to find the inverse of a.
            int inverseOfa = ed.inverserMethod(a);

            Console.WriteLine("\nThe inverse of a is: " + inverseOfa + "\n");

            //Converts all the encrypted message into uppercase.
            string decodingText = encryptedText.ToUpper();

            //Converts the encrypted message into a char array.
            char[] decodingTextChars = decodingText.ToCharArray();

            //Foreach loop started so that the equation is applied to each letter in the char array of the message.
            foreach (char c in decodingTextChars)
            {
                //converts c letters from their ASCII numbers to numbers (1-26)  
                int x = (char)c - 65;

                if (x - b < 0)
                    //if x - the value of b returns a negative number then 26 is added back on to make it the positive equivalent.
                    x = (char)x + 26;

                //Maths for calculating the decoding of an affine cipher plus converts the numbers to Chars the +65 converts the chars back to ASCII chars
                decryptedText += Convert.ToChar(((inverseOfa * (x - b)) % 26) + 65);
                //(x)   =   a-1    *  (x-b)  mod 26


            }


            return decryptedText;

        }

        //Method for inversing a.
        public int inverserMethod(int a)
        {

            int inverseOfa = 0;

            try
            {
                //For loop trys each number as x from 1 - 26
                for (int x = 1; x <= 26; x++)
                {
                    //Maths for calculating the inverse of a, if statement looks for which x value returns 1 from the equation.
                    if ((a * x) % 26 == 1)

                        //When x value returns 1 from the equation the x value is assigned to the inverseOfa. 
                        inverseOfa = x;

                }

            }

                //Catches any errors if the inverse could not be found from the value of a.
            catch (Exception)
            {

                Console.WriteLine("The inverse of a could not be found!");
            }

            //Returns the inverseOfa value.
            return inverseOfa;

        }


    }//End of encrypt/Decrypt class 



    class LoadSave
    {
        public string loadOwnTextFile()
        {
            int start = 0;
            string loadFile = "";
            Console.WriteLine("Please enter the full file name you want to load to apply a ceaser cipher encoding to.");
            string newPath = Console.ReadLine();

            while (start >= 0)
            {

                try
                {
                    Console.WriteLine("\nLoading....");
                    //Loads the file using the path defined as newPath.
                    loadFile = File.ReadAllText(newPath);
                    Console.WriteLine("Load succseful!");
                    break;
                }

                catch
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSorry file could not be Loaded!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Gets the user to enter a new location for the save.
                    Console.WriteLine("\nPlease enter a new path to load from or press m to go to main menu.\n\n");
                    //Gets the user's new file location to save to.
                    newPath = Console.ReadLine();
                    //option to quit to main menu. 
                    if (newPath == "m")
                        break;

                }//End of catch              

            }//End of while loop

            return loadFile;
        }

        public string loadCaesarCipherEncodedText()
        {

            int start = 0;
            string loadFile = "";

            //*****USE THIS IF LOADING FROM A FILE IN THE PROJECT RESOURSCES FOLDER******
            string loadPath = "Text.txt";

            //while loop to repeat codeonce a new location has been entered. 
            while (start >= 0)
            {
                try
                {
                    Console.WriteLine("\nLoading...");
                    loadFile = File.ReadAllText(loadPath);
                    Console.WriteLine("\nFile loaded!");
                    break;
                }

                catch//If the file to save to can't be found the error is caught.
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSorry file could not be Loaded!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Gets the user to enter a new location for the save.
                    Console.WriteLine("\nPlease enter a new path to save to or press m to go to main menu.\n\n");
                    //Gets the user's new file location to save to.
                    loadPath = Console.ReadLine();
                    //option to quit to main menu. 
                    if (loadPath == "m")
                        break;
                }

            }

            return loadFile;
        }

        public string loadCaesarEnhancedEncodedText()
        {

            int start = 0;
            string loadFile = "";


            //*****USE THIS IF LOADING FROM A FILE IN THE PROJECT RESOURSCES FOLDER******
           string loadPath = "Text2.txt";

            //while loop to repeat code once a new location has been entered. 
            while (start >= 0)
            {
                try
                {
                    Console.WriteLine("\nLoading...");
                    loadFile = File.ReadAllText(loadPath);
                    Console.WriteLine("\nFile loaded!");
                    break;
                }

                catch//If the file to save to can't be found the error is caught.
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSorry file could not be Loaded!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Gets the user to enter a new location for the save.
                    Console.WriteLine("\nPlease enter a new path to save to or press m to go to main menu.\n\n");
                    //Gets the user's new file location to save to.
                    loadPath = Console.ReadLine();
                    //option to quit to main menu. 
                    if (loadPath == "m")
                        break;
                }

            }

            return loadFile;
        }

        //Method for saving to caesarShiftPlainText.txt
        public string saveCaesarShiftPlainText(string saveFile, int keyShift)
        {
            int pos = 80;


            for (int i = 0; i <saveFile.Length; i += pos)
            {

                saveFile = saveFile.Insert(i, "\n");
                saveFile = saveFile.Insert(i, "\r");
            }

            string keyShiftStr = Convert.ToString(keyShift);


            string textShift = "Plain text of the caesarShiftEncoded.txt file"+"\r\n"+"Decrypted using key shift:" + keyShiftStr + "\r\n" + saveFile;

            string newPath = "caesarShiftPlainText.txt";//Path to save file to.

          

            int start = 0;

            //while loop to repeat code once a new location has been entered. 
            while (start >= 0)
            {
                try
                {
                    //Saves decrypted message to a .txt file. 
                    File.WriteAllText(newPath, textShift);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n**Decrypted message file saved!** \nThe .txt file was saved to 'caesarShiftPlainText.txt'");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nPress any key to save to a web page file .");
                    Console.ReadLine();
                    break;
                }

                catch//If the file to save to can't be found the error is caught here.
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSorry file could not be Saved!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Gets the user to enter a new location for the save.
                    Console.WriteLine("\nPlease enter a new path to save to or press m to go to main menu.\n\n");
                    //Gets the user's new file location to save to.
                    newPath = Console.ReadLine();
                    //option to quit to main menu.
                    if (newPath == "m") 
                        break;
                }

            }

     
            return saveFile;//Returns the saveFile.
        }

       
        public string ownMessageCaesarCipherText(string saveFile, int keyShift)
        {
            int pos = 80;


            for (int i = 0; i < saveFile.Length; i += pos)
            {

                saveFile = saveFile.Insert(i, "\n");
                saveFile = saveFile.Insert(i, "\r");
            }

            string keyShiftStr = Convert.ToString(keyShift);


            string textShift = "Encrypted text of own message" + "\r\n" + "Encrypted using key shift:" + keyShiftStr + "\r\n" + saveFile;

            string newPath = "ownEncryptedCaesarCipherText.txt";//Path to save file to.



            int start = 0;

            //while loop to repeat code once a new location has been entered. 
            while (start >= 0)
            {
                try
                {
                    //Saves decrypted message to a .txt file. 
                    File.WriteAllText(newPath, textShift);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n**Encrypted message file saved!** \nThe .txt file was saved to 'ownEncryptedCaesarCipherText.txt'");
                    Console.ForegroundColor = ConsoleColor.Green;
                    
                    break;
                }

                catch//If the file to save to can't be found the error is caught here.
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSorry file could not be Saved!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Gets the user to enter a new location for the save.
                    Console.WriteLine("\nPlease enter a new path to save to or press m to go to main menu.\n\n");
                    //Gets the user's new file location to save to.
                    newPath = Console.ReadLine();
                    //option to quit to main menu.
                    if (newPath == "m")
                        break;
                }

            }


            return saveFile;//Returns the saveFile.
        }
        //Method for saving to caesarShiftPlainText.txt
        public string saveCaesarShiftPlainTextWeb(string saveFile, string encryptedFile, int keyShift)
        {
            saveFile = saveFile.Replace("STOP", ". ");

            int pos = 80;
            //Inserts new lines every 80 Chars.
            for (int i = 0; i < encryptedFile.Length; i += pos)
            {

                encryptedFile = encryptedFile.Insert(i, "\n");
            }


            //Inserts new lines and caridge returns every 80 Chars.
            for (int i = 0; i <saveFile.Length; i += pos)
            {

               saveFile = saveFile.Insert(i, "\n");
               saveFile = saveFile.Insert(i, "\r");
            }

            string keyShiftStr = Convert.ToString(keyShift);


            LoadSave ls = new LoadSave();
            string webSave = ls.saveHtmlFile(saveFile, encryptedFile, keyShiftStr);

            //Path to save file to.
            string webPath = "caesarShiftPlainTextWebPage.html";

            int start = 0;

            //while loop to repeat code once a new location has been entered. 
            while (start >= 0)
            {
                try
                {
                    //Saves decrypted message to a .txt file. 
                    File.WriteAllText(webPath, webSave);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n**Decrypted message file saved!** \nThe .html webpage file was saved to caesarShiftPlainTextWebPage.html");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nPress any key to return to main menu.");
                    Console.ReadLine();
                    break;
                }

                catch//If the file to save to can't be found the error is caught.
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSorry web file could not be Saved!");
                    Console.ForegroundColor = ConsoleColor.Green;

                    //Gets the user to enter a new location for the save.
                    Console.WriteLine("\nPlease enter a new path to save to or press m to go to main menu.\n\n");
                    //Gets the user's new file location to save to.
                    webPath = Console.ReadLine();
                    //option to quit to main menu. 
                    if (webPath == "m")
                        break;
                }

            }

            return webSave;//Returns the saveFile.
        
        }
        //Method for saving to caesarShiftPlainText.txt
        public string saveHtmlFile(string saveFile, string encryptedFile, string keyShift)
        {

            List<string> webList = new List<string>();

            string keyShiftStr = Convert.ToString(keyShift);

            //Headers
            webList.Add("<html>");
            webList.Add("<body bgcolor='#9AB7EE'>");
            webList.Add("<u><h1><i><font face='arial'  size='5' color='white'>309219 Hayden Coe</i></h1></u>");
            webList.Add("<center><u>");
            webList.Add("<h1><b><i><font face='arial'  size='7' color='white'>Assessment 1 Caesar Cipher Decryption</i></b></h1>");
            webList.Add("</center></u>");
            webList.Add("<center><u>");
            webList.Add("<h2><font face='arial'  size='6' color='white'><i>caesarShiftEncoded.txt file.</i></h2>");
            webList.Add("</center></u>");
            webList.Add("<p> </p>");

            //Box 1 with encrypted message
            webList.Add("<u>");
            webList.Add("<font face='arial'  size='6' color='red'><center>Encoded Text:</center></font>");
            webList.Add("</u>");
            webList.Add("<p> </p>");
            webList.Add("<center><table border='6' style= 'width:50%' >");
            webList.Add("<tr>");
            webList.Add("<th>");
            webList.Add("<font face='arial' size='3' color='red'>");
            webList.Add(encryptedFile);
            webList.Add("</font>");
            webList.Add("</th>");
            webList.Add("</tr>");
            webList.Add("</table></centre>");

          

            //Box 2 with decrypted message
            webList.Add("<p> </p>");
            webList.Add("<u>");
            webList.Add("<font size='6' face='arial' color='green'><center>Decoded Text:</center></font>");
            webList.Add("</u>");

            //Decoded with key shift text.
            webList.Add("<p> </p>");
            webList.Add("<p><font face='arial'  size='5' color='white'><b>Decoded using a Key Shift of: ");
            webList.Add(keyShiftStr);
            webList.Add("</b></p>");

            webList.Add("<p> </p>");
            webList.Add("<center><table border='6'style= 'width:50%'>");// 'border:5px solid grey;
            webList.Add("<tr>");
            webList.Add("<th>");
            webList.Add("<font size='3' face='arial' color='green'>");
            webList.Add(saveFile);
            webList.Add("</font>");
            webList.Add("</th>");
            webList.Add("</tr>");
            webList.Add("</table></center>");

           
            webList.Add("</body>");
            webList.Add("</html>");

            string webArrayReturn = string.Join("",webList.ToArray());
            
            return webArrayReturn;
        
        }
        //Method for saving to caesarShiftPlainText.txt
        public string saveCaesarShiftEnhancedPlainText(string saveFile, string keyshift)
        {
            int pos = 80;

            //Inserts new line and carridge returns every 80 Chars.
            for (int count = 0; count < saveFile.Length; count += pos)
            {

                saveFile = saveFile.Insert(count, "\n");
                saveFile = saveFile.Insert(count, "\r");
            }


            string textShift = "Plain text of the caesarShiftEnhancedEncoded.txt file"+"\r\n"+"Decrypted using key shift:" + keyshift + "\r\n" + saveFile;
            //Path to save file to.
            string newPath = "caesarShiftEnhancedPlainText.txt";

          

            int start = 0;
            //while loop to repeat code once a new location has been entered. 
            while (start >= 0)
            {
                try
                {
                    //Saves decrypted message to a .txt file. 
                    File.WriteAllText(newPath, textShift);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n**Decrypted message file saved!** \nThe .txt file was saved to 'caesarShiftEnhancedPlainText.txt'");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nPress any key to save to a web page file .");
                    Console.ReadLine();
                    break;
                }

                catch//If the file to save to can't be found the error is caught here.
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSorry file could not be Saved!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Gets the user to enter a new location for the save.
                    Console.WriteLine("\nPlease enter a new path to save to or press m to go to main menu.\n\n");
                    //Gets the user's new file location to save to.
                    newPath = Console.ReadLine();
                    //option to quit to main menu. 
                    if (newPath == "m")
                        break;
                }

            }


            //Returns the saveFile.
            return saveFile;
        }
        //Method for saving to caesarShiftPlainText.txt
        public string saveCaesarShiftEnhancedPlainTextWeb(string saveFile, string encryptedFile, string keyShift)
        {


            saveFile = saveFile.Replace("STOP", ". ");

            int pos = 80;
            //Inserts new line ever 80 Chars.
            for (int count = 0; count < encryptedFile.Length; count += pos)
            {

                encryptedFile = encryptedFile.Insert(count, "\n");
            }


            //Inserts new lines and carridge returns every 80 Chars
            for (int count = 0; count < saveFile.Length; count += pos)
            {

                saveFile = saveFile.Insert(count, "\n");
                saveFile = saveFile.Insert(count, "\r");
            }


            LoadSave ls = new LoadSave();
            string webSave = ls.saveHtmlFile(saveFile, encryptedFile, keyShift);

            //Path to save file to.

            string webPath = "caesarShiftEnhancedPlainTextWebPage.html";
            int start = 0;

            //while loop to repeat code once a new location has been entered. 
            while (start >= 0)
            {
                try
                {
                    //Saves decrypted message to a .txt file. 
                    File.WriteAllText(webPath, webSave);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n**Decrypted message file saved!** \nThe .html webpage file was saved to caesarShiftEnhancedPlainTextWebPage.html");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nPress any key to return to main menu.");
                    Console.ReadLine();
                    break;
                }

                catch//If the file to save to can't be found the error is caught.
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSorry web file could not be Saved!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Gets the user to enter a new location for the save.
                    Console.WriteLine("\nPlease enter a new path to save to or press m to go to main menu.\n\n");
                    //Gets the user's new file location to save to.
                    webPath = Console.ReadLine();
                    if (webPath == "m")//option to quit to main menu. 
                        break;
                }

            }

            return webSave;//Returns the saveFile.
        }


    }//End of load/Save class



}// End of namespace





