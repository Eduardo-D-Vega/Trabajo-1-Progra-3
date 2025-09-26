using Practica1;

List<Producto> productos = new List<Producto>();

bool menu = true;

do
{
    MostrarMenu();
}while (menu);

static void MostrarMenu()
{
    Console.WriteLine("\n=== MENU PRINCIPAL ===");
    Console.WriteLine("1. Registrar proveedor");
    Console.WriteLine("2. Registrar producto");
    Console.WriteLine("3. Crear orden de compra");
    Console.WriteLine("4. Visualizar ordenes existentes");
    Console.WriteLine("5. Actualizar inventario");
    Console.WriteLine("6. Salir de la aplicacion");
}

bool ProcesarOpcionMenu() 
{
    try
    {
        int opcion = int.Parse(Console.WriteLine());

        switch(opcion)
        {
            case 1:
                RegistrarProveedor();
                break;
            case 2:
                RegistrarProducto();
                break;
            case 3:
                CrearOrdenDeCompra();
                break;
            case 4:
                VisualizarOrdenesExistentes();
                break;
            case 5:
                ActualizarInventario();
                break;
            case 6:
                return false;
            default:
                Console.WriteLine("Opcion no valida, por favor seleccione una opcion del 1 al 6");
                break;
        }
    }
}