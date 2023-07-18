namespace Todo.Pages;

public partial class AllNotesPage : ContentPage
{
	public AllNotesPage()
	{
		InitializeComponent();

        //this.Appearing += OnAppearing;
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        notesCollection.SelectedItem = null;
    }

    //private void OnAppearing(object sender, EventArgs e)
    //{
    //    AppShell ap = new AppShell();
    //    AppShell.SetFlyoutBehavior(ap, (FlyoutBehavior)0);
    //}
}