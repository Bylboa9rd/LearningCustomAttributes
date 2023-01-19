using static ValidationComponent_.Validator;
using static System.Console;

namespace AppCore
{
    public static class InputProcessor
    {
        public static bool GetInput(Type t, string displayText, string fieldName, out string fieldValue)
        {
            do
            {
                WriteLine(displayText);

                string valueEntered = ReadLine();

                if(!PropertyIsValid(t, valueEntered, fieldName, out string errorMessage))
                {
                    PrintMessage(false, errorMessage);
                }
                else{
                    fieldValue = valueEntered;
                }

            } while (true);

            return true;
        }

        public static void PrintMessage(bool success, string message)
        {

            switch (success)
            {
                case true:
                    ForegroundColor = ConsoleColor.Green;
                    break;
                case false:
                    ForegroundColor = ConsoleColor.Red;
                    break;
            }

            WriteLine(message);
            ResetColor();
        }
    }
}
