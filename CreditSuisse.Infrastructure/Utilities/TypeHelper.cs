using System.Reflection;

namespace CreditSuisse.Infrastructure.Utilities
{
    public static class TypeHelper
    {
        public static List<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class
        {
            List<T> objects = new();
            var listOfType = Assembly.GetAssembly(typeof(T))
                .GetTypes()
                .Where(myType => myType.IsClass
                        && !myType.IsAbstract
                        && myType.IsSubclassOf(typeof(T)));

            foreach (Type type in listOfType)
            {
                objects.Add((T)Activator.CreateInstance(type, constructorArgs));
            }

            return objects;
        }
    }
}
