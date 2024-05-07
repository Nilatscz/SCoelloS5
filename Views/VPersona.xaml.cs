using SCoelloS5.Models;

namespace SCoelloS5.Views;

public partial class VPersona : ContentPage
{
	public VPersona()
	{
		InitializeComponent();
	}

    private void BtnInsertar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.personRepo.AddNewPerson(TxtName.Text);
        lblStatus.Text = App.personRepo.StatusMessage;
    }

    private void BtnObtener_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        List<Persona> people =App.personRepo.getAllPeople();
        ListaPersona.ItemsSource = people;
        lblStatus.Text = App.personRepo.StatusMessage;
    }

    private void BtnEliminar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        int id = Convert.ToInt32(TxtId.Text);
        App.personRepo.Eliminarperson(id,TxtName.Text);
        lblStatus.Text = App.personRepo.StatusMessage;
    }

    private void BtnActualizar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        int id = Convert.ToInt32(TxtId.Text);
        App.personRepo.ActualizarPerson(id,TxtName.Text);
        lblStatus.Text = App.personRepo.StatusMessage;
    }
}