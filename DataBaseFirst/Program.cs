namespace DataBaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (Hospital5Context db = new Hospital5Context())
            //{
            //    var doctors = db.Doctors.ToList();
            //    foreach (var doc in doctors)
            //    {
            //        Console.WriteLine($"{doc.Id} {doc.Name} {doc.Surname}");
            //    }
            //}

            //// add
            //using (Hospital5Context db = new Hospital5Context())
            //{
            //    Doctor doc = new Doctor
            //    {
            //        Name = "Айболит",
            //        Surname = "Айболитович",
            //        Salary = 1000,
            //        Premium = 100
            //    };

            //    db.Doctors.Add(doc);
            //    db.SaveChanges();
            //}


            //// edit
            //using (Hospital5Context db = new Hospital5Context())
            //{
            //    var doc = db.Doctors.Where(d => d.Id == 7).First();
            //    doc.Name = "Бармалей";
            //    doc.Salary = 10;

            //    db.SaveChanges();
            //}


            // delete
            using (Hospital5Context db = new Hospital5Context())
            {
                var doc = db.Doctors.Where(d => d.Id == 7).First();
                db.Doctors.Remove(doc);

                db.SaveChanges();
            }

        }
    }
}
