
namespace SistemaRestaurantesSenator
{
    public class CRUDReserva
    {
        static List<string> restaurantes = new List<string> { "Ember", "Zao", "Grappa", "Larimar" };

        static Dictionary<string, int> capacidadRestaurantes = new Dictionary<string, int>
        {
            { "Ember", 3 },
            { "Zao", 4 },
            { "Grappa", 2 },
            { "Larimar", 3 }
        };

        static List<string> horarios = new List<string>
        {
            "6:00 PM - 8:00 PM",
            "8:00 PM - 10:00 PM"
        };
        
        static List<Reserva> reservas = new List<Reserva>();

        //Captura de datos de la reserva.
        public static string PedirNombre()
        {
            Console.WriteLine("\nIngrese su nombre:");
            return Console.ReadLine()!.ToUpper().Trim();
        }

        //Función para pedir la cantidad de personas de la reserva.
        public static int PedirCantidadPersonas()
        {
            int cantidad;

            Console.WriteLine("\nIngrese la cantidad de personas:");

            while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
            {
                Console.WriteLine("Ingrese un número válido de personas:");
            }

            return cantidad;
        }

        //Función para seleccionar el restaurante de la reserva.
        public static string SeleccionarRestaurante()
        {
            Console.WriteLine("\n¿En cuál restaurante desea reservar?");

            for (int i = 0; i < restaurantes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {restaurantes[i]}");
            }

            Console.WriteLine("\nIngresar el número del restaurante desea reservar.");

            int opcionRestaurante;

            while (!int.TryParse(Console.ReadLine(), out opcionRestaurante) || opcionRestaurante < 1 || opcionRestaurante > restaurantes.Count)
            {
                Console.WriteLine("Opción inválida. Intente nuevamente:");
            }

            return restaurantes[opcionRestaurante - 1];
        }

        //Función para seleccionar el horario de la reserva.
        public static string SeleccionarHorario()
        {
            Console.WriteLine("\nSeleccione el horario para su reserva:");

            for (int i = 0; i < horarios.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {horarios[i]}");
            }

            int opcionHorario;

            Console.WriteLine("\nIngrese el número del horario:");

            while (!int.TryParse(Console.ReadLine(), out opcionHorario) || opcionHorario < 1 || opcionHorario > horarios.Count)
            {
                Console.WriteLine("Opción inválida. Intente nuevamente:");
            }

            return horarios[opcionHorario - 1];
        }

        //Función para realizar una reserva.
        public static Reserva RealizarReserva(string nombreCliente, int cantidadPersonas, string restauranteSeleccionado, string horarioSeleccionado)
        {
            Reserva nuevaReserva = new Reserva
            {
                CodigoReserva = reservas.Count + 1,
                NombreCliente = nombreCliente,
                CantidadPersonas = cantidadPersonas,
                RestauranteSeleccionado = restauranteSeleccionado,
                HorarioSeleccionado = horarioSeleccionado
            };

            if (!CapacidadRestaurantes(nuevaReserva.RestauranteSeleccionado, nuevaReserva.HorarioSeleccionado))
            {
                Console.WriteLine("\nNo hay disponibilidad para ese restaurante en ese horario.");
                return null;
            }

            reservas.Add(nuevaReserva);


            return nuevaReserva;
        }

        //Función para mostrar el resumen de la reserva realizada.
        public static void MostrarResumen(Reserva reserva)
        {
            Console.WriteLine("\nReserva realizada con éxito!");
            Console.WriteLine("\nDetalles de la reserva:");
            Console.WriteLine($"Codigo de reserva: {reserva.CodigoReserva}");
            Console.WriteLine($"Nombre: {reserva.NombreCliente}");
            Console.WriteLine($"Cantidad de personas: {reserva.CantidadPersonas}");
            Console.WriteLine($"Restaurante: {reserva.RestauranteSeleccionado}");
            Console.WriteLine($"Horario: {reserva.HorarioSeleccionado}");
        }

        //Función para verificar la capacidad de los restaurantes en los horarios seleccionados.
        public static bool CapacidadRestaurantes(string restauranteSeleccionado, string horarioSeleccionado)
        {

            int reservasExistentes = reservas.Count(r =>
            r.RestauranteSeleccionado == restauranteSeleccionado &&
            r.HorarioSeleccionado == horarioSeleccionado);

            int capacidadMaxima = capacidadRestaurantes[restauranteSeleccionado];

            return reservasExistentes < capacidadMaxima;
        }

        //Función de eliminar una reserva.
        public static void EliminarReserva()
        {
            ImprimirListado();

            Console.WriteLine("\nIngrese el código de la reserva que desea eliminar:");
            int codigoReserva = int.Parse(Console.ReadLine()!);

            Reserva reservaAEliminar = reservas.FirstOrDefault(r => r.CodigoReserva == codigoReserva);

            if (reservaAEliminar != null)
            {
                reservas.Remove(reservaAEliminar);
                Console.WriteLine("\nReserva eliminada con éxito.");
            }
            else
            {
                Console.WriteLine("\nNo se encontró una reserva con ese código.");
            }
        }

        //Función que muestra la disponibilidad de los restaurantes y horarios.
        public static void VerDisponibilidad()
        {
            Console.WriteLine("\nDisponibilidad de restaurantes y horarios:");
            foreach (var restaurante in restaurantes)
            {
                Console.WriteLine($"\nRestaurante: {restaurante}");
                foreach (var horario in horarios)
                {
                    int reservasEnHorario = reservas.Count(r => r.RestauranteSeleccionado == restaurante && r.HorarioSeleccionado == horario);
                    int capacidadMaxima = capacidadRestaurantes[restaurante];
                    int disponibles = capacidadMaxima - reservasEnHorario;

                    Console.WriteLine($"Horario: {horario} - Reservas: {reservasEnHorario} - Disponibles: {disponibles}");
                }
            }

        }

        //Función que muestra el listado de reservas realizadas.
        public static void ImprimirListado()
        {
            Console.WriteLine("Listado de reservas:");
            foreach (var reserva in reservas)
            {
                Console.WriteLine($"\nCódigo: {reserva.CodigoReserva}");
                Console.WriteLine($"Cliente: {reserva.NombreCliente}");
                Console.WriteLine($"Cantidad de personas: {reserva.CantidadPersonas}");
                Console.WriteLine($"Restaurante: {reserva.RestauranteSeleccionado}");
                Console.WriteLine($"Horario: {reserva.HorarioSeleccionado}");
            }
        }

        //Función para salir del programa.
        public static void Salir()
        {
            Console.WriteLine("\nGracias por usar el Sistema de Reservas de Restaurantes Senator. ¡Hasta luego!");
            Environment.Exit(0);
        }

    }
}
