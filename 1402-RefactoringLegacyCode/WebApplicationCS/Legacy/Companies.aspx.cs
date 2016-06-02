using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;
using System.Web.UI;
using ClassLibraryCS.Legacy;

namespace WebApplicationCS.Legacy
{
    public partial class Companies : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.LoadCompanies();
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CompactDatabase"].ConnectionString;
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                string commandText = @"INSERT INTO Company (Name, PhoneNumber, StreetLine1, StreetLine2, City, State, ZipCode, IsDeleted) VALUES (@name, @phoneNumber, @streetLine1, @streetLine2, @city, @state, @zipCode, 0);";

                SqlCeCommand command = new SqlCeCommand(commandText, connection);

                SqlCeParameter nameParameter = new SqlCeParameter("@name", NameTextBox.Text);
                command.Parameters.Add(nameParameter);

                SqlCeParameter phoneNumberParameter = new SqlCeParameter("@phoneNumber", PhoneNumberTextBox.Text);
                command.Parameters.Add(phoneNumberParameter);

                SqlCeParameter streetLine1Parameter = new SqlCeParameter("@streetLine1", StreetLine01TextBox.Text);
                command.Parameters.Add(streetLine1Parameter);

                SqlCeParameter streetLine2Parameter = new SqlCeParameter("@streetLine2", StreetLine02TextBox.Text);
                command.Parameters.Add(streetLine2Parameter);

                SqlCeParameter cityParameter = new SqlCeParameter("@city", CityTextBox.Text);
                command.Parameters.Add(cityParameter);

                SqlCeParameter stateParameter = new SqlCeParameter("@state", StateTextBox.Text);
                command.Parameters.Add(stateParameter);

                SqlCeParameter zipCodeParameter = new SqlCeParameter("@zipCode", ZipCodeTextBox.Text);
                command.Parameters.Add(zipCodeParameter);

