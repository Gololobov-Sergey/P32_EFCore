using Microsoft.Data.SqlClient;
using Dapper;
using Academy_Dapper.Models;
using Z.Dapper.Plus;
using System.Text.RegularExpressions;
using System.Linq;
using System.Data;


namespace Academy_Dapper
{
    

    internal class Program
    {
        static string ConnectionString = "Data Source=TAURUS\\SQLEXPRESS;" +
            "Initial Catalog=Student-Dapper;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;" +
            "Encrypt=False;" +
            "Trust Server Certificate=True;" +
            "Application Intent=ReadWrite;" +
            "Multi Subnet Failover=False";

        static void Main(string[] args)
        {
            // CONNECTION
            var connection = new SqlConnection(ConnectionString);



            // CREATE TABLE
            //connection.CreateTable<Group>();
            //connection.CreateTable<Student>();


            //// SEED		
            //var groups = new List<Group>
            //{
            //    new Group { Id = 1, Name = "Group A" },
            //    new Group { Id = 2, Name = "Group B" }
            //};
            //connection.BulkInsert(groups);

            //var students = new List<Student>
            //{
            //    new Student { Id = 1, Name = "Alice", BirthDay = new DateTime(2000, 1, 1), GroupId = 1 },
            //    new Student { Id = 2, Name = "Bob", BirthDay = new DateTime(2001, 2, 2), GroupId = 1 },
            //    new Student { Id = 3, Name = "Charlie", BirthDay = new DateTime(2002, 3, 3), GroupId = 2 }
            //};
            //connection.BulkInsert(students);



            //// INSERT
            //string insertStudent = "INSERT INTO Students (Id, Name, BirthDay, GroupId) " +
            //    "VALUES (@Id, @Name, @BirthDay, @GroupId)";

            //object st = new { Id = 4, Name = "David", BirthDay = new DateTime(2003, 4, 4), GroupId = 2 };

            //int row = connection.Execute(insertStudent, st);

            //Console.WriteLine($"Added {row} rows");


            // UPDATE
            //string insertStudent = "UPDATE Students SET GroupId = @groupId WHERE Id = @id";
            //int row = connection.Execute(insertStudent, new { groupId = 2, id = 4});
            //Console.WriteLine($"Updated {row} rows");



            //// CODE
            //var outputList = connection.Query<Student>("SELECT * FROM Students").ToList();

            //// TEST
            //foreach (var student in outputList)
            //{
            //    Console.WriteLine($"{student.Id} {student.Name} {student.BirthDay} {student.GroupId}");
            //}



            //var sql = "SELECT COUNT(*) FROM Students";
            //var count = connection.ExecuteScalar<int>(sql);
            //Console.WriteLine($"Total students: {count}");



            //var sql = "SELECT * FROM Students WHERE GroupId = @groupId";
            //var st = connection.Query<Student>(sql, new { groupId = 1 });
            //foreach (var student in st)
            //{
            //    Console.WriteLine($"{student.Id} {student.Name} {student.BirthDay} {student.Group}");
            //}


            string sql = "SELECT * FROM [Students] as s join [Groups] as g on s.GroupId = g.Id";
            var stud = connection.Query<Student, Academy_Dapper.Models.Group, Student>(sql, (student, group) =>
            {
                student.Group = group;
                return student;
            }, 
            splitOn: "Id");

            foreach (var student in stud)
            {
                Console.WriteLine($"{student.Id} {student.Name} {student.BirthDay} {student.Group.Name}");
            }


            //var st = connection.ExecuteReader(sql, new { groupId = 1 });
            //DataTable dt = new DataTable();
            //dt.Load(st);
            //dt.Print();

        }
    }
}
