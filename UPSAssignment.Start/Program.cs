using System;
using UPSAssignment.View;
using UPSAssignment.Controller;


namespace UseMVCApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                int i = 1;
                UsersView view = new UsersView();
                view.Visible = false;

                UsersController controller = new UsersController(view);
                controller.LoadView(1);
                view.ShowDialog();
            }
            catch (Exception ex)
            {

            }
            finally { }

        }
       
    }
}