                connection.Open();
                command.ExecuteNonQuery();
            }

            this.Clear();
            this.LoadCompanies();
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (this.CompanyListView.SelectedDataKey != null)
            {
                int id = Convert.ToInt32(this.CompanyListView.SelectedDataKey.Value);    
                this.UpdateCompany(id);
                this.LoadCompanies();
                this.SetAddHeader();
                this.Clear();
            }
        }

        protected void CompanyListView_SelectedIndexChanging(object sender, System.Web.UI.WebControls.ListViewSelectEventArgs e)
        {
            // needed by compiler
        }

        protected void CompanyListView_ItemDeleting(object sender, System.Web.UI.WebControls.ListViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(e.Keys[0]);
            this.DeleteCompany(id);
            this.LoadCompanies();
        }

        protected void CompanyListView_ItemCommand(object sender, System.Web.UI.WebControls.ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Select":
                    int selectId = Convert.ToInt32(e.CommandArgument);
                    this.SelectCompany(selectId);
                    break;
            }
        }

        private void UpdateCompany(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CompactDatabase"].ConnectionString;
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                const string commandText = @"UPDATE Company SET Name = @name, PhoneNumber = @phoneNumber, StreetLine1 = @streetLine1, StreetLine2 = @streetLine2, City = @city, State = @state, ZipCode = @zipCode WHERE Id = @id";

                SqlCeCommand command = new SqlCeCommand(commandText, connection);
                
                SqlCeParameter idParameter = new SqlCeParameter("@id", id);
                command.Parameters.Add(idParameter);

                SqlCeParameter nameParameter = new SqlCeParameter("@name", NameTextBox.Text);
                command.Parameters.Add(nameParameter);

                SqlCeParameter phoneNumberParameter = new SqlCeParameter("@phoneNumber", PhoneNumberTextBox.Text);
                command.Parameters.Add(phoneNumberParameter);

                SqlCeParameter streetLine1Parameter = new SqlCeParameter("@streetLine1", StreetLine01TextBox.Text);
                command.Parameters.Add(streetLine1Parameter);

                SqlCeParameter streetLine2Parameter = new SqlCeParameter("@streetLine2", StreetLine02TextBox.Text);
                command.Parameters.Add(streetLine2Parameter);

                SqlCeParameter cityParameter = new SqlCeParameter("@city", CityTextBox.Text);
                command.Parameters.Add(cityParameter);

                SqlCeParameter stateParameter = new SqlCeParameter("@state", StateTextBox.Text);
                command.Parameters.Add(stateParameter);

                SqlCeParameter zipCodeParameter = new SqlCeParameter("@zipCode", ZipCodeTextBox.Text);
                command.Parameters.Add(zipCodeParameter);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void SelectCompany(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CompactDatabase"].ConnectionString;
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                SqlCeCommand command = new SqlCeCommand("SELECT * FROM Company WHERE Id = @id", connection);
                SqlCeParameter parameter = new SqlCeParameter("@id", id);
                command.Parameters.Add(parameter);

                connection.Open();
                using (SqlCeDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow | CommandBehavior.CloseConnection))
                {
                    reader.Read();
                    NameTextBox.Text = reader["Name"].ToString();
                    PhoneNumberTextBox.Text = reader["PhoneNumber"].ToString();
                    StreetLine01TextBox.Text = reader["StreetLine1"].ToString();
                    StreetLine02TextBox.Text = reader["StreetLine2"].ToString();
                    CityTextBox.Text = reader["City"].ToString();
                    StateTextBox.Text = reader["State"].ToString();
                    ZipCodeTextBox.Text = reader["ZipCode"].ToString();
                }
            }

            this.SetUpdateHeader();
            this.NameTextBox.Focus();
        }

        private void DeleteCompany(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CompactDatabase"].ConnectionString;
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                SqlCeCommand command = new SqlCeCommand("UPDATE Company SET IsDeleted = 1 WHERE Id = @id", connection);
                SqlCeParameter parameter = new SqlCeParameter("@id", id);
                command.Parameters.Add(parameter);

                connection.Open();
                command.ExecuteNonQuery();
            }

            this.SetAddHeader();
        }

        private void LoadCompanies()
        {
            List<Company> companies = new List<Company>();

            string connectionString = ConfigurationManager.ConnectionStrings["CompactDatabase"].ConnectionString;
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                SqlCeCommand command = new SqlCeCommand("SELECT * FROM Company WHERE (IsDeleted = 0)", connection);

                connection.Open();

                using (SqlCeDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        Company company = new Company();
                        company.Id = Convert.ToInt32(reader["Id"]);
                        company.Name = reader["Name"].ToString();
                        company.PhoneNumber = reader["PhoneNumber"].ToString();
                        company.StreetLine1 = reader["StreetLine1"].ToString();
                        company.StreetLine2 = reader["StreetLine2"].ToString();
                        company.City = reader["City"].ToString();
                        company.State = reader["State"].ToString();
                        company.ZipCode = reader["ZipCode"].ToString();
                        company.IsDeleted = false;
                        companies.Add(company);
                    }
                }
            }

            this.CompanyListView.DataSource = companies;
            this.CompanyListView.DataBind();
        }

        private void Clear()
        {
            this.NameTextBox.Text = string.Empty;
            this.PhoneNumberTextBox.Text = string.Empty;
            this.StreetLine01TextBox.Text = string.Empty;
            this.StreetLine02TextBox.Text = string.Empty;
            this.CityTextBox.Text = string.Empty;
            this.StateTextBox.Text = string.Empty;
            this.ZipCodeTextBox.Text = string.Empty;

            this.SetAddHeader();
            this.NameTextBox.Focus();
        }

        private void SetAddHeader()
        {
            this.AddUpdateHeaderLiteral.Text = "Add";
            this.AddButton.Visible = true;
            this.UpdateButton.Visible = false;
        }

        private void SetUpdateHeader()
        {
            this.AddUpdateHeaderLiteral.Text = "Update";
            this.AddButton.Visible = false;
            this.UpdateButton.Visible = true;
        }
    }
}