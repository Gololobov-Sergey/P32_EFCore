namespace Hospital_Models
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (HospitalContext db = new HospitalContext())
            {
                foreach (var item in db.Doctors)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
