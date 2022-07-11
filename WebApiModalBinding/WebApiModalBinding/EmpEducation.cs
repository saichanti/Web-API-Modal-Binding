namespace WebApiModalBinding
{
    public class EmpEducation
    {
        public int empId { get; set; }
        public string? empEducation { get; set; }
        public int passingYear { get; set; }
        public int marksPercentage { get; set; }
        internal static object Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        internal static void Remove(object education)
        {
            throw new NotImplementedException();
        }
    }
}
