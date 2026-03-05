
namespace SistemaRestaurantesSenator
{
    public class Menu
    {
        public static void MostrarMenu()
        {
            while (true)
            {
                //Menu
                Console.WriteLine("\n---------------------------------------------------------");
                Console.WriteLine("Bievenido al Sistema de Reservas de Restaurantes Senator!");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Realizar Reserva.");
                Console.WriteLine("2. Eliminar Reserva.");
                Console.WriteLine("3. Ver Disponibilidad.");
                Console.WriteLine("4. Imprimir Listado.");
                Console.WriteLine("5. Salir");
                Console.WriteLine("\nColocar el número de la acción que desea realizar.");

                int opcion = int.Parse(Console.ReadLine()!);

                switch (opcion)
                {
                    case 1:
                        string nombreCliente = CRUDReserva.PedirNombre();
                        int cantidadPersonas = CRUDReserva.PedirCantidadPersonas();
                        string restaurante = CRUDReserva.SeleccionarRestaurante();
                        string horario = CRUDReserva.SeleccionarHorario();

                        Reserva? reserva = CRUDReserva.RealizarReserva(nombreCliente, cantidadPersonas, restaurante, horario);

                        if (reserva != null)
                        {
                            CRUDReserva.MostrarResumen(reserva);
                        }
                        break;
                    case 2:
                        CRUDReserva.EliminarReserva();
                        break;
                    case 3:
                        CRUDReserva.VerDisponibilidad();
                        break;
                    case 4:
                        CRUDReserva.ImprimirListado();
                        break;
                    case 5:
                        CRUDReserva.Salir();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }
            }
        }
    }
}
