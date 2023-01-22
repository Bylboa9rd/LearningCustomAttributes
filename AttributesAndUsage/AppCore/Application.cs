using AppCore.Models;
using System.Reflection;
using ValidationComponent_.CustomAttributes;
using static System.Console;

namespace AppCore
{
    public static class Application
    {
         
        public static void GetDocs()
        {
            Assembly forDocumentAttributes = Assembly.LoadFrom("Documentor");

            Type[] types = forDocumentAttributes.GetTypes();

            foreach (Type t in types)
            {
                ListTypes(t);
                ListConstructors(t);
                ListProperties(t);
                ListMethods(t);
            }

        }

        public static void ListTypes(Type type)
        {
            var documentAttribute = (DocumentAttribute)type.GetCustomAttribute(typeof(DocumentAttribute));

            if (documentAttribute != null)
            {
                if (type.IsClass)
                {
                    Display($"\nClass:\t{type.Name}\n\tDescription: \n\t\t{documentAttribute.Description}\n");
                }
                if (type.IsEnum)
                {
                    Display($"\nEnum:\t{type.Name}\n\tDescription: \n\t\t{documentAttribute.Description}\n");
                }               
            }
        }



        public static void ListConstructors(Type type)
        {
            var constructors = type.GetConstructors();

            if (constructors.Any())
            {
                foreach (var constructor in constructors)
                {
                    var documentAttribute = (DocumentAttribute)constructor.GetCustomAttribute(typeof(DocumentAttribute));

                    if (documentAttribute != null)
                    {
                        Display($"\tConstructor: \n\tDescription: \n\t\t{documentAttribute.Description}");

                        string checkInput = string.IsNullOrEmpty(documentAttribute.Input) ? "" : $"\tInput: \n\t\t{documentAttribute.Input}";
                        Display(checkInput);

                        var checkOutput = string.IsNullOrEmpty(documentAttribute.Output) ? "" : $"\tOutput: \n\t\t{documentAttribute.Output}";
                        Display(checkOutput);

                    }
                }

            }
        }

        public static void ListProperties(Type type)
        {
            var properties = type.GetProperties();

            if (properties.Any())
            {
                foreach (var property in properties)
                {
                    var documentAttribute = (DocumentAttribute)property.GetCustomAttribute(typeof(DocumentAttribute));

                    if (documentAttribute != null && !string.IsNullOrEmpty(documentAttribute.Description))
                    {
                        Display($"\n\tProperty: {property.Name}\n\tDescription: {documentAttribute.Description}\n");
                    }
                }
            }
        }

        public static void ListMethods(Type type)
        {
            var methods = type.GetMethods();

            foreach( var method in methods)
            {
                var documentAttribute = (DocumentAttribute)method.GetCustomAttribute(typeof(DocumentAttribute));

                if (documentAttribute != null && !string.IsNullOrEmpty(documentAttribute.Description))
                {
                    Display($"\tMethod: {method.Name}\n\tDescription: {documentAttribute.Description}\n");

                    string checkInput = string.IsNullOrEmpty(documentAttribute.Input) ? "" : $"\n\tInput: \n\t\t{documentAttribute.Input}";
                    Display(checkInput);

                    var checkOutput = string.IsNullOrEmpty(documentAttribute.Output) ? "" : $"\n\tOutput: \n\t\t{documentAttribute.Output}";
                    Display(checkOutput);
                }
            }
        }    
}
