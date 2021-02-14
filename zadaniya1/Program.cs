using System;

using System.Data;
using System.Data.SqlClient;


namespace proj
{
	class Program
	{
		static void Main(string[] args)
		{
			const string connectionString = @"Data source=Muhammad\SQLEXPRESS; initial catalog=person; Integrated Security=True";
			SqlConnection connection = new SqlConnection(connectionString);

			connection.Open();
			if (connection.State == ConnectionState.Open) Console.WriteLine("Connected Successfuly ");
			int x;
			Console.WriteLine("Введите число: \n1  Insert \n2 Select All\n3 Select by Id\n4 Update\n5 Delet");
			x = Convert.ToInt32(Console.ReadLine());
			SqlCommand command = connection.CreateCommand();
			if (x == 1)
			{
				Console.Write("Name = ");
				string Name = Console.ReadLine();
				Console.Write("Surname = ");
				string Surname = Console.ReadLine();
				Console.Write("MiddleName = ");
				string MiddleName = Console.ReadLine();
				Console.Write("DateofBirth = ");
				string DateofBirth = Console.ReadLine();
				command.CommandText = $"Insert into Person ([Name],[Surname],[MiddleName], [DateofBirth]) values ('{Name}', '{Surname}', '{MiddleName}', '{DateofBirth}')";
				var result = command.ExecuteNonQuery();
				if (result > 0) Console.WriteLine("The person is added!");



			}

			if (x == 2)
			{
				command.CommandText = "Select * from Person";
				var reader = command.ExecuteReader();
				while (reader.Read())
				{

					Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Surname: {reader["Surname"]}, Middle Name: {reader["MiddleName"]}, DateofBirth{reader["DateofBirth"]}");
				}

			}
			if (x == 3)
			{
				int id;
				Console.WriteLine("Введите ID ");
				id = Convert.ToInt32(Console.ReadLine());
				command.CommandText = $"Select *from Person where Id = {id}";

				var reader = command.ExecuteReader();
				while (reader.Read())
				{

					Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Surname: {reader["Surname"]}, MiddleName: {reader["MiddleName"]}, Date of Birth{reader["DateofBirth"]}");
				}

			}
			if (x == 4)
			{
				int idnum = 0;
				Console.WriteLine("Введите ID = ");
				idnum = Convert.ToInt32(Console.ReadLine());

				string novaname;
				Console.WriteLine("Введите новое имя = ");
				novaname = Console.ReadLine();
				string novasurname;
				Console.WriteLine("Введите новую фамилию = ");
				novasurname = Console.ReadLine();
				string novamidlname;
				Console.WriteLine("Введите новое отчество = ");
				novamidlname = Console.ReadLine();
				string novabirthday;
				Console.WriteLine("Введите новую дату рождения = ");
				novabirthday = Console.ReadLine();
				command.CommandText = "update person set " + "Name = " + $"'{novaname}'," + "Surname = " + $"'{novasurname}'," + "MiddleName = " + $"'{novamidlname}'," + "DateofBirth = " + $"'{novabirthday} '" + "where Id = " + $"'{idnum}'";

				int result = command.ExecuteNonQuery();

				if (result > 0)
				{
					Console.WriteLine("Seccessfully uploaded information!");
				}
				var reader = command.ExecuteReader();
				while (reader.Read())
				{

					Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Surname: {reader["Surname"]}, MiddleName: {reader["MiddleName"]}, Date of Birth{reader["DateofBirth"]}");
				}


			}
			if (x == 5)
			{
				int id;
				Console.WriteLine("Введите ID человека которого вы желаете удалить = ");
				id = Convert.ToInt32(Console.ReadLine());
				command.CommandText = $"Delete Person where Id = {id}";
				int result1 = command.ExecuteNonQuery();
				if (result1 > 0)
				{
					Console.WriteLine("Seccessfully deleted the person under ID = " + id);
				}

			}
		}
	}
}