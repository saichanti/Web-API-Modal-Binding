namespace WebApiModalBinding
{
    public class Employee
    {
        public int id { get; set; }
        public string? name { get; set; }
        public int age { get; set; }
        public string? address { get; set; }

        internal static object Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        internal static void Remove(object delEmp)
        {
            throw new NotImplementedException();
        }
    }
}
