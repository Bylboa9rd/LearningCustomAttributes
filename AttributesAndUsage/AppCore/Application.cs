using AppCore.Models;
using System.Reflection;
using ValidationComponent_.CustomAttributes;
using static System.Console;

namespace AppCore
{
    public static class Application
    {
        static Type traineeType = typeof(BEZAOTrainee);

        public static void Run()
        {
            GetDocs();
        }
        public static void GetDocs()
        {
            ListClasses();
            ListConstructors();
            ListProperties();
            ListMethods();
            ListNestedTypes();
        }
        public static void ListClasses()
        {
            WriteLine("{0} Documentation:", Assembly.LoadFrom("AppCore").FullName);
            WriteLine("\nClasses: \n\n\t1. {0}:", traineeType.Name);

            object[] classAttributes = traineeType.GetCustomAttributes(true);

            foreach (Attribute item in classAttributes)
            {
                if (item is DocumentAttribute)
                {
                    DocumentAttribute documentAttribute = (DocumentAttribute)item;
                    WriteLine("\t\tDescription:\n\t\t\t{0}", documentAttribute.Description);
                }
            }
        }
        public static void ListConstructors()
        {
            WriteLine("\n\tConstructor(s):");

            ConstructorInfo[] constructors = traineeType.GetConstructors();

            if (constructors.Any())
            {
                for (int i = 0; i < constructors.GetLength(0); i++)
                {
                    object[] constructorAttributes = constructors[i].GetCustomAttributes(typeof(DocumentAttribute), true);

                    foreach (Attribute attr in constructorAttributes)
                    {
                        if (attr is DocumentAttribute docAttr)
                        {
                            docAttr = (DocumentAttribute)attr;

                            WriteLine($"\t\t{constructors[i].Name}:\n\t\tDescription:\n\t\t\t{docAttr.Description}\n\t\tInput: {docAttr.Input}");

                        }
                        return;
                    }
                }
            }
            else
            {
                WriteLine("Constructors not found!");
            }

        }

        public static void ListProperties()
        {
            WriteLine("\n\tProperties: ");

            PropertyInfo[] properties = traineeType.GetProperties();

            if (properties.Any())
            {
                for (int i = 0; i < properties.GetLength(0); i++)
                {
                    object[] propertyAttributes = properties[i].GetCustomAttributes(true);

                    foreach (Attribute item in propertyAttributes)
                    {
                        if (item is DocumentAttribute documentAttribute)
                        {
                            documentAttribute = (DocumentAttribute)item;
                            WriteLine($"\n\t\t{properties[i].Name}\n\t\tDescription: {documentAttribute.Description}");
                        }
                    }
                }
            }
            else
            {
                WriteLine("Properties not found!");
            }

        }

        public static void ListMethods()
        {
            WriteLine("\n\tMethods:");

            var methodInfoList = traineeType.GetMethods();

            if (methodInfoList.Any())
            {
                for (int i = 0; i < methodInfoList.GetLength(0); i++)
                {
                    object[] methodAttributes = methodInfoList[i].GetCustomAttributes(true);

                    foreach (Attribute attribute in methodAttributes)
                    {
                        if (attribute is DocumentAttribute att)
                        {
                            WriteLine($"\t{methodInfoList[i].Name}\n\t\tDescription:{att.Description}\n\t\tInput:{att.Input}\n\t\t{att.Output}");
                        }

                    }
                }
            }
            else
            {
                WriteLine("Methods not found!");
            }        
        }

        public static void ListNestedTypes()
        {
            WriteLine("\nNested classes: ");

            Type[] nestedTypes = traineeType.GetNestedTypes();
            
            if (nestedTypes.Any())
            {
                for (int i = 0; i < nestedTypes.GetLength(0); i++)
                {
                    WriteLine($"\t2. {nestedTypes[i].Name}");

                    object[] attributes = nestedTypes[i].GetCustomAttributes(true);

                    foreach(Attribute attribute in attributes)
                    {
                        if (attribute is DocumentAttribute documentAttribute)
                        {
                            WriteLine($"\t\tDescription: \n\t\t\t{documentAttribute.Description}");
                        }
                    }
                }
            }
            else
            {
                WriteLine("No nested types found!");
            }

        }

        public static void ListEnums()
        {
            WriteLine("Enums: ");

            /*string[] enumNames = traineeType.GetEnumNames();

            if (enumNames.Any())
            {
                var enumValues = traineeType.GetEnumValues();

                for (int i = 0; i < enumNames.GetLength(0); i++)
                {
                    WriteLine(enumNames[i]);


                    WriteLine(enumValues);

                }
            }*/

            var enumValues = traineeType.GetEnumValues();

            for (int i = 0; i < enumValues.GetLength(0); i++)
            {


                WriteLine(enumValues);

            }
        }

        /*public static string? GetAttribute(Type desiredType, Type desiredAttribute)
        {
            var attribute = Attribute.GetCustomAttribute(desiredType, desiredAttribute);

            if (attribute is not null)
                Display(attribute);
            else
                WriteLine($"The class {desiredType} has no attributes.");

            return attribute?.ToString();
        }

        private static void Display(Attribute attribute)
        {
            var propertyInfoList = attribute.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //WriteLine($"The {attribute} attribute:");

            foreach (var pInfo in propertyInfoList)
            {
                if (!string.IsNullOrEmpty(pInfo.Name))
                {
                    WriteLine($"Description:\n\t\t{pInfo.GetValue(attribute)}");
                    return;
                }

            }

        }*/

    }
}
