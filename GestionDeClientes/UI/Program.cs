
using GestionDeClientes.UI;

namespace GestionDeClientes
{
	using WFrms = System.Windows.Forms;
    class MainClass
    {
        public static void Main(string[] args) { 
	        WFrms.Application.Run( new MainWindowController().MainView);
        }
    }
}
