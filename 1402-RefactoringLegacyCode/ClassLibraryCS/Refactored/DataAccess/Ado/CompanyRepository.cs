using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace ClassLibraryCS.Refactored.DataAccess.Ado
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DbProviderFactory factory;

        private readonly string connectionString;

        public CompanyRepository()
        {
            const string connectionStringName = "CompactDatabase";
            string providerName = ConfigurationManager.ConnectionStrings[connectionStringName].ProviderName;
            this.factory = DbProviderFactories.GetFactory(providerName);
            this.connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }

        public void Delete(int id)
        {
            using (DbConnection connection = this.MakeConnection())
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Company SET IsDeleted = 1 WHERE Id = @id";
                command.CommandType = CommandType.Text;

                DbParameterFactory parameterFactory = this.MakeParameterFactory();
                DbParameter parameter = parameterFactory.Make("id", DbType.Int32);
                command.Parameters.Add(parameter);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Company> SelectAll()
        {
            var companies = new List<Company>();

            using (DbConnection connection = this.MakeConnection())
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Company WHERE (IsDeleted = 0)";
                command.CommandType = CommandType.Text;

                connection.Open();

                using (DbDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        var company = new Company
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            StreetLine1 = reader["StreetLine1"].ToString(),
                            StreetLine2 = reader["StreetLine2"].ToString(),
                            City = reader["City"].ToString(),
                            State = reader["State"].ToString(),
                            ZipCode = reader["ZipCode"].ToString(),
                            IsDeleted = false
                        };
                        companies.Add(company);
                    }
                }
            }

            return companies;
        }

        public void Save(Company company)
        {
            if (company.Id > 0)
            {
                this.Update(company);
            }
            else
            {
                this.Add(company);
            }
        }

        public Company SelectById(int id)
        {
            Company company;

            using (DbConnection connection = this.MakeConnection())
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Company WHERE Id = @id";
                command.CommandType = CommandType.Text;

                DbParameterFactory parameterFactory = this.MakeParameterFactory();
                DbParameter parameter = parameterFactory.Make("id", DbType.Int32);
                command.Parameters.Add(parameter);

                connection.Open();

                using (DbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow | CommandBehavior.CloseConnection))
                {
                    reader.Read();
                    company = new Company
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        StreetLine1 = reader["StreetLine1"].ToString(),
                        StreetLine2 = reader["StreetLine2"].ToString(),
                        City = reader["City"].ToString(),
                        State = reader["State"].ToString(),
                        ZipCode = reader["ZipCode"].ToString(),
                        IsDeleted = false
                    };
                }
            }

            return company;
        }

        private void Add(Company company)
        {
            //using (var connection = new SqlCeConnection(this.connectionString))
            //{
            //    const string commandText = @"INSERT INTO Company (Name, PhoneNumber, StreetLine1, StreetLine2, City, State, ZipCode, IsDeleted) VALUES (@name, @phoneNumber, @streetLine1, @streetLine2, @city, @state, @zipCode, 0);";

            //    var command = new SqlCeCommand(commandText, connection);

            //    var nameParameter = new SqlCeParameter("@name", company.Name);
            //    command.Parameters.Add(nameParameter);

            //    var phoneNumberParameter = new SqlCeParameter("@phoneNumber", company.PhoneNumber);
            //    command.Parameters.Add(phoneNumberParameter);

            //    var streetLine1Parameter = new SqlCeParameter("@streetLine1", company.StreetLine1);
            //    command.Parameters.Add(streetLine1Parameter);

            //    var streetLine2Parameter = new SqlCeParameter("@streetLine2", company.StreetLine2);
            //    command.Parameters.Add(streetLine2Parameter);

            //    var cityParameter = new SqlCeParameter("@city", company.City);
            //    command.Parameters.Add(cityParameter);

            //    var stateParameter = new SqlCeParameter("@state", company.State);
            //    command.Parameters.Add(stateParameter);

            //    var zipCodeParameter = new SqlCeParameter("@zipCode", company.ZipCode);
            //    command.Parameters.Add(zipCodeParameter);

            //    connection.Open();
            //    command.ExecuteNonQuery();
            //}
        }

        private void Update(Company company)
        {
            //using (var connection = new SqlCeConnection(this.connectionString))
            //{
            //    const string commandText = @"UPDATE Company SET Name = @name, PhoneNumber = @phoneNumber, StreetLine1 = @streetLine1, StreetLine2 = @streetLine2, City = @city, State = @state, ZipCode = @zipCode WHERE Id = @id";
            //    var updateCommand = new SqlCeCommand(commandText, connection);

            //    var idParameter = new SqlCeParameter("@id", company.Id);
            //    updateCommand.Parameters.Add(idParameter);

            //    var nameParameter = new SqlCeParameter("@name", company.Name);
            //    updateCommand.Parameters.Add(nameParameter);

            //    var phoneNumberParameter = new SqlCeParameter("@phoneNumber", company.PhoneNumber);
            //    updateCommand.Parameters.Add(phoneNumberParameter);

            //    var streetLine1Parameter = new SqlCeParameter("@streetLine1", company.StreetLine1);
            //    updateCommand.Parameters.Add(streetLine1Parameter);

            //    var streetLine2Parameter = new SqlCeParameter("@streetLine2", company.StreetLine2);
            //    updateCommand.Parameters.Add(streetLine2Parameter);

            //    var cityParameter = new SqlCeParameter("@city", company.City);
            //    updateCommand.Parameters.Add(cityParameter);

            //    var stateParameter = new SqlCeParameter("@state", company.State);
            //    updateCommand.Parameters.Add(stateParameter);

            //    var zipCodeParameter = new SqlCeParameter("@zipCode", company.ZipCode);
            //    updateCommand.Parameters.Add(zipCodeParameter);

            //    connection.Open();
            //    updateCommand.ExecuteNonQuery();
            //}
        }

        private DbConnection MakeConnection()
        {
            DbConnection connection = this.factory.CreateConnection();

            if (connection != null)
            {
                connection.ConnectionString = this.connectionString;
            }

            return connection;
        }

        private DbParameterFactory MakeParameterFactory()
        {
            return new DbParameterFactory(this.factory);
        }
    }
}
