using System;
using System.Collections.Generic;
using System.Web.UI;
using ClassLibraryCS.Refactored;
using ClassLibraryCS.Refactored.Presentation;

namespace WebApplicationCS.Refactored
{
    public partial class Companies : Page, ICompanyView
    {
        public IEnumerable<Company> CompanyListField
        {
            set
            {
                this.CompanyListView.DataSource = value;
                this.CompanyListView.DataBind();
            }
        }

        public string NameField
        {
            get { return this.NameTextBox.Text.Trim(); }
            set { this.NameTextBox.Text = value; }
        }

        public string PhoneNumberField
        {
            get { return this.PhoneNumberTextBox.Text.Trim(); }
            set { this.PhoneNumberTextBox.Text = value; }
        }

        public string StreetLine02Field
        {
            get { return this.StreetLine02TextBox.Text.Trim(); }
            set { this.StreetLine02TextBox.Text = value; }
        }

        public string StreetLine01Field
        {
            get { return this.StreetLine01TextBox.Text.Trim(); }
            set { this.StreetLine01TextBox.Text = value; }
        }

        public string CityField
        {
            get { return this.CityTextBox.Text.Trim(); }
            set { this.CityTextBox.Text = value; }
        }

        public string StateField
        {
            get { return this.StateTextBox.Text.Trim(); }
            set { this.StateTextBox.Text = value; }
        }

        public string ZipCodeField
        {
            get { return this.ZipCodeTextBox.Text.Trim(); }
            set { this.ZipCodeTextBox.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var presenter = new CompanyPresenter(this);
                presenter.List(); 
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            var presenter = new CompanyPresenter(this);
            presenter.Add();

            this.SetFormToAddNew();
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            var presenter = new CompanyPresenter(this);
            presenter.Clear();

            this.SetFormToAddNew();
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (this.CompanyListView.SelectedDataKey != null)
            {
                int id = Convert.ToInt32(this.CompanyListView.SelectedDataKey.Value);

                var presenter = new CompanyPresenter(this);
                presenter.Update(id);
                this.SetFormToAddNew();
            }
        }

        protected void CompanyListView_SelectedIndexChanging(object sender, System.Web.UI.WebControls.ListViewSelectEventArgs e)
        {
            // needed by compiler
        }

        protected void CompanyListView_ItemDeleting(object sender, System.Web.UI.WebControls.ListViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(e.Keys[0]);
            var presenter = new CompanyPresenter(this);
            presenter.Delete(id);

            this.SetFormToAddNew();
        }

        protected void CompanyListView_ItemCommand(object sender, System.Web.UI.WebControls.ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Select":
                    int selectId = Convert.ToInt32(e.CommandArgument);
                    var presenter = new CompanyPresenter(this);
                    presenter.Select(selectId);
                    this.SetFormToUpdate();
                    this.NameTextBox.Focus();
                    break;
            }
        }

        private void SetFormToAddNew()
        {
            this.AddUpdateHeaderLiteral.Text = "Add";
            this.AddButton.Visible = true;
            this.UpdateButton.Visible = false;

            this.NameTextBox.Focus();
        }

        private void SetFormToUpdate()
        {
            this.AddUpdateHeaderLiteral.Text = "Update";
            this.AddButton.Visible = false;
            this.UpdateButton.Visible = true;
        }
    }
}